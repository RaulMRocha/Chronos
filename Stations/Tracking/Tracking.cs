using Chronos.Data.DBAccess.BLogic;
using Chronos.Data.Shared;
using Chronos.Data.Shared.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Chronos.Data.Shared.Model.Enumerations;

namespace Chronos.Modules.Tracking
{
    public partial class Tracking : UserControl
    {
        //SqlConnection _chronosDBConnection;
        private IChronosGlobal _chronosGlobal;

        #region Local Configurations
        private int _lclFacilityId = 0;
        private int _lclCellId = 0;
        private int _lclOBCId = 0;
        private int _lclStationId = 0;
        private string _lclEmpBadge;

        private List<OBCConfigDetails_Input> _lclInputs;
        private List<Flows> _lclStationFlow;

        private bool _lclValidateFlow = false;
        private bool _lclValidateLastOp = false;
        private bool _lclStartOfCell = false;
        private bool _lclEndOfCell = false;


        private bool _lclAllowDefects = false;
        private bool _lclAllowDownTime = false;

        private string _lclPrinterName;
        private bool _lclReLabel = false;
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

        private Guid _lastInsertedTrackId;
        private int _totalProcessed = 0;
        private string _lastLicensePlate = "";
        private string _lastWorktag = "";

        System.Windows.Forms.Timer errorTimer;
        private int _errorTicks = 0;
        private Color _currentFormColor;

        public Tracking(IChronosGlobal chronosGlobal)
        {
            InitializeComponent();
            InitErrorTimer();
            HideMessageFromUser();
            _chronosGlobal = chronosGlobal;
            LoadStationsSettings();
            UpdateProcessed();
            lblStation.Text = "Asociado de: " + _chronosGlobal.MainUser.SubProcessName;
            GetInstructions();
            ResetForm();
        }

        #region Settings Loading
        private void LoadStationsSettings()
        {
            _lclFacilityId = _chronosGlobal.FacilityId;
            _lclCellId = _chronosGlobal.CellsInformation.CellId;
            _lclOBCId = _chronosGlobal.OperationsByCellConfiguration.OBCId;
            _lclStationId = _chronosGlobal.StationConfiguration.StationId;
            _lclEmpBadge = _chronosGlobal.MainUser.EmployeeBadge;

            _lclInputs = new List<OBCConfigDetails_Input>();
            _lclInputs = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Inputs;

            _lclStationFlow = _chronosGlobal.FlowConfiguration;

            _lclValidateFlow = _chronosGlobal.StationConfiguration.ValidateFlow;
            _lclValidateLastOp = _chronosGlobal.StationConfiguration.ValidateLastOp;
            _lclPrinterName = _chronosGlobal.StationConfiguration.PrinterName.PrinterName;
            _lclStartOfCell = _chronosGlobal.OperationsByCellConfiguration.IsStartOfCell;
            _lclEndOfCell = _chronosGlobal.OperationsByCellConfiguration.IsEndOfCell;

            _lclAllowDefects = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Config.AllowDefects;
            _lclAllowDownTime = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Config.AllowDownTime;

            _lclAutoOutput = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Tracking.AutoOutput;
            _lclTrackPrint = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Tracking.TrackLabelPrint;
            _lclTrackReprint = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Tracking.TrackLabelReprint;
            _lclReportToERP = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Tracking.ReportToERP;

            _lclNumberOfCopies = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Labels.NumberOfCopies;
            _lclAllowReprint = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Labels.AllowReprint;
            _lclAskUser = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Labels.AskUser;
            _lclReLabel = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Labels.ReLabel;

            _lclRackPoP = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Racks.RackBehavior;
            _lclRacksIds = _chronosGlobal.OperationsByCellConfiguration.OBCConfig_Racks.RackId;
        }

        private void GetInstructions()
        {
            ShowInstructionsToUser();
            txtInput.Select();
        }

        private void ShowInstructionsToUser()
        {
            _instructionControl = 0;
            lblInstruction.Text = _lclInputs[_instructionControl].Instructions.Instruction_es;
            _expectedInput = _lclInputs[_instructionControl].Instructions.InputName;
        }

        public void ForceFocus()
        {
            txtInput.Select();
            txtInput.Focus();
        }

        #endregion

        #region Form Controls
        private void TxtInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblMessage.Visible)
                HideMessageFromUser();

            if (e.KeyCode == Keys.Enter)
            {
                string input = txtInput.Text;

                if (!string.IsNullOrWhiteSpace(input))
                    ValidateInput(input);
                else
                    ShowMessageToUser(_lclInputs[_instructionControl].Instructions.ErrorMessage_es, true);


                txtInput.Text = "";


                //string inputText = txtInput.Text.Trim();
                //string inputType = ChronosValidations.GetInputType(inputText, _lclFacilityId).ToString();
                //if (inputType == _lclInputs[_instructionControl].Instructions.InputName)
                //{
                //    //Close last opened unit if applies
                //    if (_lclAutoOutput)
                //        TrackingLogsLogic.AddTrackRecordOutputAuto(_chronosGlobal, _lclStationId, _lclEmpBadge, "P", 0);


                //    //Validate Operation Flow
                //    bool IsValidFlow = false;
                //    string InvalidFlowNextStation = "";

                //    if (_chronosGlobal.StationConfiguration.ValidateFlow)
                //    {
                //        IsValidFlow = true;
                //        InvalidFlowNextStation = "";
                //    }
                //    else
                //    {
                //        IsValidFlow = true;
                //    }


                //    if (!IsValidFlow)
                //    {
                //        ShowMessageToUser("Operación Inválida: Favor de enviar la unidad a: " + InvalidFlowNextStation, true);
                //        return;
                //    }


                //    //Get Record Data
                //    Guid LastRecordId = Guid.NewGuid();
                //    string RunNumber = "";
                //    string WorkTag = "";
                //    int LastStationId = 0;
                //    int LastOBCId = 0;

                //    TrackingLogs RecordData = TrackingLogsLogic.GetRecordData(_chronosGlobal, inputText);

                //    if (RecordData == null)
                //    {
                //        ShowMessageToUser("Operación Inválida: La unidad no exite en Chronos.", true);
                //        return;
                //    }

                //    LastRecordId = RecordData.TrackId;
                //    RunNumber = RecordData.RunNumber;
                //    WorkTag = RecordData.WorkTag;
                //    LastStationId = RecordData.StationId;
                //    LastOBCId = RecordData.OperationByCellId;

                //    if (LastOBCId == _chronosGlobal.StationConfiguration.OperationByCellId)//Last Operation is also this operation, close manually
                //    {
                //        TrackingLogsLogic.AddTrackRecordOutput(_chronosGlobal, LastRecordId, null, _lclStationId, _lclEmpBadge, "P", 0);
                //        ShowMessageToUser(_lclInputs[_instructionControl].Instructions.OKMessage_es, false);
                //    }
                //    else
                //    {
                //        Tuple<bool, Guid> Result = TrackingLogsLogic.AddTrackRecordInput(_chronosGlobal,
                //                                            RunNumber,
                //                                            WorkTag,
                //                                            inputText,
                //                                            _chronosGlobal.StationConfiguration.OperationByCellId,
                //                                            _chronosGlobal.MainUser.SubProcessName,
                //                                            _chronosGlobal.StationConfiguration.StationId,
                //                                            0,
                //                                            _chronosGlobal.MainUser.EmployeeBadge);

                //        if (Result.Item1)
                //        {
                //            ShowMessageToUser(_lclInputs[_instructionControl].Instructions.OKMessage_es, false);
                //            _totalProcessed++;
                //            _lastLicensePlate = inputText;
                //            UpdateProcessed();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Error Inesperado: Error al procesar la unidad en Chronos.");
                //        }
                //    }
                //}
                //else if (inputType == UserInputs.BadgeID.ToString())
                //{
                //    //Close last opened unit if applies
                //    if (_lclAutoOutput)
                //    {
                //        TrackingLogsLogic.AddTrackRecordOutputAuto(_chronosGlobal, _lclStationId, _lclEmpBadge, "P", 0);
                //    }
                //    ExitForm();
                //}
                //else
                //{
                //    ShowMessageToUser(_lclInputs[_instructionControl].Instructions.ErrorMessage_es, true);
                //}
                //txtInput.Text = "";
            }
            else if (e.KeyCode == Keys.F7) //Reprint
            {
                F7Press();
            }
            else if (e.KeyCode == Keys.F8) //Reprint
            {
                F8Press();
            }
            else if (e.KeyCode == Keys.F9) //Change Run
            {
                F9Press();
            }
            else if (e.KeyCode == Keys.F10) //Logoff
            {
                F10Press();
            }
        }
        #endregion
        
        #region Label Processing
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
            bool IsValidFlow = true;
            string FlowErrorMessage = "";
            string NextValidFlowOpName = "";
            bool IsValidResult = true;

            TrackingLogs LastRecord = TrackingLogsLogic.GetRecordData(_chronosGlobal, LicensePlate);
            if(LastRecord == null)
            {
                ShowMessageToUser("Error: Componente no encontrado, favor de revisar", true);
                return;
            }


            string OrderNumber = ChronosValidations.GetOrderNumberFromTrackingCode(LicensePlate);
            string WorkTag = ChronosValidations.GetWorkTagFromTrackingCode(LicensePlate);
            int LineNumber = int.Parse(ChronosValidations.GeLineNumberFromTrackingCode(LicensePlate));
            string RunNumber = LastRecord.RunNumber;


            _lastLicensePlate = LicensePlate;
            //Validate Model Flow
            FlowsLogic.IsModelFlowValid(_chronosGlobal, LabelType, LicensePlate, true, _lclStationFlow, out bool IsValidModel, out string ModelName);

            if (!IsValidModel)
            {
                ShowMessageToUser("Error: Esta estación no esta configurada para procesar el modelo " + ModelName, true);
                return;
            }
            
            //Validate Flow
            if (_lclValidateFlow)
                FlowsLogic.ValidateFlow(_chronosGlobal, LicensePlate, _lclOBCId, LastRecord.ComponentId, ModelName, _lclStationFlow, out IsValidFlow, out NextValidFlowOpName, out FlowErrorMessage);

            if (FlowErrorMessage != "")
            {
                ShowMessageToUser(FlowErrorMessage, true);
                return;
            }

            if (!IsValidFlow)
            {
                ShowMessageToUser("Error de flujo: favor de mandar la pieza a " + NextValidFlowOpName, true);
                return;
            }

            //Validate Last Op
            if (_lclValidateLastOp)
                TrackingLogsLogic.ValidateLastOperationResult(_chronosGlobal, LicensePlate, _lclOBCId, out IsValidResult);

            if (!IsValidResult)
            {
                ShowMessageToUser("Error de flujo: favor de mandar la pieza a Retrabajo/Reparación", true);
                return;
            }

            InsertTrackingLog(RunNumber, WorkTag, LicensePlate, LastRecord.ComponentId);
        }

        private void ProcessDefectCode(string DefectCode)
        {

        }

        private void ProcessDownTimeCode(string DownTimeCode)
        {

        }
        #endregion

        #region Data Processing
        private bool RackHandling(string WorkTag, string LicensePlate)
        {
            if (_lclRackPoP == "NoRack")
                return true;

            if (_lclRacksIds[0] == 0)
            {
                ShowMessageToUser("Error: La estación no ha sido configurada correctamente para usar Racks.", true);
                return false;
            }

            //Start Rack Processing
            Tuple<bool, string> AddRackResult = new Tuple<bool, string>(false, "");

            if (_lclRackPoP == "PlaceToRack")
                AddRackResult = RacksLogic.AssignComponentToRack(_chronosGlobal, _lclCellId, _lclStationId, _lclOBCId, WorkTag, LicensePlate);
            else if (_lclRackPoP == "PickFromRack")
            {

            }

            if (!AddRackResult.Item1)
            {
                ShowMessageToUser(AddRackResult.Item2, true);
                _lastWorktag = "";
                _instructionControl = 0;
            }


            return AddRackResult.Item1;
        }

        private void InsertTrackingLog(string RunNumber, string WorkTag, string LicensePlate, int ComponentId)
        {
            Tuple<bool, Guid> AddTrackResult = new Tuple<bool, Guid>(false, Guid.Empty);

            bool IsRrProcess = TrackingLogsLogic.IsPartAlreadyProcessed(_chronosGlobal, RunNumber, LicensePlate, _lclOBCId);

            if (IsRrProcess)
            {
                ShowMessageToUser("El componente '" + LicensePlate + "' ya pasó por esta operación", true);
                return;
            }
            else
                AddTrackResult = TrackingLogsLogic.AddTrackRecordInput(_chronosGlobal, RunNumber, WorkTag, LicensePlate, _lclOBCId, null, _lclStationId, ComponentId, _lclEmpBadge, false);
            
    
            if (AddTrackResult.Item1)
                _lastInsertedTrackId = AddTrackResult.Item2;


            _lastWorktag = WorkTag;

            //AutoOutput
            if (_lclAutoOutput)
                TrackingLogsLogic.AddTrackRecordOutputAuto(_chronosGlobal, _lclStationId, _lclEmpBadge, "P", ComponentId);


            ShowMessageToUser("Componente '" + LicensePlate + "' procesado exitoente", false);
        }

        void UpdateProcessed()
        {
            lblTotal.Text = "Total: " + _totalProcessed.ToString();
            lblLastScanned.Text = "Último: " + _lastLicensePlate;
        }
        #endregion

        #region Function Buttons
        private void BtnF7_Click(object sender, EventArgs e)
        {
            F7Press();
        }

        private void BtnF8_Click(object sender, EventArgs e)
        {
            F8Press();
        }

        private void BtnF9_Click(object sender, EventArgs e)
        {
            F9Press();
        }

        private void BtnF10_Click(object sender, EventArgs e)
        {
            F10Press();
        }

        void F7Press()
        {
            _chronosGlobal.SwitchScreens(ChronosScreens.TrackingReport, ChronosScreensActions.OnTop);
        }

        void F8Press()
        {

        }

        void F9Press()
        {
            _totalProcessed = 0;
            _lastLicensePlate = "";
            UpdateProcessed();
        }

        void F10Press()
        {
            ExitForm();
        }

        void ExitForm()
        {
            ResetForm();
            _chronosGlobal.LogInLogOutUser(false);
        }

        void ResetForm()
        {
            HideMessageFromUser();
            _totalProcessed = 0;
            _lastLicensePlate = "";
            UpdateProcessed();
        }
        #endregion


        #region Messages
        private void ShowMessageToUser(string Message, bool IsError)
        {
            if (IsError)
            {
                lblMessage.ForeColor = Color.Maroon;
                errorTimer.Enabled = true;
                errorTimer.Start();
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
            errorTimer = new System.Windows.Forms.Timer()
            {
                Interval = 100
            };
            errorTimer.Tick += _errorTimer_Tick;
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
                errorTimer.Enabled = false;
                errorTimer.Stop();
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

            var colorFader = new Data.Shared.Utils.ColorFader(eventColor, Color.White, intervals);

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
