using Chronos.Data.DBAccess.BLogic;
using Chronos.Data.Shared;
using Chronos.Data.Shared.Model;
using Chronos.Data.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualEffects;
using VisualEffects.Animations.Effects;
using VisualEffects.Easing;
using static Chronos.Data.Shared.Model.Enumerations;
using static Chronos.Data.Shared.Model.ERP;

namespace Chronos.Modules.Consolidation
{
    public partial class OrderConsolidation : UserControl
    {
        private IChronosGlobal _chronosGlobal;

        #region Local Configurations
        private int _lclFacilityId = 0;
        private int _lclCellId = 0;
        private int _lclOBCId = 0;
        private int _lclStationId = 0;
        private string _lclEmpBadge;

        private Cells _lclcells;

        private List<OBCConfigDetails_Input> _lclInputs;
        private List<Flows> _lclStationFlow;

        private bool _lclValidateFlow = false;
        private bool _lclValidateLastOp = false;
        private bool _lclStartOfCell = false;
        private bool _lclEndOfCell = false;


        private bool _lclAllowDefects = false;
        private bool _lclAllowDownTime = false;

        private string _lclPrinterName;
        private bool _lclAllowReprint = false;
        private int _lclNumberOfCopies = 1;
        private bool _lclAskUser = false;

        private bool _lclAutoOutput = false;
        private bool _lclTrackPrint = false;
        private bool _lclTrackReprint = false;
        private bool _lclReportToERP = false;

        private string _lclRackPoP;
        private int[] _lclRacksIds;
        #endregion

        private string _expectedInput;
        private int _instructionControl = 0;

        List<RacksAllocations> _rackDataToConsolidate;
        private Guid _lastInsertedTrackId;
        private string _lastRunNumber = "";
        private string _lastWorktag = "";
        private string _orderNumberToProcess = "";

        private string _pnlStatus = "CLOSED";
        VisualEffects.Animators.AnimationStatus _pnlScanContainerAnimation;
        private int _pnlScanContainerObjective = 0;
        VisualEffects.Animators.AnimationStatus _pnlCompSetAnimation;
        private int _pnlCompSetObjective = 0;

        VisualEffects.Animators.AnimationStatus _pnlGridHolderAnimation;
        VisualEffects.Animators.AnimationStatus _formChangeColorAnimation;
        VisualEffects.Animators.AnimationStatus _headerChangeColorAnimation;

        System.Windows.Forms.Timer _errorTimer;
        private int _errorTicks = 0;
        private Color _currentFormColor;


        System.Windows.Forms.Timer _rackScanningTimer;
        int _rackScanningRefreshRate = 10;
        int _rackScanningRefreshCtrl = 0;

        public OrderConsolidation(IChronosGlobal chronosGlobal)
        {
            InitializeComponent();
            _pnlStatus = "CLOSED";
            InitErrorTimer();
            HideMessageFromUser();
            _chronosGlobal = chronosGlobal;
            LoadStationsSettings();
            GetInstructions();
            ResetForm();
            FromRackOrTrack();

        }

        #region Settings Loading
        private void LoadStationsSettings()
        {
            _lclFacilityId = _chronosGlobal.FacilityId;
            _lclCellId = _chronosGlobal.CellsInformation.CellId;
            _lclOBCId = _chronosGlobal.OperationsByCellConfiguration.OBCId;
            _lclStationId = _chronosGlobal.StationConfiguration.StationId;
            _lclEmpBadge = _chronosGlobal.MainUser.EmployeeBadge;

            _lclcells = new Cells();
            _lclcells = _chronosGlobal.CellsInformation;

            _lclInputs = new List<OBCConfigDetails_Input>();
            _lclInputs = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Inputs;

            _lclStationFlow = _chronosGlobal.FlowConfiguration;

            _lclValidateFlow = _chronosGlobal.StationConfiguration.ValidateFlow;
            _lclValidateLastOp = _chronosGlobal.StationConfiguration.ValidateLastOp;
            _lclPrinterName = _chronosGlobal.StationConfiguration.PrinterName.PrinterName;
            _lclStartOfCell = _chronosGlobal.OperationsByCellConfiguration.IsStartOfCell;
            _lclEndOfCell = _chronosGlobal.OperationsByCellConfiguration.IsEndOfCell;

            if(_lclEndOfCell)
                _lclReportToERP = _lclcells.MainSetting.ReportToFRN;

            _lclAllowDefects = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Config.AllowDefects;
            _lclAllowDownTime = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Config.AllowDownTime;

            _lclAutoOutput = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Tracking.AutoOutput;
            _lclTrackPrint = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Tracking.TrackLabelPrint;
            _lclTrackReprint = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Tracking.TrackLabelReprint;

            _lclNumberOfCopies = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Labels.NumberOfCopies;
            _lclAllowReprint = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Labels.AllowReprint;
            _lclAskUser = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Labels.AskUser;

            _lclRackPoP = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Racks.RackBehavior;
            _lclRacksIds = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Racks.RackId;
        }

        private void GetInstructions()
        {
            ShowInstructionsToUser();
            txtInput.Focus();
            txtInput.Select();
        }

        private void ShowInstructionsToUser()
        {
            _instructionControl = 0;
            lblInstruction.Text = _lclInputs[_instructionControl].Instructions.Instruction_es;
            _expectedInput = _lclInputs[_instructionControl].Instructions.InputName;
        }
        #endregion


        #region Form Controls
        private void TxtInput_KeyUp(object sender, KeyEventArgs e)
        {
            HideMessageFromUser();
            if (e.KeyCode == Keys.Enter)
            {
                string rawInput = txtInput.Text;
                string input = rawInput.TrimStart(new char[] { '0' });

                if (!string.IsNullOrWhiteSpace(input))
                    ValidateInput(input);
                else
                    ShowMessageToUser(_lclInputs[_instructionControl].Instructions.ErrorMessage_es, true);


                txtInput.Text = "";
            }
            else if (e.KeyCode == Keys.F10) //Logoff
            {
                ExitForm();
            }
        }

        private void OrderConsolidation_Load(object sender, EventArgs e)
        {
            RefreshRack();
            txtInput.Select();
        }

        private void OrderConsolidation_Resize(object sender, EventArgs e)
        {
            //if (_pnlStatus == "OPENED" && _pnlScanContainerAnimation.IsCompleted)
            //{
            //    _pnlScanContainerObjective = Screen.PrimaryScreen.Bounds.Top + 45;

            //    pnlScanContainer.Animate
            //    (
            //        new YLocationEffect(), //effect to apply implementing IEffect
            //        EasingFunctions.BackEaseIn, //easing to apply
            //        _pnlScanContainerObjective, //value to reach
            //        800, //animation duration in milliseconds
            //        0 //delayed start in milliseconds
            //    );
            //}
        }
        #endregion

        #region Data Processing
        private void ValidateInput(string input)
        {
            InputDataValidations.ValidateUserDataInput(_chronosGlobal, input, _lclFacilityId, out UserInputs InputType, out bool IsValid);

            if (!IsValid)
            {
                ShowMessageToUser(_lclInputs[_instructionControl].Instructions.ErrorMessage_es, true);
                return;
            }

            ChronosLabelTypes LabelType = ChronosValidations.GetLabelType(InputType);

            if (InputType == UserInputs.Unknown)
            {
                ShowMessageToUser(_lclInputs[_instructionControl].Instructions.ErrorMessage_es, true);
                return;
            }
            else if (InputType == UserInputs.BadgeID)
            {
                ExitForm();
                return;
            }
            else if (InputType == UserInputs.Defect)
            {
                ProcessDefectCode(input);
            }
            else if (InputType == UserInputs.DownTime)
            {
                ProcessDownTimeCode(input);
            }
            else
            {
                ProcessChronosLabel(LabelType, input);
            }
        }

        private void ProcessChronosLabel(ChronosLabelTypes LabelType, string LicensePlate)
        {
            //OpenConsolidationPanels();

            _lastRunNumber = "";
            //string OrderNumber = ChronosValidations.GetOrderNumberFromTrackingCode(LicensePlate);
            _lastWorktag = ChronosValidations.GetWorkTagFromTrackingCode(LicensePlate);
            //int LineNumber = int.Parse(ChronosValidations.GeLineNumberFromTrackingCode(LicensePlate));
            //int UnitNumber = 1;

            //Validate Model Flow
            FlowsLogic.IsModelFlowValid(_chronosGlobal, LabelType, LicensePlate, true, _lclStationFlow, out bool IsValidModel, out string ModelName);

            if (!IsValidModel)
            {
                ShowMessageToUser("Error: Esta estación no esta configurada para procesar el modelo " + ModelName, true);
                return;
            }

            //Extract Data from FRN
            //M1P_WorkOrderHeader WorkTagData = ERPLogic.GetMFGOrderNumberInfoByOrder(_chronosGlobal, WorkTag);
            //List<SGP_WorkOrderSegments> WorkTagSegments = ERPLogic.GetBuildInstructions(_chronosGlobal, WorkTag);
            //SGP_WorkOrderSegments FRNSegmentsInfo = new SGP_WorkOrderSegments();



            TrackingLogs LastRecord = TrackingLogsLogic.GetRecordData(_chronosGlobal, LicensePlate);

            if (LastRecord != null)
                _lastRunNumber = LastRecord.RunNumber;

            RacksAllocations rak = _rackDataToConsolidate.Find(r => r.LicensePlate == LicensePlate);
            
            if(rak != null)
            {
                InsertTrackingLog(LastRecord.RunNumber, rak.WorkTag, LicensePlate, rak.ComponentId);
                RefreshRackAllocationGrid(_orderNumberToProcess);
            }
        }

        private void ProcessDefectCode(string DefectCode)
        {

        }

        private void ProcessDownTimeCode(string DownTimeCode)
        {

        }

        private void InsertTrackingLog(string RunNumber, string WorkTag, string LicensePlate, int ComponentId)
        {
            Tuple<bool, Guid> AddTrackResult = new Tuple<bool, Guid>(false, Guid.Empty);

            bool isProcessed = TrackingLogsLogic.IsPartAlreadyProcessed(_chronosGlobal, RunNumber, LicensePlate, _lclOBCId);
            if(!isProcessed)
                AddTrackResult = TrackingLogsLogic.AddTrackRecordInput(_chronosGlobal, RunNumber, WorkTag, LicensePlate, _lclOBCId, null, _lclStationId, ComponentId, _lclEmpBadge);
            
            if (AddTrackResult.Item1)
                _lastInsertedTrackId = AddTrackResult.Item2;
            
            _lastWorktag = WorkTag;

            //AutoOutput
            if (_lclAutoOutput)
                TrackingLogsLogic.AddTrackRecordOutputAuto(_chronosGlobal, _lclStationId, _lclEmpBadge, "P", ComponentId);
        }

        private void ReportOrderAsCompleted(string RunNumber, string WorkTag)
        {
            Tuple<bool, string> res = CompletedOrdersLogic.CheckOrderForCompletion(_chronosGlobal, _lclcells.FacilityNumber.ToString(), _lclcells.WorkCenter, _lclcells.DepartmentNumber.ToString(), RunNumber, _orderNumberToProcess, WorkTag, _lclCellId, _lclOBCId, _lclStationId, _lclReportToERP == true ? 1: 0);

            if (res.Item1)
                if (res.Item2 == "1")
                    RestartRackOrTrack();
        }

        private void RefreshRack()
        {
            List<RackConsolidationReport> rackdata = RacksLogic.GetRackConsolidationReportByOrder(_chronosGlobal, _lclCellId, _lclOBCId, _lclRacksIds);
            gcConsBySO.DataSource = rackdata;

            if (rackdata.Count > 0)
            {
                if (rackdata[0].OrderCompleted == 1)
                {
                    StopRackTimer();
                    txtInput.Text = "";
                    txtInput.Enabled = true;
                    txtInput.Focus();
                    txtInput.Select();
                    pnlScanContainer.Visible = true;
                    //pnlGridHolder.Visible = false;
                    lblUnityLabel.Visible = false;
                    _orderNumberToProcess = rackdata[0].OrderNumber;
                    lblRackScanning.Text = "Procesar Orden #" + _orderNumberToProcess + " en el " + rackdata[0].RackName + ", locación " + rackdata[0].RackLocation;
                    lblRackScanning.ForeColor = Color.Black;
                    lblInstruction.ForeColor = Color.Black;

                    //*www.codeproject.com/Articles/827808/Control-Animation-in-Winforms*//
                    _pnlGridHolderAnimation = pnlGridHolder.Animate
                    (
                        new YLocationEffect(), //effect to apply implementing IEffect
                        EasingFunctions.BackEaseOut, //easing to apply
                        1000, //value to reach
                        1200, //animation duration in milliseconds
                        1000 //delayed start in milliseconds
                    );

                    RefreshRackAllocationGrid(rackdata[0].OrderNumber);
                    OpenConsolidationPanels(1000);

                    _headerChangeColorAnimation = pnlHeader.Animate
                    (
                        new ColorShiftEffect(), //effect to apply implementing IEffect
                        EasingFunctions.BackEaseInOut, //easing to apply
                        Color.LightGreen.ToArgb(), //value to reach
                        2000, //animation duration in milliseconds
                        2000, //delayed start in milliseconds
                        true,
                        0
                    );

                    _formChangeColorAnimation = this.Animate
                    (
                        new ColorShiftEffect(), //effect to apply implementing IEffect
                        EasingFunctions.BackEaseInOut, //easing to apply
                        Color.LightGreen.ToArgb(), //value to reach
                        2000, //animation duration in milliseconds
                        2000, //delayed start in milliseconds
                        true,
                        0
                    );
                }
            }
        }

        private void RefreshRackAllocationGrid(string OrderNumber)
        {
            gcCompSetList.DataSource = null;
            _rackDataToConsolidate = RacksLogic.GetRackReportByOrderNumber(_chronosGlobal, _lclCellId, _lclOBCId, OrderNumber);
            gcCompSetList.DataSource = _rackDataToConsolidate;
            
            RacksAllocations rak = _rackDataToConsolidate.Find(r => r.Completed == 0);


            if (rak == null)
                ReportOrderAsCompleted(_lastRunNumber, _lastWorktag);
        }
        #endregion

        #region Rack Panel Management
        private void RestartRackOrTrack()
        {
            _headerChangeColorAnimation.CancellationToken.Cancel();
            _headerChangeColorAnimation.CancellationToken.Dispose();
            _formChangeColorAnimation.CancellationToken.Cancel();
            _formChangeColorAnimation.CancellationToken.Dispose();
            txtInput.Text = "";
            txtInput.Enabled = true;
            txtInput.Focus();
            txtInput.Select();
            CloseConsolidationPanels();
            pnlScanContainer.Visible = false;
            lblUnityLabel.Visible = true;
            _orderNumberToProcess = "";
            lblRackScanning.Text = "Buscando ordenes completadas";
            lblRackScanning.ForeColor = Color.DarkGreen;
            lblInstruction.ForeColor = Color.DarkGreen;
            pnlHeader.BackColor = Color.WhiteSmoke;
            this.BackColor = Color.White;
            
            _pnlGridHolderAnimation = pnlGridHolder.Animate
            (
                new YLocationEffect(), //effect to apply implementing IEffect
                EasingFunctions.BackEaseOut, //easing to apply
                44, //value to reach
                1200, //animation duration in milliseconds
                1000 //delayed start in milliseconds
            );

            RefreshRack();
            StartRackTimer();
        }

        private void FromRackOrTrack()
        {
            if (_lclRackPoP == "NoRack") // From Track (Linear Scanning)
            {
                pnlScanContainer.Visible = true;
                lblRackScanning.Visible = false;
                lblRackScanning.Text = "";
            }
            else if (_lclRackPoP == "PickFromRack") // From Rack (Bulk Scanning)
            {
                txtInput.Text = "";
                txtInput.Enabled = false;
                pnlScanContainer.Visible = false;
                lblRackScanning.Visible = true;
                lblRackScanning.Text = "Buscando ordenes completadas";
                InitRackScanningTimer();
                StartRackTimer();
                //RefreshRack();
            }
            else if (_lclRackPoP == "PlaceToRack") // Invalid Setting
            {
                ShowMessageToUser("Error: La estación no ha sido configurada correctamente para usar Racks.", true);
                txtInput.Enabled = false;
                return;
            }
        }

        private void InitRackScanningTimer()
        {
            //Initialize Error Timer
            _rackScanningTimer = new System.Windows.Forms.Timer()
            {
                Interval = 3000
            };
            _rackScanningTimer.Tick += _rackScanningTimer_Tick;
        }

        private void StartRackTimer()
        {
            if(_rackScanningTimer.Enabled == false)
            {
                _rackScanningTimer.Enabled = true;
                _rackScanningTimer.Start();
            }
        }

        private void StopRackTimer()
        {
            if (_rackScanningTimer.Enabled == true)
            {
                _rackScanningTimer.Stop();
                _rackScanningTimer.Enabled = false;
            }
        }

        private void _rackScanningTimer_Tick(object sender, EventArgs e)
        {
            string lblText = lblRackScanning.Text;

            if (lblText != "Buscando ordenes completadas...")
                lblRackScanning.Text = lblText + ".";
            else
                lblRackScanning.Text = "Buscando ordenes completadas";

            if (_rackScanningRefreshCtrl >= _rackScanningRefreshRate)
            {
                RefreshRack();
                _rackScanningRefreshCtrl = 0;
            }
            else
            {
                _rackScanningRefreshCtrl += 1;
            }
        }
        #endregion


        #region Move Consolidation Panels
        private void OpenConsolidationPanels(int animationDelay)
        {
            if (_pnlStatus == "CLOSED")
            {
                _pnlScanContainerObjective = Screen.PrimaryScreen.Bounds.Top + 45;
                _pnlCompSetObjective = Screen.PrimaryScreen.Bounds.Height - 439;

                _pnlScanContainerAnimation = pnlScanContainer.Animate
                (
                    new YLocationEffect(), //effect to apply implementing IEffect
                    EasingFunctions.BackEaseIn, //easing to apply
                    45, //value to reach
                    800, //animation duration in milliseconds
                    animationDelay //delayed start in milliseconds
                );

                _pnlCompSetAnimation = pnlComponentSetProgress.Animate
                (
                    new YLocationEffect(), //effect to apply implementing IEffect
                    EasingFunctions.BackEaseIn, //easing to apply
                    _pnlCompSetObjective, //value to reach
                    800, //animation duration in milliseconds
                    animationDelay //delayed start in milliseconds
                );
                _pnlStatus = "OPENED";
                
            }
        }

        private void CloseConsolidationPanels()
        {
            if (_pnlStatus == "OPENED")
            {
                gcCompSetList.DataSource = null;
                _pnlScanContainerObjective = pnlScanContainer.Location.Y + 310;
                _pnlCompSetObjective = Screen.PrimaryScreen.Bounds.Height;

                _pnlScanContainerAnimation = pnlScanContainer.Animate
                (
                    new YLocationEffect(), //effect to apply implementing IEffect
                    EasingFunctions.BackEaseIn, //easing to apply
                    _pnlScanContainerObjective, //value to reach
                    800, //animation duration in milliseconds
                    0 //delayed start in milliseconds
                );

                _pnlCompSetAnimation = pnlComponentSetProgress.Animate
                (
                    new YLocationEffect(), //effect to apply implementing IEffect
                    EasingFunctions.BackEaseIn, //easing to apply
                    _pnlCompSetObjective, //value to reach
                    800, //animation duration in milliseconds
                    0 //delayed start in milliseconds
                );
                _pnlStatus = "CLOSED";
            }
        }
        #endregion

        #region Function Buttons
        private void BtnF7_Click(object sender, EventArgs e)
        {

        }

        private void BtnF8_Click(object sender, EventArgs e)
        {

        }

        private void BtnF9_Click(object sender, EventArgs e)
        {

        }

        private void BtnF10_Click(object sender, EventArgs e)
        {
            ExitForm();
        }
        #endregion

        #region Exit Form
        void ResetForm()
        {
        }

        void ExitForm()
        {
            try
            {
                _headerChangeColorAnimation.CancellationToken.Cancel();
                _formChangeColorAnimation.CancellationToken.Cancel();
                _pnlGridHolderAnimation.CancellationToken.Cancel();
                _pnlScanContainerAnimation.CancellationToken.Cancel();
                _pnlCompSetAnimation.CancellationToken.Cancel();
                ResetForm();
                _chronosGlobal.LogInLogOutUser(false);
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region Messages
        private void ShowMessageToUser(string Message, bool IsError)
        {
            if (IsError)
            {
                lblMessage.ForeColor = Color.Maroon;
                _errorTimer.Enabled = true;
                _errorTimer.Start();
                System.Media.SystemSounds.Hand.Play();
            }
            else
            {
                ChangeControlColor(Color.Green);
                lblMessage.ForeColor = Color.Green;
                System.Media.SystemSounds.Exclamation.Play();
            }

            lblMessage.Visible = true;
            lblMessage.Text = Message;
        }

        private void HideMessageFromUser()
        {
            lblMessage.Visible = false;
            lblMessage.Text = "";
        }
        #endregion

        #region Change Form Color
        private void InitErrorTimer()
        {
            _currentFormColor = BackColor;

            //Initialize Error Timer
            _errorTimer = new System.Windows.Forms.Timer()
            {
                Interval = 100
            };
            _errorTimer.Tick += _errorTimer_Tick;
        }

        /// <summary>
        /// Event Handler for error timer (Flashes Screen red)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _errorTimer_Tick(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Red)
                this.BackColor = _currentFormColor;
            else
                this.BackColor = Color.Red;

            if (_errorTicks == 5)
            {
                _errorTicks = 0;
                _errorTimer.Enabled = false;
                _errorTimer.Stop();
                this.BackColor = _currentFormColor;
            }
            else
            {
                _errorTicks += 1;
            }
        }

        /// <summary>
        /// Changes form color
        /// </summary>
        /// <param name="eventColor"></param>
        private void ChangeControlColor(Color eventColor)
        {
            uint intervals = 15;

            var colorFader = new ColorFader(eventColor, Color.White, intervals);

            SetControlBackColor(eventColor);

            /*  LinearFading Process isolated in a seperate Task to avoid blocking UI   */
            Task t = Task.Factory.StartNew(() =>
            {
                //System.Threading.Thread.Sleep(500);
                foreach (var color in colorFader.Fade())
                {
                    SetControlBackColor(color);
                    Thread.Sleep(50);
                }
            });
        }

        /// <summary>
        /// Helps ChangeControlColor to change the color
        /// </summary>
        /// <param name="color"></param>
        private void SetControlBackColor(Color color)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { this.BackColor = color; });
            else
                BackColor = color;
        }

        #endregion

    }
}
