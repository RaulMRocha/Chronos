using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Chronos.Data.DBAccess.BLogic;
using Chronos.Data.Shared;
using Chronos.Data.Shared.Model;
using Chronos.Data.Shared.Utils;
using Chronos.Modules.LabelManager.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Chronos.Data.Shared.Model.Enumerations;
using static Chronos.Data.Shared.Model.ERP;

namespace Chronos.Modules.LabelManager
{
    public partial class LabelPrintingAuto : UserControl
    {
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
        
        private int _chr_ttl_cmp = 0;
        private string _chr_lbl_cnt;
        private string _chr_rck_loc;
        private string _chr_cmp_dsc;

        private string _expectedInput;
        private int _instructionControl = 0;
        private bool _isComponentSetWindow = false;
        private int _componentSetsControl = 1;

        private Guid _lastInsertedTrackId;
        private int _currentComponentSetId = 0;
        private string _lastLicensePlate = "";
        private string _lastWorktag = "";
        private string _outputLicensePlate = "";
        private int _outputComponentId = 0;
        private int _totalProcessed = 0;

        private string _pnlStatus = "CLOSED";

        private int _pnlScanContainerObjective = 0;
        private int _pnlCompSetObjective = 0;

        System.Windows.Forms.Timer errorTimer;
        private int _errorTicks = 0;
        private Color _currentFormColor;


        public LabelPrintingAuto(IChronosGlobal chronosGlobal)
        {
            InitializeComponent();
            InitErrorTimer();

            //Continue
            HideMessageFromUser();
            _chronosGlobal = chronosGlobal;
            //_chronosDBConnection = DBConnection.GetConnection(_chronosGlobal.ConnectToProd, _chronosGlobal.ServerName, _chronosGlobal.DatabaseName);
            LoadStationsSettings();
            RearrangeWindow();
            GetInstructions();
            ResetForm();

            if(_chronosGlobal.CellsInformation.MainSetting.InfoSource != "FRN")
            {
                MessageBox.Show("This screen only works with FRN connection. Please contact your system administrator.", "Wrong Configuration");
                ExitForm();
            }
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
                string rawInput = txtInput.Text;
                string input = rawInput.TrimStart(new char[] { '0' });

                if (!string.IsNullOrWhiteSpace(input))
                    ValidateInput(input);
                else
                    ShowMessageToUser(_lclInputs[_instructionControl].Instructions.ErrorMessage_es, true);


                txtInput.Text = "";
            }
            else if (e.KeyCode == Keys.F9) //Complete Set
            {
                CompleteSet();
            }
            else if (e.KeyCode == Keys.F10) //Logoff
            {
                ExitForm();
            }
        }
        
        private void LabelPrintingAuto_Resize(object sender, EventArgs e)
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

            if (_isComponentSetWindow && _pnlStatus == "CLOSED")
                OpenPanels();
            
            string RunNumber = "";
            int UnitNumber = 1;
            int LabelsToPrint = 0;
            string OrderNumber = ChronosValidations.GetOrderNumberFromTrackingCode(LicensePlate);
            string WorkTag = ChronosValidations.GetWorkTagFromTrackingCode(LicensePlate);
            int LineNumber = int.Parse(ChronosValidations.GeLineNumberFromTrackingCode(LicensePlate));

            _lastLicensePlate = LicensePlate;

            //Validate Model Flow
            FlowsLogic.IsModelFlowValid(_chronosGlobal, LabelType, LicensePlate, true, _lclStationFlow, out bool IsValidModel, out string ModelName);

            if (!IsValidModel)
            {
                ShowMessageToUser("Error: La estación no esta configurada para procesar el modelo " + ModelName, true);
                return;
            }
            
            //Verify the new worktag is the e as the previous one
            if(LineNumber == 0)
            {
                if (!string.IsNullOrEmpty(_lastWorktag))
                    if (OrderNumber != ChronosValidations.GetOrderNumberFromTrackingCode(_lastWorktag))
                    {
                        ShowMessageToUser("Error: La etiqueta escaneada no corresponde a la orden en proceso.", true);
                        return;
                    }
            }
            else
            {
                if (!string.IsNullOrEmpty(_lastWorktag))
                    if (WorkTag != _lastWorktag)
                    {
                        string LastOrderNumber = ChronosValidations.GetOrderNumberFromTrackingCode(_lastWorktag);
                        int LastLineNumber = int.Parse(ChronosValidations.GeLineNumberFromTrackingCode(_lastWorktag));
                        if ((LastLineNumber == 0 && LastOrderNumber != OrderNumber) || (LastLineNumber > 0))
                        {
                            ShowMessageToUser("Error: La etiqueta escaneada no corresponde a la orden en proceso.", true);
                            return;
                        }
                    }
            }
            
            //Extract Data from FRN
            WorkOrderHeader WorkTagData = ERPLogic.GetMFGOrderNumberInfoByOrder(_chronosGlobal, WorkTag);
            List<SGP_WorkOrderSegments> WorkTagSegments = ERPLogic.GetBuildInstructions(_chronosGlobal, WorkTag);
            SGP_WorkOrderSegments FRNSegmentsInfo = new SGP_WorkOrderSegments();
            TrackingLogs LastRecord = TrackingLogsLogic.GetRecordData(_chronosGlobal, LicensePlate);

            if (LastRecord != null)
            {
                RunNumber = LastRecord.RunNumber;

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
            }

            //Start processing
            if (_lclReLabel)
            {
                LabelsToPrint = 0;
                int ComponentId = ComponentsLogic.GetComponentIdByLicensePlate(_chronosGlobal, LicensePlate);
                foreach (Flows flow in _lclStationFlow.Where(r => r.ModelSettingValue == ModelName && r.ComponentId == ComponentId))
                {
                    LabelsToPrint = 1;
                    _outputLicensePlate = LicensePlate;
                    _outputComponentId = flow.ComponentId;
                    _lastWorktag = ChronosValidations.GetWorkTagFromTrackingCode(_outputLicensePlate);
                    Components CompData = ComponentsLogic.GetComponentById(_chronosGlobal, flow.ComponentId);

                    CreateLabelToPrint(CompData, LabelsToPrint, RunNumber, OrderNumber, LineNumber, UnitNumber, WorkTag, WorkTagSegments, FRNSegmentsInfo);
                    _lastWorktag = "";
                    _outputLicensePlate = "";
                    _outputComponentId = 0;
                }
            }
            else
            {
                foreach (Flows flow in _lclStationFlow.Where(r => r.ModelSettingValue == ModelName))
                {
                    LabelsToPrint = 0;
                    Components CompData = ComponentsLogic.GetComponentById(_chronosGlobal, flow.ComponentId);

                    //Component Processing
                    if (_isComponentSetWindow)
                    {
                        if (flow.Prev_OBCId == 0)
                        {
                            _currentComponentSetId = flow.ComponentId;
                            _componentSetsControl = TrackingLogsLogic.GetComponentSetNumber(_chronosGlobal, WorkTag, LicensePlate, _lclOBCId, CompData.LabelCode);
                            LabelsToPrint = 1;

                            bool PrintLabel = false;
                            if (string.IsNullOrEmpty(RunNumber) && CompData.UsesFRN)
                                RunNumber = WorkTagData.M1RUN_RunNumber;

                            if (LineNumber == 0)
                            {
                                OrderNumber = ChronosValidations.GetOrderNumberFromTrackingCode(_outputLicensePlate);
                                WorkTag = ChronosValidations.GetWorkTagFromTrackingCode(_outputLicensePlate);
                                LineNumber = int.Parse(ChronosValidations.GeLineNumberFromTrackingCode(_outputLicensePlate));
                                UnitNumber = 1; 

                                 //_outputLicensePlate = BarCodes.CreateBarCodeForLabel(ChronosValidations.GetLabelType(CompData.LabelTypeCode),
                                 //                                                   OrderNumber, LineNumber, UnitNumber, CompData.LabelCode, 1);

                                _outputLicensePlate = BarCodes.CreateBarCodeForLabel(ChronosValidations.GetLabelType(CompData.LabelTypeCode),
                                                                                   OrderNumber, LineNumber, UnitNumber, CompData.LabelCode, _componentSetsControl);
                                _outputComponentId = CompData.ComponentId;

                                //Processing
                                InsertTrackingLog(RunNumber, ChronosValidations.GetWorkTagFromTrackingCode(LicensePlate), LicensePlate, LastRecord.ComponentId, _isComponentSetWindow, 
                                                                                    out PrintLabel);
                            }
                            else
                            {
                                //_outputLicensePlate = BarCodes.CreateBarCodeForLabel(ChronosValidations.GetLabelType(CompData.LabelTypeCode),
                                //                                                    OrderNumber, LineNumber, UnitNumber, CompData.LabelCode, 1);

                                _outputLicensePlate = BarCodes.CreateBarCodeForLabel(ChronosValidations.GetLabelType(CompData.LabelTypeCode),
                                                                                    OrderNumber, LineNumber, UnitNumber, CompData.LabelCode, _componentSetsControl);
                                _outputComponentId = CompData.ComponentId;

                                //Processing
                                InsertTrackingLog(RunNumber, WorkTag, LicensePlate, LastRecord.ComponentId, _isComponentSetWindow, out PrintLabel);
                            }

                            List<ComponentSetComponents> CompSet = ComponentsLogic.GetComponentSetComponents(_chronosGlobal, CompData.LabelQtyFRNSegment, WorkTag, 
                                                                                    _lclOBCId);
                            gcCompSetList.DataSource = CompSet;
                            //_chr_ttl_cmp = CompSet.Count();
                            _chr_ttl_cmp = CompSet.Where(r => r.Processed && r.OutputLicensePlate == _outputLicensePlate).Count();



                            //Verify all components are scanned
                            foreach (ComponentSetComponents comp in CompSet)
                                if (!comp.Processed)
                                {
                                    PrintLabel = false;
                                    break;
                                }

                            //Fill Chronos Segment
                            //if (string.IsNullOrEmpty(_chr_cmp_dsc))
                            //    _chr_cmp_dsc = ChronosValidations.GetComponentFromTrackingCode(LicensePlate);
                            //else
                            //    _chr_cmp_dsc = _chr_cmp_dsc + "," + ChronosValidations.GetComponentFromTrackingCode(LicensePlate);

                            //Print label
                            if (PrintLabel)
                            {
                                _chr_cmp_dsc = TrackingLogsLogic.GetComponentSetComponents(_chronosGlobal, _outputLicensePlate, _lclOBCId);
                                //Rack Handling
                                if (!RackHandling(WorkTag, _outputLicensePlate))
                                    return;

                                CreateLabelToPrint(CompData, LabelsToPrint, RunNumber, OrderNumber, 
                                                LineNumber, UnitNumber, ChronosValidations.GetWorkTagFromTrackingCode(_outputLicensePlate), WorkTagSegments, FRNSegmentsInfo);
                                TrackingLogsLogic.CompleteSetInProgress(_chronosGlobal, _outputLicensePlate, _lclOBCId);
                                WorkTag = "";
                                _lastWorktag = "";
                                _outputLicensePlate = "";
                                _outputComponentId = 0;
                                _lastLicensePlate = "";
                                _chr_cmp_dsc = "";
                                _componentSetsControl = 1;
                                ClosePanels();
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (CompData.UsesFRN)
                        {
                            RunNumber = WorkTagData.M1RUN_RunNumber;
                            SGP_WorkOrderSegments ToPrint = WorkTagSegments.Find(r => r.SegmentName == CompData.LabelQtyFRNSegment);
                            if (ToPrint != null)
                                LabelsToPrint = int.Parse(ToPrint.CfgCodeENU);
                        }
                        else
                        {
                            WorkTagSegments = null;
                            FRNSegmentsInfo = null;
                            LabelsToPrint = 1;
                        }
                        if (LabelsToPrint > 0)
                        {
                            //Handle One Per Order
                            if (CompData.OnePerOrder)
                            {
                                WorkTag = OrderNumber + ".000";
                                LineNumber = 0;
                                UnitNumber = 0;
                            }

                            _outputComponentId = CompData.ComponentId;

                            //Rack Handling
                            if (!RackHandling(WorkTag, LicensePlate))
                                return;

                            //Processing
                            CreateLabelToPrint(CompData, LabelsToPrint, RunNumber, OrderNumber, LineNumber, UnitNumber, WorkTag, WorkTagSegments, FRNSegmentsInfo);
                            
                            //WorkTag = "";
                            _lastWorktag = "";
                            _outputLicensePlate = "";
                            _outputComponentId = 0;
                        }
                    }
                }
            }

            UpdateProcessed();
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
                _outputLicensePlate = "";
                _outputComponentId = 0;
                _instructionControl = 0;
            }
            else
                _chr_rck_loc = AddRackResult.Item2;


            return AddRackResult.Item1;
        }
        
        private void InsertTrackingLog(string RunNumber, string WorkTag, string LicensePlate, int ComponentId, bool IsSet, out bool PrintLabel)
        {
            PrintLabel = true;
            Tuple<bool, Guid> AddTrackResult = new Tuple<bool, Guid>(false, Guid.Empty);

            bool IsReprint = TrackingLogsLogic.IsPartAlreadyProcessed(_chronosGlobal, RunNumber, LicensePlate, _lclOBCId);

            if (IsReprint)
            {
                if (!_lclAllowReprint)
                {
                    PrintLabel = false;
                    ShowMessageToUser("Reimpresión no permitida: Etiqueta #" + LicensePlate, true);
                }
                else
                {
                    ShowMessageToUser("La etiqueta solicitada es una reimpresión", true);
                    if (_lclTrackReprint)
                        AddTrackResult = TrackingLogsLogic.AddTrackRecordInput(_chronosGlobal, RunNumber, WorkTag, LicensePlate, _lclOBCId, null, _lclStationId, ComponentId, _lclEmpBadge, IsSet);
                }

            }
            else
            {
                if (_lclTrackPrint)
                    AddTrackResult = TrackingLogsLogic.AddTrackRecordInput(_chronosGlobal, RunNumber, WorkTag, LicensePlate, _lclOBCId, null, _lclStationId, ComponentId, _lclEmpBadge, IsSet);
            }

            if (AddTrackResult.Item1)
                _lastInsertedTrackId = AddTrackResult.Item2;


            _lastWorktag = WorkTag;

            //AutoOutput
            if (_lclAutoOutput)
                if (_isComponentSetWindow && !string.IsNullOrEmpty(_lastWorktag))
                    TrackingLogsLogic.AddTrackRecordOutput(_chronosGlobal, _lastInsertedTrackId, _outputLicensePlate, _lclStationId, _lclEmpBadge, "P", _outputComponentId);
                else
                    TrackingLogsLogic.AddTrackRecordOutputAuto(_chronosGlobal, _lclStationId, _lclEmpBadge, "P", _outputComponentId);
        }

        private void CompleteSet()
        {
            if (TrackingLogsLogic.GetComponentSetComponentsCount(_chronosGlobal,_outputLicensePlate, _lclOBCId) <= 0)
            {
                ShowMessageToUser("No hay componentes asignados al set " + _outputLicensePlate, true);
                txtInput.Select();
                return;
            }


            var confirmResult = MessageBox.Show("Estas seguro que deseas completar el Set?", "Completar Set", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                int LabelsToPrint = 1;

                //Extract Data from FRN
                WorkOrderHeader WorkTagData = ERPLogic.GetMFGOrderNumberInfoByOrder(_chronosGlobal, _lastWorktag);
                List<SGP_WorkOrderSegments> WorkTagSegments = ERPLogic.GetBuildInstructions(_chronosGlobal, _lastWorktag);
                SGP_WorkOrderSegments FRNSegmentsInfo = new SGP_WorkOrderSegments();
                TrackingLogs LastRecord = TrackingLogsLogic.GetRecordData(_chronosGlobal, _lastLicensePlate);

                Components CompData = ComponentsLogic.GetComponentById(_chronosGlobal, _currentComponentSetId);

                //int ComponentId = ComponentsLogic.GetComponentIdByLicensePlate(_chronosGlobal, _lastLicensePlate);
                //string OrderNumber = ChronosValidations.GetOrderNumberFromTrackingCode(_lastLicensePlate);
                //int LineNumber = int.Parse(ChronosValidations.GeLineNumberFromTrackingCode(_lastLicensePlate));

                int ComponentId = ComponentsLogic.GetComponentIdByLicensePlate(_chronosGlobal, _outputLicensePlate);
                string OrderNumber = ChronosValidations.GetOrderNumberFromTrackingCode(_outputLicensePlate);
                int LineNumber = int.Parse(ChronosValidations.GeLineNumberFromTrackingCode(_outputLicensePlate));
                string WorkTag = ChronosValidations.GetWorkTagFromTrackingCode(_outputLicensePlate);
                int UnitNumber = 1;

                //Rack Handling
                if (!RackHandling(WorkTag, _outputLicensePlate))
                    return;

                _chr_cmp_dsc = TrackingLogsLogic.GetComponentSetComponents(_chronosGlobal, _outputLicensePlate, _lclOBCId);
                CreateLabelToPrint(CompData, LabelsToPrint, LastRecord.RunNumber, OrderNumber, LineNumber,
                                    UnitNumber, ChronosValidations.GetWorkTagFromTrackingCode(_outputLicensePlate), WorkTagSegments, FRNSegmentsInfo);
                TrackingLogsLogic.CompleteSetInProgress(_chronosGlobal, _outputLicensePlate, _lclOBCId);
                ShowMessageToUser("Set Completado", false);
                //_componentSetsControl = _componentSetsControl + 1;
                _chr_cmp_dsc = "";
            }
            
            txtInput.Select();
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

        }

        private void BtnF8_Click(object sender, EventArgs e)
        {

        }

        private void BtnF9_Click(object sender, EventArgs e)
        {
            CompleteSet();
        }

        private void BtnF10_Click(object sender, EventArgs e)
        {
            ExitForm();
        }
        #endregion

        #region Label Creation
        private void CreateLabelToPrint(Components CompData, int LabelsToPrint, string RunNumber, string OrderNumber, int LineNumber, int UnitNumber, string WorkTag, List<SGP_WorkOrderSegments> WorkTagSegments, SGP_WorkOrderSegments FRNSegmentsInfo)
        {
            bool PrintLabel = true;
            string Slot1Value = "";
            string Slot2Value = "";
            string Slot3Value = "";
            string Slot4Value = "";
            string Slot5Value = "";
            string Slot6Value = "";
            string Slot7Value = "";
            string Slot8Value = "";
            
            if (_isComponentSetWindow)
                ConfigureAndPrintLabel(_componentSetsControl, CompData, RunNumber, OrderNumber, LineNumber, UnitNumber, WorkTag, WorkTagSegments, FRNSegmentsInfo, PrintLabel,
                                               Slot1Value, Slot2Value, Slot3Value, Slot4Value, Slot5Value, Slot6Value, Slot7Value, Slot8Value, LabelsToPrint);
            else
                for (int LabelNumber = 1; LabelNumber <= LabelsToPrint; LabelNumber++)
                {
                    PrintLabel = true;
                    ConfigureAndPrintLabel(LabelNumber, CompData, RunNumber, OrderNumber, LineNumber, UnitNumber, WorkTag, WorkTagSegments, FRNSegmentsInfo, PrintLabel,
                                               Slot1Value, Slot2Value, Slot3Value, Slot4Value, Slot5Value, Slot6Value, Slot7Value, Slot8Value, LabelsToPrint);
                }
        }

        private void ConfigureAndPrintLabel(int LabelNumber, Components CompData, string RunNumber, string OrderNumber, int LineNumber, 
                                            int UnitNumber, string WorkTag, List<SGP_WorkOrderSegments> WorkTagSegments, 
                                            SGP_WorkOrderSegments FRNSegmentsInfo, bool PrintLabel, string Slot1Value,
                                            string Slot2Value, string Slot3Value, string Slot4Value, string Slot5Value, string Slot6Value,
                                            string Slot7Value, string Slot8Value, int LabelsToPrint)
        {
            string BarCodeValue = "";
            BarCodeValue = BarCodes.CreateBarCodeForLabel(ChronosValidations.GetLabelType(CompData.LabelTypeCode), OrderNumber, LineNumber, UnitNumber, CompData.LabelCode, LabelNumber);

            if (CompData.LabelConfiguration != null)
            {
                foreach (ComponentsLabelsConfig cfg in CompData.LabelConfiguration)
                {
                    //Start: Fill Constant Values
                    switch (cfg.DataSlotNumber)
                    {
                        case 1:
                            Slot1Value = cfg.ConstantValue;
                            break;
                        case 2:
                            Slot2Value = cfg.ConstantValue;
                            break;
                        case 3:
                            Slot3Value = cfg.ConstantValue;
                            break;
                        case 4:
                            Slot4Value = cfg.ConstantValue;
                            break;
                        case 5:
                            Slot5Value = cfg.ConstantValue;
                            break;
                        case 6:
                            Slot6Value = cfg.ConstantValue;
                            break;
                        case 7:
                            Slot7Value = cfg.ConstantValue;
                            break;
                        case 8:
                            Slot8Value = cfg.ConstantValue;
                            break;
                        default:
                            break;
                    }
                    //End: Fill Constant Values

                    //START: Chronos Segments
                    if (!string.IsNullOrEmpty(cfg.VariableValue))
                    {
                        if (cfg.VariableValue.Substring(0, 3).ToUpper() == "CHR")
                        {
                            string SlotValue = "";
                            string chronosSegment = cfg.VariableValue.ToUpper();
                            _chr_lbl_cnt = LabelNumber.ToString() + " / " + LabelsToPrint.ToString();

                            switch (chronosSegment)
                            {
                                case "CHR.LBL.CNT": //Label Count
                                    SlotValue = _chr_lbl_cnt;
                                    break;
                                case "CHR.TTL.CMP": //Total Components
                                    SlotValue = _chr_ttl_cmp.ToString();
                                    break;
                                case "CHR.RCK.LOC": //Rack Allocation
                                    SlotValue = _chr_rck_loc;
                                    break;
                                case "CHR.CMP.DSC": //Components desc
                                    SlotValue = _chr_cmp_dsc;
                                    break;
                                default:
                                    break;
                            }

                            if (chronosSegment.Substring(0, 7) == "CHR.FRN") //Se usa para llamar FRN segments desde los sets
                            {
                                string FRNSegment = chronosSegment.Substring(8, chronosSegment.Length - 8);
                                if (WorkTagSegments != null)
                                {
                                    FRNSegmentsInfo = WorkTagSegments.Find(r => r.SegmentName == FRNSegment);
                                    SlotValue = FRNSegmentsInfo != null ? SlotValue + FRNSegmentsInfo.CfgCodeENU : SlotValue;
                                }
                            }

                            switch (cfg.DataSlotNumber)
                            {
                                case 1:
                                    Slot1Value = !string.IsNullOrEmpty(SlotValue) ? Slot1Value + SlotValue : Slot1Value;
                                    break;
                                case 2:
                                    Slot2Value = !string.IsNullOrEmpty(SlotValue) ? Slot2Value + SlotValue : Slot2Value;
                                    break;
                                case 3:
                                    Slot3Value = !string.IsNullOrEmpty(SlotValue) ? Slot3Value + SlotValue : Slot3Value;
                                    break;
                                case 4:
                                    Slot4Value = !string.IsNullOrEmpty(SlotValue) ? Slot4Value + SlotValue : Slot4Value;
                                    break;
                                case 5:
                                    Slot5Value = !string.IsNullOrEmpty(SlotValue) ? Slot5Value + SlotValue : Slot5Value;
                                    break;
                                case 6:
                                    Slot6Value = !string.IsNullOrEmpty(SlotValue) ? Slot6Value + SlotValue : Slot6Value;
                                    break;
                                case 7:
                                    Slot7Value = !string.IsNullOrEmpty(SlotValue) ? Slot7Value + SlotValue : Slot7Value;
                                    break;
                                case 8:
                                    Slot8Value = !string.IsNullOrEmpty(SlotValue) ? Slot8Value + SlotValue : Slot8Value;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    //END: Chronos Segments

                    //START: FRN Segments
                    if (CompData.UsesFRN)
                    {
                        switch (cfg.DataSlotNumber)
                        {
                            case 1:
                                FRNSegmentsInfo = WorkTagSegments.Find(r => r.SegmentName == cfg.VariableValue);
                                Slot1Value = FRNSegmentsInfo != null ? Slot1Value + FRNSegmentsInfo.CfgCodeENU : Slot1Value;
                                break;
                            case 2:
                                FRNSegmentsInfo = WorkTagSegments.Find(r => r.SegmentName == cfg.VariableValue);
                                Slot2Value = FRNSegmentsInfo != null ? Slot2Value + FRNSegmentsInfo.CfgCodeENU : Slot2Value;
                                break;
                            case 3:
                                FRNSegmentsInfo = WorkTagSegments.Find(r => r.SegmentName == cfg.VariableValue);
                                Slot3Value = FRNSegmentsInfo != null ? Slot3Value + FRNSegmentsInfo.CfgCodeENU : Slot3Value;
                                break;
                            case 4:
                                FRNSegmentsInfo = WorkTagSegments.Find(r => r.SegmentName == cfg.VariableValue);
                                Slot4Value = FRNSegmentsInfo != null ? Slot4Value + FRNSegmentsInfo.CfgCodeENU : Slot4Value;
                                break;
                            case 5:
                                FRNSegmentsInfo = WorkTagSegments.Find(r => r.SegmentName == cfg.VariableValue);
                                Slot5Value = FRNSegmentsInfo != null ? Slot5Value + FRNSegmentsInfo.CfgCodeENU : Slot5Value;
                                break;
                            case 6:
                                FRNSegmentsInfo = WorkTagSegments.Find(r => r.SegmentName == cfg.VariableValue);
                                Slot6Value = FRNSegmentsInfo != null ? Slot6Value + FRNSegmentsInfo.CfgCodeENU : Slot6Value;
                                break;
                            case 7:
                                FRNSegmentsInfo = WorkTagSegments.Find(r => r.SegmentName == cfg.VariableValue);
                                Slot7Value = FRNSegmentsInfo != null ? Slot7Value + FRNSegmentsInfo.CfgCodeENU : Slot7Value;
                                break;
                            case 8:
                                FRNSegmentsInfo = WorkTagSegments.Find(r => r.SegmentName == cfg.VariableValue);
                                Slot8Value = FRNSegmentsInfo != null ? Slot8Value + FRNSegmentsInfo.CfgCodeENU : Slot8Value;
                                break;
                            default:
                                break;
                        }
                    }
                    //END: FRN Segments
                }

                InsertTrackingLog(RunNumber, WorkTag, BarCodeValue, CompData.ComponentId, _isComponentSetWindow, out PrintLabel);

                if (PrintLabel)
                    PrintTemplate(CompData.LabelTemplateCode, BarCodeValue, Slot1Value, Slot2Value, Slot3Value, Slot4Value, Slot5Value, Slot6Value, Slot7Value, Slot8Value);
            }
            else
            {
                ShowMessageToUser("Error en la configuracion de la etiqueta ", true);
                return;
            }
        }
        #endregion
        
        #region Label Printing
        void PrintTemplate(string LabelTemplateCode, string BarcodeValue, string Slot1Value, string Slot2Value, string Slot3Value, string Slot4Value, string Slot5Value, string Slot6Value, string Slot7Value, string Slot8Value)
        {
            ReportPrintTool printTool;

            switch (LabelTemplateCode)
            {
                case "LabelTemplate_SimpleBarCode128":
                    Template_SimpleBarCode128_Data TemplateSimpleBarCode128 = new Template_SimpleBarCode128_Data
                    {
                        BarCodeValue = BarcodeValue
                    };
                    printTool = new ReportPrintTool(PrintLabel.SimpleBarCode128(TemplateSimpleBarCode128));
                    printTool.PrintingSystem.StartPrint += PrintingSystem_StartPrint;
                    printTool.Print(_lclPrinterName);
                    break;
                case "LabelTemplate_Component128":
                    Template_Component128_Data TemplateComponent128 = new Template_Component128_Data
                    {
                        BarCodeValue = BarcodeValue,
                        DataSlot1 = Slot1Value,
                        DataSlot2 = Slot2Value,
                        DataSlot3 = Slot3Value,
                        DataSlot4 = Slot4Value,
                        DataSlot5 = Slot5Value,
                        DataSlot6 = Slot6Value,
                        DataSlot7 = Slot7Value,
                        DataSlot8 = Slot8Value
                    };
                    printTool = new ReportPrintTool(PrintLabel.Component128(TemplateComponent128));
                    printTool.PrintingSystem.StartPrint += PrintingSystem_StartPrint;
                    printTool.Print(_lclPrinterName);
                    break;
                case "LabelTemplate_ComponentSet128":
                    Template_ComponentSet128_Data TemplateComponentSet128 = new Template_ComponentSet128_Data
                    {
                        BarCodeValue = BarcodeValue,
                        DataSlot1 = Slot1Value,
                        DataSlot2 = Slot2Value,
                        DataSlot3 = Slot3Value,
                        DataSlot4 = Slot4Value
                    };
                    printTool = new ReportPrintTool(PrintLabel.ComponentSet128(TemplateComponentSet128));
                    printTool.PrintingSystem.StartPrint += PrintingSystem_StartPrint;
                    printTool.Print(_lclPrinterName);
                    break;
                case "LabelTemplate_Box128":
                    Template_Box128_Data TemplateBox128 = new Template_Box128_Data
                    {
                        BarCodeValue = BarcodeValue,
                        DataSlot1 = Slot1Value,
                        DataSlot2 = Slot2Value,
                        DataSlot3 = Slot3Value,
                        DataSlot4 = Slot4Value
                    };
                    printTool = new ReportPrintTool(PrintLabel.Box128(TemplateBox128));
                    printTool.PrintingSystem.StartPrint += PrintingSystem_StartPrint;
                    printTool.Print(_lclPrinterName);
                    break;
                default:
                    break;
            }
        }

        void PrintingSystem_StartPrint(object sender, PrintDocumentEventArgs e)
        {
            e.PrintDocument.PrinterSettings.Copies = short.Parse(_lclNumberOfCopies.ToString());
        }
        #endregion

        #region Exit Form
        void ResetForm()
        {
            _pnlScanContainerObjective = 0;
            _pnlCompSetObjective = 0;
            _lastWorktag = "";
            _outputLicensePlate = "";
            _outputComponentId = 0;
            _instructionControl = 0;
            _chr_ttl_cmp = 0;
            _chr_lbl_cnt = "";
            _chr_rck_loc = "";
            _chr_cmp_dsc = "";
            ClosePanels();
            txtInput.Select();
        }

        void ExitForm()
        {
            if (_isComponentSetWindow && !string.IsNullOrEmpty(_lastWorktag))
                TrackingLogsLogic.DeleteSetsInProgress(_chronosGlobal, _lastWorktag, _lclOBCId, _lclStationId);

            if (_lclAutoOutput)
                if (_isComponentSetWindow && !string.IsNullOrEmpty(_lastWorktag))
                    TrackingLogsLogic.AddTrackRecordOutput(_chronosGlobal, _lastInsertedTrackId, _outputLicensePlate, _lclStationId, _lclEmpBadge, "P", _outputComponentId);
                else
                    TrackingLogsLogic.AddTrackRecordOutputAuto(_chronosGlobal, _lclStationId, _lclEmpBadge, "P", _outputComponentId);

            ResetForm();
            _chronosGlobal.LogInLogOutUser(false);
        }
        #endregion

        #region Move Panels

        private void RearrangeWindow()
        {
            var isCompoentSetWindow = _lclStationFlow.Find(r => r.LabelTypeCode == "LabelLevel4" || r.LabelTypeCode == "LabelLevel6");
            if (isCompoentSetWindow != null)
            {
                _isComponentSetWindow = true;
                btnF9.Enabled = true;
            }
            else
            {
                _isComponentSetWindow = false;
                btnF9.Enabled = false;
            }
        }

        private void OpenPanels()
        {
            if (_pnlStatus == "CLOSED")
            {
                _pnlScanContainerObjective = pnlScanContainer.Location.Y - 310;
                _pnlCompSetObjective = Size.Height - 310;
                pnlScanContainer.Location = new Point(pnlScanContainer.Location.X, _pnlScanContainerObjective);
                pnlComponentSetProgress.Location = new Point(pnlComponentSetProgress.Location.X, _pnlCompSetObjective);

                _pnlScanContainerObjective = Screen.PrimaryScreen.Bounds.Top + 45;
                _pnlCompSetObjective = Screen.PrimaryScreen.Bounds.Height - 439;

                // _pnlScanContainerAnimation = pnlScanContainer.Animate
                //(
                //    new YLocationEffect(), //effect to apply implementing IEffect
                //    EasingFunctions.BackEaseIn, //easing to apply
                //    _pnlScanContainerObjective, //value to reach
                //    800, //animation duration in milliseconds
                //    0 //delayed start in milliseconds
                //);

                //pnlComponentSetProgress.Animate
                //(
                //    new YLocationEffect(), //effect to apply implementing IEffect
                //    EasingFunctions.BackEaseIn, //easing to apply
                //    _pnlCompSetObjective, //value to reach
                //    800, //animation duration in milliseconds
                //    0 //delayed start in milliseconds
                //);

                _pnlStatus = "OPENED";
                //_locationTimer.Enabled = true;
                //_locationTimer.Start();
            }
        }

        private void ClosePanels()
        {
            if (_pnlStatus == "OPENED")
            {
                gcCompSetList.DataSource = null;
                _pnlScanContainerObjective = pnlScanContainer.Location.Y + 310;
                _pnlCompSetObjective = Size.Height;
                pnlScanContainer.Location = new Point(pnlScanContainer.Location.X, _pnlScanContainerObjective);
                pnlComponentSetProgress.Location = new Point(pnlComponentSetProgress.Location.X, _pnlCompSetObjective);
                //pnlScanContainer.Animate
                //(
                //    new YLocationEffect(), //effect to apply implementing IEffect
                //    EasingFunctions.BackEaseIn, //easing to apply
                //    _pnlScanContainerObjective, //value to reach
                //    800, //animation duration in milliseconds
                //    0 //delayed start in milliseconds
                //);

                //pnlComponentSetProgress.Animate
                //(
                //    new YLocationEffect(), //effect to apply implementing IEffect
                //    EasingFunctions.BackEaseIn, //easing to apply
                //    _pnlCompSetObjective, //value to reach
                //    800, //animation duration in milliseconds
                //    0 //delayed start in milliseconds
                //);
                _pnlStatus = "CLOSED";
                //_locationTimer.Enabled = true;
                //_locationTimer.Start();
            }
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
