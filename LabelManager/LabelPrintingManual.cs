using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Chronos.Data.DBAccess;
using Chronos.Data.DBAccess.BLogic;
using Chronos.Data.DBAccess.General;
using Chronos.Data.Shared;
using Chronos.Data.Shared.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Chronos.Data.Shared.Model.Enumerations;

namespace Chronos.Modules.LabelManager
{
    public partial class LabelPrintingManual : UserControl
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
        
        private int _instructionControl = 0;
        private string _runNumber;
        private string _worktag;
        private string _units;
        private int _runUnits;
        private bool _isReprint = false;
        private Guid _lastGuid;
        private bool _justReset = false;

        public LabelPrintingManual(IChronosGlobal chronosGlobal)
        {
            InitializeComponent();
            HideMessageFromUser();
            _chronosGlobal = chronosGlobal;
            //_chronosDBConnection = DBConnection.GetConnection(_chronosGlobal.ConnectToProd, _chronosGlobal.ServerName, _chronosGlobal.DatabaseName);
            LoadStationsSettings();
            ResetForm();
        }

        //private void GetInstructions()
        //{
        //    List<StationsDetails_Input> inst = new List<StationsDetails_Input>();
        //    _detailsConfig.AllowDownTime = false;
        //    _detailsConfig.AllowDefects = false;
        //    _detailsTracking.TrackLabelPrint = false;
        //    _detailsTracking.TrackLabelReprint = false;
        //    _detailsLabels.PrintLabel = false;
        //    _detailsLabels.AllowReprint = false;
        //    _detailsLabels.PrinterName = "";
        //    _detailsLabels.NumberOfCopies = 1;
        //    foreach (StationsConfig config in _configuration)
        //    {
        //        if (config.Category == "Config")
        //        {
        //            if (config.ConfigKey == "AllowDownTime")
        //                _detailsConfig.AllowDownTime = config.ConfigValue == "1" ? true : false;

        //            if (config.ConfigKey == "AllowDefects")
        //                _detailsConfig.AllowDefects = config.ConfigValue == "1" ? true : false;

        //        }
        //        else if (config.Category == "Tracking")
        //        {
        //            if (config.ConfigKey == "TrackLabelPrint")
        //                _detailsTracking.TrackLabelPrint = config.ConfigValue == "1" ? true : false;

        //            if (config.ConfigKey == "TrackLabelReprint")
        //                _detailsTracking.TrackLabelReprint = config.ConfigValue == "1" ? true : false;

        //            if (config.ConfigKey == "AutoOutput")
        //                _detailsTracking.AutoOutput = config.ConfigValue == "1" ? true : false;

        //        }
        //        else if (config.Category == "Labels")
        //        {
        //            if (config.ConfigKey == "PrintLabel")
        //                _detailsLabels.PrintLabel = config.ConfigValue == "1" ? true : false;

        //            if (config.ConfigKey == "TemplateName")
        //                _detailsLabels.TemplateName = config.ConfigValue;

        //            if (config.ConfigKey == "AllowReprint")
        //                _detailsLabels.AllowReprint = config.ConfigValue == "1" ? true : false;

        //            if (config.ConfigKey == "PrinterName")
        //                _detailsLabels.PrinterName = config.ConfigValue;

        //            if (config.ConfigKey == "NumberOfCopies")
        //                _detailsLabels.NumberOfCopies = int.Parse(config.ConfigValue);

        //            if (config.ConfigKey == "PrintingScreen")
        //                _detailsLabels.PrintingScreen = config.ConfigValue;

        //            if (config.ConfigKey == "LabelType")
        //                _detailsLabels.LabelType = config.ConfigValue;

        //        }
        //        else if (config.Category == "Input")
        //        {
        //            StationsDetails_Input SInst = new StationsDetails_Input();
        //            DataTable Instructions = StationsData.GetStationInstructions(_chronosGlobal, config.ConfigValue);
        //            SInst.DisplayOrder = int.Parse(config.ConfigKey);
        //            SInst.InputName = config.ConfigValue;

        //            foreach (DataRow row in Instructions.Rows)
        //            {
        //                SInst.Instruction_en = row["Instruction_en"].ToString();
        //                SInst.Instruction_es = row["Instruction_es"].ToString();
        //                SInst.OKMessage_en = row["OKMessage_en"].ToString();
        //                SInst.OKMessage_es = row["OKMessage_es"].ToString();
        //                SInst.ErrorMessage_en = row["ErrorMessage_en"].ToString();
        //                SInst.ErrorMessage_es = row["ErrorMessage_es"].ToString();
        //            }
        //            inst.Add(SInst);
        //        }

        //    }
        //    _instructions = inst.OrderBy(x => x.DisplayOrder).ToList();
        //    //ShowInstructionToUser(false);
        //    _chronosGlobal.StationConfiguration.PrinterName = _detailsConfig;
        //    _chronosGlobal.StationConfiguration.DetailsLabels = _detailsLabels;
        //    _chronosGlobal.StationConfiguration.DetailsTracking = _detailsTracking;
        //    _chronosGlobal.StationConfiguration.Instructions = _instructions;


        //    _trackPrint = _chronosGlobal.StationConfiguration.DetailsTracking.TrackLabelPrint;
        //    _trackReprint = _chronosGlobal.StationConfiguration.DetailsTracking.TrackLabelReprint;
        //    _printerName = _chronosGlobal.StationConfiguration.DetailsLabels.PrinterName;
        //    _numberOfCopies = short.Parse(_chronosGlobal.StationConfiguration.DetailsLabels.NumberOfCopies.ToString());
        //    txtRun.Focus();
        //}

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
        #endregion

        #region Controls
        private void TxtRun_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !_justReset)
            {
                if (txtRun.Text.Length > 0)
                {
                    lblRun.Text = txtRun.Text.Trim();
                    _runNumber = txtRun.Text.Trim();
                    pnlRun.Visible = false;
                    pnlWorktag.Visible = true;
                    btnPrint.Enabled = true;
                    btnPrint.Visible = true;
                    btnF8.Enabled = false;
                    txtRun.Clear();
                    HideMessageFromUser();
                    txtWorktag.Select();
                }
                else
                {
                    ShowMessageToUser("Favor de ingresar el número de corrida", true);
                }
            }
            else if (e.KeyCode == Keys.F7) //Reprint
            {
                ShowReports();
            }
            else if (e.KeyCode == Keys.F8) //Reprint
            {
                SetPrintReprintScreen(!_isReprint);
            }
            else if (e.KeyCode == Keys.F9) //Change Run
            {
                ResetForm();
            }
            else if (e.KeyCode == Keys.F10) //Logoff
            {
                ExitForm();
            }
            _justReset = false;
        }

        private void TxtWorktag_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblMessage.Visible)
            {
                HideMessageFromUser();
            }

            if (e.KeyCode == Keys.Enter && !_justReset)
            {
                string inputText = txtWorktag.Text.Trim();
                string inputType = ChronosValidations.GetInputType(inputText, _chronosGlobal.FacilityId).ToString();
                if (inputType == UserInputs.LabelLevel1.ToString())
                {
                    _worktag = inputText;
                    if (_isReprint)
                    {
                        txtNumberOfLables.Select();
                    }
                    else
                    {
                        txtNumberOfLables.Select();
                    }
                }
                else
                {
                    ShowMessageToUser(_lclInputs[_instructionControl].Instructions.ErrorMessage_es, true);
                    txtWorktag.Select();
                }
            }
            else if (e.KeyCode == Keys.F7) //Reprint
            {
                ShowReports();
            }
            else if (e.KeyCode == Keys.F8) //Reprint
            {
                SetPrintReprintScreen(!_isReprint);
            }
            else if (e.KeyCode == Keys.F9) //Change Run
            {
                ResetForm();
            }
            else if (e.KeyCode == Keys.F10) //Logoff
            {
                ExitForm();
            }
            _justReset = false;
        }

        private void TxtNumberOfLables_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblMessage.Visible)
            {
                HideMessageFromUser();
            }

            if (e.KeyCode == Keys.Enter && !_justReset)
            {
                string units = txtNumberOfLables.Text.Trim();
                if (int.TryParse(units, out int i) && i > 0)
                {
                    _units = units;
                    InitPrinting();
                }
                else
                {
                    _units = "0";
                    ShowMessageToUser("Favor de ingresar la cantidad de unidades", true);
                    txtNumberOfLables.Select();
                }
            }
            else if (e.KeyCode == Keys.F7) //Reprint
            {
                ShowReports();
            }
            else if (e.KeyCode == Keys.F8) //Reprint
            {
                SetPrintReprintScreen(!_isReprint);
            }
            else if (e.KeyCode == Keys.F9) //Change Run
            {
                ResetForm();
            }
            else if (e.KeyCode == Keys.F10) //Logoff
            {
                ExitForm();
            }
            _justReset = false;
        }
        
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            InitPrinting();
        }
        
        private void BtnF7_Click(object sender, EventArgs e)
        {
            ShowReports();
        }

        private void BtnF8_Click(object sender, EventArgs e)
        {
            SetPrintReprintScreen(!_isReprint);
        }

        private void BtnF9_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void BtnF10_Click(object sender, EventArgs e)
        {
            ExitForm();
        }
        #endregion
        
        void ShowReports()
        {
            _chronosGlobal.SwitchScreens(ChronosScreens.TrackingReport, ChronosScreensActions.OnTop);
        }

        #region Printing
        void InitPrinting()
        {
            //_runNumber = lblRun.Text.Trim();
            //_worktag = txtWorktag.Text.Trim();
            //_units = txtNumberOfLables.Text.Trim();

            if (_worktag.Length <= 0)
            {
                ShowMessageToUser("Favor de ingresar un worktag", true);
                return;
            }

            if (!int.TryParse(_units, out int i))
            {
                ShowMessageToUser("Favor de ingresar la cantidad de unidades", true);
                return;
            }

            try
            {
                if (_isReprint)
                {
                    string sUnit = string.Format("{0:000}", i);
                    string BarCodeValue = _worktag + "." + sUnit;
                    TrackingLogs RecordData = TrackingLogsLogic.GetRecordData(_chronosGlobal, BarCodeValue);

                    if (RecordData == null)
                    {
                        ShowMessageToUser("Error: La unidad no exite en Chronos.", true);
                        return;
                    }
                    
                    DisableWhilePrinting();
                    PrintUnit(int.Parse(_units));
                    ResetUnit();
                }
                else
                {
                    int PrintedUnits = TrackingLogsLogic.GetPrintedLabels(_chronosGlobal, _runNumber, _worktag);

                    if (PrintedUnits == 0)
                    {
                        PrintLabel();
                    }
                    else
                    {

                        DialogResult dialogResult = MessageBox.Show("Esta orden ya tiene etiquetas impresas. ¿Deseas imprimir " + _units + " adicionales?", "Imprimir Adicionales", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            PrintLabel(PrintedUnits + 1);
                        }

                        return;

                        /*
                        if (PrintedUnits == int.Parse(_units))
                        {
                            DialogResult dialogResult = MessageBox.Show("Todas las etiquetas de esta orden han sido impresas. ¿Deseas reimprimirlas?", "Reimpresión", MessageBoxButtons.YesNo);

                            if (dialogResult == DialogResult.Yes)
                            {
                                _isReprint = true;
                                PrintLabel();
                            }

                            return;
                        }
                        else if (PrintedUnits < int.Parse(_units))
                        {
                            DialogResult dialogResult = MessageBox.Show("La cantidad de unidades requerida es mayor a las impresas. ¿Deseas imprimir las faltantes?", "Imprimir Faltantes", MessageBoxButtons.YesNo);

                            if (dialogResult == DialogResult.Yes)
                            {
                                _isReprint = false;
                                PrintLabel(PrintedUnits + 1);
                            }

                            return;
                        }
                        else if (PrintedUnits > int.Parse(_units))
                        {
                            DialogResult dialogResult = MessageBox.Show("Esta orden ya tiene etiquetas impresas, ¿Deseas reimprimir la unidad #" + _units + "?", "Reimpresión", MessageBoxButtons.YesNo);

                            if (dialogResult == DialogResult.Yes)
                            {
                                DisableWhilePrinting();
                                _isReprint = true;
                                PrintUnit(int.Parse(_units));
                                ResetWorkTag();
                            }

                            return;
                        }*/
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Inesperado: " + ex.Message);
            }
        }

        void PrintLabel(int StartUnit = 1)
        {
            DisableWhilePrinting();
            int units = int.Parse(_units);
            if (StartUnit > 1)
            {
                units = int.Parse(_units) + StartUnit - 1;
            }
            int j = 0;
            for (int i = StartUnit; i <= units; i++)
            {
                PrintUnit(i);
                j++;
            }
            lblLastWorktag.Text = "Pzas/Worktag: " + _worktag + "(" + _units + ")";
            if (!_isReprint)
            {
                _runUnits = _runUnits + j;
            }
            lblLastRun.Text = "Pzas/Corrida: " + _runNumber + "(" + _runUnits + ")";
            ResetWorkTag();
        }

        private void PrintUnit(int i)
        {
            //if(_detailsLabels.TemplateName == "LabelTemplate_SimpleBarCode128")
            //{
            //    PrintLabel_SimpleBarCode128(i);
            //}
            //else
            //{
            //    MessageBox.Show("Error en la configuración, falta el parámetro: 'TemplateName' ");
            //    return;
            //}
            PrintLabel_SimpleBarCode128(i);
        }
        
        void PrintLabel_SimpleBarCode128(int i)
        {
            string sUnit = string.Format("{0:000}", i);
            string sData = _worktag;
            string sBarcodeValue = _worktag + "." + sUnit;

            /*
            SimpleBarCode128_Data productLabel = new SimpleBarCode128_Data
            {
                BarCodeValue = _worktag + "." + sUnit
            };

            List<SimpleBarCode128_Data> lpt2 = new List<SimpleBarCode128_Data>
                {
                    productLabel
                };

            LabelTemplates.LabelTemplate_SimpleBarCode128 lbl = new LabelTemplates.LabelTemplate_SimpleBarCode128();
            lbl.LoadData(lpt2);
            */

            Template_SimpleBarCode128_Data TemplateSimpleBarCode128 = new Template_SimpleBarCode128_Data
            {
                BarCodeValue = sBarcodeValue
            };
            ReportPrintTool printTool = new ReportPrintTool(Manager.PrintLabel.SimpleBarCode128(TemplateSimpleBarCode128));
            printTool.PrintingSystem.StartPrint += PrintingSystem_StartPrint;

            if (!_isReprint)
            {
                if (_lclTrackPrint)
                {
                    Tuple<bool, Guid> Result = TrackingLogsLogic.AddTrackRecordInput(_chronosGlobal,
                                                            _runNumber,
                                                            _worktag,
                                                            sBarcodeValue,
                                                            _chronosGlobal.StationConfiguration.OperationByCellId,
                                                            _chronosGlobal.MainUser.SubProcessName,
                                                            _chronosGlobal.StationConfiguration.StationId,
                                                            0,
                                                            _chronosGlobal.MainUser.EmployeeBadge);

                    if (Result.Item1)
                    {
                        _lastGuid = Result.Item2;
                        TrackingLogsLogic.AddTrackRecordOutput(_chronosGlobal, _lastGuid, null, _chronosGlobal.StationConfiguration.StationId, _chronosGlobal.MainUser.EmployeeBadge, "P", 0);
                        
                        printTool.Print(_lclPrinterName);
                    }
                    else
                    {
                        MessageBox.Show("Error Inesperado: No es posible conectar con la base de datos, favor de reiniciar Chronos");
                    }
                }
            }
            else
            {
                printTool.Print(_lclPrinterName);
            }

            printTool.Dispose();
        }

        void PrintingSystem_StartPrint(object sender, PrintDocumentEventArgs e)
        {
            e.PrintDocument.PrinterSettings.Copies = short.Parse(_lclNumberOfCopies.ToString());
        }
        #endregion


        #region Reset
        void ResetUnit()
        {
            _justReset = true;
            HideMessageFromUser();
            EnableForm();
            //_isReprint = false;
            //_worktag = "";
            _units = "0";
            txtNumberOfLables.Clear();
            //txtWorktag.Clear();
            txtNumberOfLables.Focus();
        }

        void ResetWorkTag()
        {
            _justReset = true;
            HideMessageFromUser();
            EnableForm();
            //_isReprint = false;
            _worktag = "";
            _units = "0";
            txtNumberOfLables.Clear();
            txtWorktag.Clear();
            txtWorktag.Focus();
        }

        void DisableWhilePrinting()
        {
            btnPrint.Enabled = false;
            txtWorktag.Enabled = false;
            txtNumberOfLables.Enabled = false;
        }

        void EnableForm()
        {
            HideMessageFromUser();
            btnPrint.Enabled = true;
            txtWorktag.Enabled = true;
            txtNumberOfLables.Enabled = true;
        }
        
        void ResetForm()
        {
            SetPrintReprintScreen(false);
        }

        void ResetFormNoReprint()
        {
            _justReset = true;
            HideMessageFromUser();
            //_isReprint = false;
            _worktag = "";
            _units = "0";
            _runNumber = "";
            _runUnits = 0;
            txtNumberOfLables.Clear();
            txtWorktag.Clear();
            txtRun.Clear();
            lblRun.Text = "----";
            pnlWorktag.Visible = false;
            pnlRun.Visible = true;
            btnPrint.Enabled = false;
            btnPrint.Visible = false;
            btnF8.Enabled = true;
            txtRun.Select();
        }

        void ExitForm()
        {
            ResetForm();
            _chronosGlobal.LogInLogOutUser(false);
        }
        #endregion


        void SetPrintReprintScreen(bool IsReprint)
        {
            if (IsReprint)
            {
                if (_runNumber == "")
                {
                    _isReprint = IsReprint;
                    pnlHeader.BackColor = Color.Gold;
                    tlpFooter.BackColor = Color.Gold;
                    lblRun.Text = "";
                    lblRunText.Text = "Reimpresión de Etiquetas";
                    btnF8.Text = "F8: Regresar";
                    pnlRun.Visible = false;
                    pnlWorktag.Visible = true;
                    txtWorktag.Select();
                        //lblRunText.ForeColor = Color.White;
                        //lblUnityLabel.ForeColor = Color.White;
                }
                else
                {
                    MessageBox.Show("Para reimprimir etiquetas es necesario salir de la corrida actual");
                }
            }
            else
            {
                _isReprint = IsReprint;
                pnlHeader.BackColor = Color.WhiteSmoke;
                tlpFooter.BackColor = Color.WhiteSmoke;
                lblRun.Text = "---";
                lblRunText.Text = "Corrida";
                btnF8.Text = "F8: Reimprimir";
                pnlRun.Visible = true;
                pnlWorktag.Visible = false;
                ResetFormNoReprint();
                //lblRunText.ForeColor = Color.MidnightBlue;
                //lblUnityLabel.ForeColor = Color.Black;
            }
        }
        
        private void ShowMessageToUser(string Message, bool IsError)
        {
            if (IsError)
            {
                lblMessage.ForeColor = Color.Maroon;
            }
            else
            {
                lblMessage.ForeColor = Color.Green;
            }

            lblMessage.Visible = true;
            lblMessage.Text = Message;
        }

        private void HideMessageFromUser()
        {
            lblMessage.Visible = false;
            lblMessage.Text = "";
        }

        private void LabelPrintingManual_Load(object sender, EventArgs e)
        {
            txtRun.Select();
        }
    }
}
