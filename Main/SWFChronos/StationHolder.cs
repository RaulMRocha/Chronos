using Chronos.Data.DBAccess.BLogic;
using Chronos.Data.DBAccess.General;
using Chronos.Data.IkarusWS;
using Chronos.Data.Shared;
using Chronos.Data.Shared.Model;
using Chronos.Machinery.AndonLights;
using Chronos.Modules.Consolidation;
using Chronos.Modules.DownTime;
using Chronos.Modules.EmployeeValidation;
using Chronos.Modules.LabelManager;
using Chronos.Modules.StationReports;
using Chronos.Modules.Tracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Chronos.Data.Shared.Model.Enumerations;

namespace Chronos
{
    public partial class StationHolder : Form, IChronosGlobal
    {
        #region App Variables
        private string _windowsUserName = Environment.UserName;
        private string _pcName = Environment.MachineName;
        private string _versionNumber = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        private Guid _assemblyGUID = new Guid(Assembly.GetExecutingAssembly().GetCustomAttribute<GuidAttribute>().Value.ToUpper());

        private ChronosWS _chronosService;
        private bool _preconfigIsValid = false;
        private bool _stationConfigIsValid = false;
        private bool _stationIsActive = false;
        private bool _stationPrinterExists = true;
        private bool _cellIsConfigIsValid = false;
        private bool _cellIsActive = false;
        private bool _oBCIsConfigIsValid = false;
        private bool _oBCIsActive = false;
        private bool _flowsConfigIsValid = false;

        #endregion

        #region Screens
        private Tracking _trackingScreen;
        private OrderConsolidation _orderConsolidationScreen;
        private LineConsolidation _lineConsolidationScreen;
        private DownTime _downTimeScreen;
        private LabelPrintingAuto _printLabelsAutoScreen;
        private LabelPrintingManual _printLabelsManualScreen;
        private EmployeeValidation _employeeValidation;
        private TrackingHistoryReport _reportTrackingHistory;

        private string _PrintingScreenType;
        #endregion
        
        private AndonLights _andonControl;

        #region IChronosGlobal
        public SqlConnection ChronosDBConnection { get; set; }
        public ChronosScreens MainScreen { get; set; }
        public ChronosScreens CurrentScreen { get; set; }

        public Employees MainUser { get; set; }
        public ChronosStation StationConfiguration { get; set; }
        public OperationsByCell OperationsByCellConfiguration { get; set; }
        public Cells CellsInformation { get; set; }
        public List<Flows> FlowConfiguration { get; set; }

        public bool IsUserLogged { get; set; }

        public void LogInLogOutUser(bool UserLogged)
        {
            IsUserLogged = UserLogged;
            ClearStations();

            if (IsUserLogged)
            {
                pnlMainHolder.Visible = false;
                tslblUserLogged.Text = MainUser.EmployeeName;
                if (MainUser.IsCertified)
                {
                    tslblUserCertified.Text = "Certificado";
                }
                else
                {
                    tslblUserCertified.Text = "No Certificado";
                }
                SwitchScreens(MainScreen, ChronosScreensActions.Replace);
            }
            else
            {
                pnlMainHolder.Visible = true;
                if (_employeeValidation == null)
                    _employeeValidation = new EmployeeValidation(this, _preconfigIsValid)
                    {
                        Dock = DockStyle.Fill
                    };
                CurrentScreen = ChronosScreens.EmployeeValidation;
                pnlMainHolder.Controls.Add(_employeeValidation);
            }
        }

        public void SwitchScreens(ChronosScreens Screen, ChronosScreensActions Action, string Param1 = null, string param2 = null, string param3 = null)
        {
            switch (Screen)
            {
                case ChronosScreens.Tracking: ShowTrackingScreen(); break;
                case ChronosScreens.OrderConsolidation: ShowOrderConsolidationScreen(); break;
                case ChronosScreens.LineConsolidation: ShowLineConsolidationScreen(); break;
                case ChronosScreens.RackManagement: break;
                case ChronosScreens.DownTime: ShowDownTimeScreen(null); break;
                case ChronosScreens.PrintLabels:
                    ShowPrintLabelsScreen();
                    break;
                case ChronosScreens.TrackingReport: ShowTrackinReport(); break;
                default: break;
            }
        }
        
        public bool ConnectToProd { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string AppVersionName { get; set; }
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string[] Roles { get; set; }
        
        public string CustomBarStatus1 {
            get { return tslblStatus1.Text; }
            set { tslblStatus1.Text = value; }
        }
        public string CustomBarStatus2 {
            get { return tslblStatus2.Text; }
            set { tslblStatus2.Text = value; }
        }
        #endregion
        
        public StationHolder()
        {
            InitializeComponent();
            try
            {
                AppVersionName = "Chronos Shopfloor Application" + " - v" + _versionNumber.Substring(0, _versionNumber.LastIndexOf('.'));
                tslblAppVersion.Text = AppVersionName;
                lblAppVersion.Text = AppVersionName;

                if (!ChronosValidations.IsNetworkAvailable())
                {
                    lblStartupError.Text = "No hay conexión de red. \r\nFavor de contactar a Sistemas";
                    return;
                }
                
                _chronosService = new ChronosWS(true);
                LoadConfigurations();

                if (!_preconfigIsValid)
                {
                    lblStartupError.Text = "Preonfiguración no encontrada para el usuario: '" + _windowsUserName + "'. \r\nFavor de contactar al coordinador de línea";
                    return;
                }


                if (ConnectToProd)
                    lblAppEnvironment.Text = "Production Environment - " + FacilityName;
                else
                    lblAppEnvironment.Text = "Test Environment - " + FacilityName;


                if (!_stationPrinterExists)
                {
                    lblStartupError.Text = "Impresora no encontrada: '" + StationConfiguration.PrinterName.PrinterName + "'. \r\nFavor de contactar a Sistemas";
                    return;
                }

                if (!_stationConfigIsValid)
                {
                    lblStartupError.Text = "La configuración de la estación no fue encontrada para el usuario: '" + _windowsUserName + "'. \r\nFavor de contactar al coordinador de línea";
                    return;
                }

                
                if (!_stationIsActive)
                {
                    lblStartupError.Text = "Estación desactivada para el usuario: '" + _windowsUserName + "'. \r\nFavor de contactar al coordinador de línea";
                    return;
                }

                if (!_cellIsConfigIsValid)
                {
                    lblStartupError.Text = "Celda no configurada. \r\nFavor de contactar al coordinador de línea";
                    return;
                }

                if (!_cellIsActive)
                {
                    lblStartupError.Text = "Celda desactivada. \r\nFavor de contactar al coordinador de línea";
                    return;
                }

                if (!_oBCIsConfigIsValid)
                {
                    lblStartupError.Text = "La configuración de la Operación de Celda no es válida. \r\nFavor de contactar al coordinador de línea";
                    return;
                }

                if (!_oBCIsActive)
                {
                    lblStartupError.Text = "Operación de Celda desactivada. \r\nFavor de contactar al coordinador de línea";
                    return;
                }

                if (!_flowsConfigIsValid)
                {
                    lblStartupError.Text = "La configuración de flujos es inválida. \r\nFavor de contactar al coordinador de línea";
                    return;
                }


                GetShifts();
                StationsLogic.UpdateStationData(this, _pcName, _versionNumber, _windowsUserName);
                LogInLogOutUser(false);
                StartDefaultMachinery();
            }
            catch (Exception ex)
            {
                lblStartupError.Text = "Error Desconocido: " + ex.Message + ". \r\nFavor de contactar a Sistemas";
            }
        }

        //private void GetConfiguration()
        //{
        //    //Station PreConfig
        //    DataTable preconfig = _chronosService.Chronos_GetStationPreConfig(_windowsUserName);
        //    if (preconfig.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in preconfig.Rows)
        //        {
        //            ConnectToProd = int.Parse(row["IsProd"].ToString()) == 1 ? true : false;
        //            FacilityId = int.Parse(row["FacilityId"].ToString());
        //            FacilityName = row["FacilityName"].ToString();
        //            DatabaseName = row["DatabaseName"].ToString();
        //            ServerName = row["ServerName"].ToString();
        //            Roles = row["Roles"].ToString().Split(',');
        //        }

        //        tslblFacility.Text = FacilityName;
        //        ChronosDBConnection = DBConnection.GetConnection(ConnectToProd, ServerName, DatabaseName);

        //        //Station Main Config
        //        DataTable config = StationsData.GetMainConfiguration(this, _windowsUserName, FacilityId);
        //        if (config.Rows.Count > 0)
        //        {
        //            ChronosStation lclStation = new ChronosStation();
        //            foreach (DataRow row in config.Rows)
        //            {
        //                lclStation.StationId = int.Parse(row["StationId"].ToString());
        //                lclStation.StationName_es = row["StationName_es"].ToString();
        //                lclStation.StationName_en = row["StationName_en"].ToString();
        //                lclStation.ADUserId = row["ADUserId"].ToString();
        //                lclStation.OperationByCellId = int.Parse(row["OperationByCellId"].ToString());
        //                lclStation.UnityFacilityId = int.Parse(row["UnityFacilityId"].ToString());
        //                lclStation.UnityCellId = int.Parse(row["UnityCellId"].ToString());
        //                lclStation.CellId = int.Parse(row["CellId"].ToString());
        //                lclStation.CellName = row["CellName"].ToString();
        //                lclStation.BUId = int.Parse(row["BUId"].ToString());
        //                lclStation.WorkCenter = row["WorkCenter"].ToString();
        //                lclStation.DepartmentNumber = int.Parse(row["DepartmentNumber"].ToString());
        //                lclStation.OperationId = int.Parse(row["OperationId"].ToString());
        //                lclStation.OperationName_es = row["OperationName_es"].ToString();
        //                lclStation.OperationName_en = row["OperationName_en"].ToString();
        //                lclStation.DisplayFullScreen = bool.Parse(row["DisplayFullScreen"].ToString());
        //                lclStation.ValidateFlow = bool.Parse(row["ValidateFlow"].ToString());
        //                lclStation.ValidateLastOp = bool.Parse(row["ValidateLastOperation"].ToString());
        //                lclStation.IsActive = bool.Parse(row["Active"].ToString());
        //            }

        //            lblStationName.Text = lclStation.StationName_es;
        //            tslblCellName.Text = lclStation.CellName + " - " + lclStation.OperationName_es;

        //            if (lclStation.IsActive)
        //            {
        //                //Cell Main Info
        //                DataTable cellMainInfo = CellsData.GetCellById(this, lclStation.CellId);

        //                if (cellMainInfo.Rows.Count > 0)
        //                {
        //                    Cells lclcells = new Cells();
        //                    foreach (DataRow row in cellMainInfo.Rows)
        //                    {
        //                        lclcells.CellId = int.Parse(row["Id"].ToString());
        //                        lclcells.CellName = row["CellName"].ToString();
        //                        lclcells.BUId = int.Parse(row["BUId"].ToString());
        //                        lclcells.DepartmentNumber = int.Parse(row["DepartmentNumber"].ToString());
        //                        lclcells.WorkCenter = row["WorkCenter"].ToString();
        //                        lclcells.UnityFacilityId = int.Parse(row["UnityFacilityId"].ToString());
        //                        lclcells.UnityCellId = int.Parse(row["UnityCellId"].ToString());
        //                        lclcells.FacilityNumber = int.Parse(row["FacilityNumber"].ToString());
        //                        lclcells.IsActive = bool.Parse(row["Active"].ToString());
        //                    }


        //                    if (lclcells.IsActive)
        //                    {
        //                        //Cell Settings
        //                        DataTable cellSettings = CellsData.GetCellsSettingsByCellId(this, lclStation.CellId);

        //                        if (cellSettings.Rows.Count > 0)
        //                        {
        //                            List<CellsSettings> lclCellSettings = new List<CellsSettings>();
        //                            foreach (DataRow row in cellSettings.Rows)
        //                            {
        //                                CellsSettings cs = new CellsSettings
        //                                {
        //                                    SettingId = int.Parse(row["SettingId"].ToString()),
        //                                    CellId = int.Parse(row["CellId"].ToString()),
        //                                    Category = row["Category"].ToString(),
        //                                    SettingKey = row["SettingKey"].ToString(),
        //                                    SettingValue = row["SettingValue"].ToString(),
        //                                    Comments = row["Comments"].ToString()
        //                                };
        //                                lclCellSettings.Add(cs);
        //                            }

        //                            CellSettings_Main mainSet = new CellSettings_Main();

        //                            foreach (CellsSettings cSets in lclCellSettings)
        //                            {
        //                                if (cSets.Category == "Main")
        //                                {
        //                                    if (cSets.SettingKey == "InfoSource")
        //                                        mainSet.InfoSoruce = cSets.SettingValue;
        //                                }
        //                            }

        //                            lclcells.MainSetting = mainSet;
        //                            CellsInformation = lclcells;

        //                            //Secondary Station Config
        //                            DataTable secConfig = StationsData.GetSecondaryConfiguration(this, lclStation.StationId);

        //                            if (secConfig.Rows.Count > 0)
        //                            {
        //                                List<StationsConfig> lclStationConfig = new List<StationsConfig>();
        //                                foreach (DataRow row in secConfig.Rows)
        //                                {
        //                                    StationsConfig stConfig = new StationsConfig
        //                                    {
        //                                        ConfigId = int.Parse(row["Id"].ToString()),
        //                                        StationId = int.Parse(row["StationId"].ToString()),
        //                                        Category = row["Category"].ToString(),
        //                                        ConfigKey = row["ConfigKey"].ToString(),
        //                                        ConfigValue = row["ConfigValue"].ToString()
        //                                    };

        //                                    /*Start: Special Code*/
        //                                    if (string.IsNullOrEmpty(_PrintingScreenType))
        //                                    {
        //                                        if (stConfig.Category == "Labels" && stConfig.ConfigKey == "PrintingScreen" && stConfig.ConfigValue == "M")
        //                                        {
        //                                            _PrintingScreenType = "M";
        //                                        }
        //                                        else if (stConfig.Category == "Labels" && stConfig.ConfigKey == "PrintingScreen" && stConfig.ConfigValue == "A")
        //                                        {
        //                                            _PrintingScreenType = "A";
        //                                        }
        //                                    }
        //                                    /*End: Special Code*/

        //                                    lclStationConfig.Add(stConfig);
        //                                }

        //                                lclStation.Configuration = lclStationConfig;

        //                                List<StationsDetails_Input> inst = new List<StationsDetails_Input>();
        //                                StationsDetails_Config detailsConfig = new StationsDetails_Config();
        //                                StationsDetails_Tracking detailsTracking = new StationsDetails_Tracking();
        //                                StationsDetails_Labels detailsLabels = new StationsDetails_Labels();
        //                                List<Components> labelComponents = new List<Components>();

        //                                detailsConfig.AllowDownTime = false;
        //                                detailsConfig.AllowDefects = false;
        //                                detailsTracking.TrackLabelPrint = false;
        //                                detailsTracking.TrackLabelReprint = false;
        //                                detailsTracking.AutoOutput = false;
        //                                detailsLabels.PrintLabel = false;
        //                                detailsLabels.AllowReprint = false;
        //                                detailsLabels.PrinterName = "";
        //                                detailsLabels.NumberOfCopies = 1;

        //                                foreach (StationsConfig sconfig in lclStationConfig)
        //                                {
        //                                    if (sconfig.Category == "Config")
        //                                    {
        //                                        if (sconfig.ConfigKey == "AllowDownTime")
        //                                            detailsConfig.AllowDownTime = sconfig.ConfigValue == "1" ? true : false;

        //                                        if (sconfig.ConfigKey == "AllowDefects")
        //                                            detailsConfig.AllowDefects = sconfig.ConfigValue == "1" ? true : false;

        //                                    }
        //                                    else if (sconfig.Category == "Tracking")
        //                                    {
        //                                        if (sconfig.ConfigKey == "TrackLabelPrint")
        //                                            detailsTracking.TrackLabelPrint = sconfig.ConfigValue == "1" ? true : false;

        //                                        if (sconfig.ConfigKey == "TrackLabelReprint")
        //                                            detailsTracking.TrackLabelReprint = sconfig.ConfigValue == "1" ? true : false;

        //                                        if (sconfig.ConfigKey == "AutoOutput")
        //                                            detailsTracking.AutoOutput = sconfig.ConfigValue == "1" ? true : false;

        //                                    }
        //                                    else if (sconfig.Category == "Labels")
        //                                    {

        //                                        if (sconfig.ConfigKey == "AllowReprint")
        //                                            detailsLabels.AllowReprint = sconfig.ConfigValue == "1" ? true : false;

        //                                        if (sconfig.ConfigKey == "AskUser")
        //                                            detailsLabels.AskUser = sconfig.ConfigValue == "1" ? true : false;

        //                                        if (sconfig.ConfigKey == "LabelType")
        //                                            detailsLabels.LabelType = sconfig.ConfigValue;

        //                                        if (sconfig.ConfigKey == "NumberOfCopies")
        //                                            detailsLabels.NumberOfCopies = int.Parse(sconfig.ConfigValue);

        //                                        if (sconfig.ConfigKey == "PrinterName")
        //                                            detailsLabels.PrinterName = sconfig.ConfigValue;

        //                                        if (sconfig.ConfigKey == "PrintingScreen")
        //                                            detailsLabels.PrintingScreen = sconfig.ConfigValue;

        //                                        if (sconfig.ConfigKey == "PrintLabel")
        //                                            detailsLabels.PrintLabel = sconfig.ConfigValue == "1" ? true : false;

        //                                        if (sconfig.ConfigKey == "TemplateName")
        //                                            detailsLabels.TemplateName = sconfig.ConfigValue;

        //                                    }
        //                                    else if (sconfig.Category == "Input")
        //                                    {
        //                                        StationsDetails_Input SInst = new StationsDetails_Input();
        //                                        DataTable Instructions = StationsData.GetStationInstructions(this, sconfig.ConfigValue);
        //                                        SInst.DisplayOrder = int.Parse(sconfig.ConfigKey);
        //                                        SInst.InputName = sconfig.ConfigValue;

        //                                        foreach (DataRow row in Instructions.Rows)
        //                                        {
        //                                            SInst.Instruction_en = row["Instruction_en"].ToString();
        //                                            SInst.Instruction_es = row["Instruction_es"].ToString();
        //                                            SInst.OKMessage_en = row["OKMessage_en"].ToString();
        //                                            SInst.OKMessage_es = row["OKMessage_es"].ToString();
        //                                            SInst.ErrorMessage_en = row["ErrorMessage_en"].ToString();
        //                                            SInst.ErrorMessage_es = row["ErrorMessage_es"].ToString();
        //                                        }
        //                                        inst.Add(SInst);
        //                                    }
        //                                }

        //                                lclStation.PrinterName = detailsConfig;
        //                                lclStation.DetailsTracking = detailsTracking;
        //                                lclStation.DetailsLabels = detailsLabels;
        //                                lclStation.Instructions = inst.OrderBy(x => x.DisplayOrder).ToList();

        //                            }
        //                            StationConfiguration = lclStation;

        //                            //P = Print
        //                            //T = Track
        //                            //RW = Rework
        //                            //RI = Rack Input
        //                            //RO = Rack Output
        //                            //DT = Down Time
        //                            //C = Consolidate

        //                            if (Roles[0].ToString() == "P")
        //                            {
        //                                MainScreen = ChronosScreens.PrintLabels;
        //                            }
        //                            else if (Roles[0].ToString() == "T")
        //                            {
        //                                MainScreen = ChronosScreens.Tracking;
        //                            }
        //                            else if (Roles[0].ToString() == "RW")
        //                            {
        //                                MainScreen = ChronosScreens.Tracking;
        //                            }
        //                            else if (Roles[0].ToString() == "RI")
        //                            {
        //                                MainScreen = ChronosScreens.Tracking;
        //                            }
        //                            else if (Roles[0].ToString() == "RO")
        //                            {
        //                                MainScreen = ChronosScreens.Tracking;
        //                            }
        //                            else if (Roles[0].ToString() == "DT")
        //                            {
        //                                MainScreen = ChronosScreens.DownTime;
        //                            }
        //                            else if (Roles[0].ToString() == "C")
        //                            {
        //                                MainScreen = ChronosScreens.Tracking;
        //                            }
        //                            else
        //                            {
        //                                _stationRole = false;
        //                            }

        //                            if (!StationConfiguration.DisplayFullScreen)
        //                            {
        //                                FormBorderStyle = FormBorderStyle.FixedSingle;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            _cellIsConfigured = false;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        _cellIsActive = false;
        //                    }
        //                }
        //                else
        //                {
        //                    _cellIsConfigured = false;
        //                }



        //            }
        //            else
        //            {
        //                _stationIsActive = false;
        //            }

        //        }
        //        else
        //        {
        //            _configIsValid = false;
        //        }
        //    }
        //    else
        //    {
        //        _preconfigIsValid = false;
        //    }
        //}

        #region Load DataBase Configurations
        private void LoadConfigurations()
        {
            LoadUnityPreconfig();
            if (!_preconfigIsValid)
                return;
            
            LoadStationConfig();
            if (!_stationConfigIsValid)
                return;

            if (!_stationIsActive)
                return;
            
            LoadCellConfig();
            if (!_cellIsConfigIsValid)
                return;

            if (!_cellIsActive)
                return;
            
            LoadOBCConfig();
            if (!_oBCIsConfigIsValid)
                return;

            if (!_oBCIsActive)
                return;

            //if (StationConfiguration.ValidateFlow)
            //{
            //    LoadFlowsConfig();
            //    if (!_flowsConfigIsValid)
            //        return;
            //}
            //else
            //    _flowsConfigIsValid = true;

            LoadFlowsConfig();
            if (!_flowsConfigIsValid)
                return;

        }

        private void LoadUnityPreconfig()
        {
            DataTable preconfig = _chronosService.Chronos_GetStationPreConfig(_windowsUserName);
            if (preconfig.Rows.Count > 0)
            {
                foreach (DataRow row in preconfig.Rows)
                {
                    ConnectToProd = int.Parse(row["IsProd"].ToString()) == 1 ? true : false;
                    FacilityId = int.Parse(row["FacilityId"].ToString());
                    FacilityName = row["FacilityName"].ToString();
                    DatabaseName = row["DatabaseName"].ToString();
                    ServerName = row["ServerName"].ToString();
                    Roles = row["Roles"].ToString().Split(',');
                }

                tslblFacility.Text = FacilityName;
                ChronosDBConnection = DBConnection.GetConnection(ConnectToProd, ServerName, DatabaseName);

                _preconfigIsValid = true;
            }
        }

        private void LoadStationConfig()
        {
            DataTable config = StationsLogic.GetMainConfiguration(this, _windowsUserName, FacilityId);
            if (config.Rows.Count > 0)
            {
                ChronosStation lclStation = new ChronosStation();
                foreach (DataRow row in config.Rows)
                {
                    lclStation.StationId = int.Parse(row["StationId"].ToString());
                    lclStation.StationName_es = row["StationName_es"].ToString();
                    lclStation.StationName_en = row["StationName_en"].ToString();
                    lclStation.ADUserId = row["ADUserId"].ToString();
                    lclStation.OperationByCellId = int.Parse(row["OperationByCellId"].ToString());
                    lclStation.UnityFacilityId = int.Parse(row["UnityFacilityId"].ToString());
                    lclStation.UnityCellId = int.Parse(row["UnityCellId"].ToString());
                    lclStation.CellId = int.Parse(row["CellId"].ToString());
                    lclStation.CellName = row["CellName"].ToString();
                    lclStation.BUId = int.Parse(row["BUId"].ToString());
                    lclStation.WorkCenter = row["WorkCenter"].ToString();
                    lclStation.DepartmentNumber = int.Parse(row["DepartmentNumber"].ToString());
                    lclStation.OperationId = int.Parse(row["OperationId"].ToString());
                    lclStation.OperationName_es = row["OperationName_es"].ToString();
                    lclStation.OperationName_en = row["OperationName_en"].ToString();
                    lclStation.DisplayFullScreen = bool.Parse(row["DisplayFullScreen"].ToString());
                    lclStation.ValidateFlow = bool.Parse(row["ValidateFlow"].ToString());
                    lclStation.ValidateLastOp = bool.Parse(row["ValidateLastOperation"].ToString());
                    lclStation.IsActive = bool.Parse(row["Active"].ToString());
                }

                lblStationName.Text = lclStation.StationName_es;
                tslblCellName.Text = lclStation.CellName + " - " + lclStation.OperationName_es;
                _stationIsActive = lclStation.IsActive;

                //Secondary Station Config
                DataTable secConfig = StationsLogic.GetSecondaryConfiguration(this, lclStation.StationId);

                if (secConfig.Rows.Count > 0)
                {
                    List<StationsConfig> lclStationConfig = new List<StationsConfig>();
                    foreach (DataRow row in secConfig.Rows)
                    {
                        StationsConfig stConfig = new StationsConfig
                        {
                            ConfigId = int.Parse(row["Id"].ToString()),
                            StationId = int.Parse(row["StationId"].ToString()),
                            Category = row["Category"].ToString(),
                            ConfigKey = row["ConfigKey"].ToString(),
                            ConfigValue = row["ConfigValue"].ToString()
                        };

                        lclStationConfig.Add(stConfig);
                    }


                    StationsDetails_Labels detailsLabels = new StationsDetails_Labels();
                    detailsLabels.PrinterName = "";

                    foreach (StationsConfig sconfig in lclStationConfig)
                    {
                        if (sconfig.Category == "Labels")
                        {
                            if (sconfig.ConfigKey == "PrinterName")
                            {
                                detailsLabels.PrinterName = sconfig.ConfigValue;
                                if (!ChronosValidations.PrinterExists(detailsLabels.PrinterName))
                                {
                                    _stationPrinterExists = false;
                                }
                            }
                        }
                    }
                    lclStation.PrinterName = detailsLabels;
                    _stationConfigIsValid = true;
                }

                StationConfiguration = lclStation;


                if (!lclStation.DisplayFullScreen)
                {
                    FormBorderStyle = FormBorderStyle.FixedSingle;
                }
            }
        }

        private void LoadCellConfig()
        {
            DataTable cellMainInfo = CellsLogic.GetCellById(this, StationConfiguration.CellId);
            if (cellMainInfo.Rows.Count > 0)
            {
                Cells lclcells = new Cells();
                foreach (DataRow row in cellMainInfo.Rows)
                {
                    lclcells.CellId = int.Parse(row["Id"].ToString());
                    lclcells.CellName = row["CellName"].ToString();
                    lclcells.BUId = int.Parse(row["BUId"].ToString());
                    lclcells.DepartmentNumber = int.Parse(row["DepartmentNumber"].ToString());
                    lclcells.WorkCenter = row["WorkCenter"].ToString();
                    lclcells.UnityFacilityId = int.Parse(row["UnityFacilityId"].ToString());
                    lclcells.UnityCellId = int.Parse(row["UnityCellId"].ToString());
                    lclcells.FacilityNumber = int.Parse(row["FacilityNumber"].ToString());
                    lclcells.Active = bool.Parse(row["Active"].ToString());
                }
                _cellIsActive = lclcells.Active;

                //Cell Settings
                DataTable cellSettings = CellsLogic.GetCellsSettingsByCellId(this, StationConfiguration.CellId);
                if (cellSettings.Rows.Count > 0)
                {
                    List<CellsSettings> lclCellSettings = new List<CellsSettings>();
                    foreach (DataRow row in cellSettings.Rows)
                    {
                        CellsSettings cs = new CellsSettings
                        {
                            SettingId = int.Parse(row["SettingId"].ToString()),
                            CellId = int.Parse(row["CellId"].ToString()),
                            Category = row["Category"].ToString(),
                            SettingKey = row["SettingKey"].ToString(),
                            SettingValue = row["SettingValue"].ToString(),
                            Comments = row["Comments"].ToString()
                        };
                        lclCellSettings.Add(cs);
                    }

                    CellSettings_Main mainSet = new CellSettings_Main();

                    foreach (CellsSettings cSets in lclCellSettings)
                    {
                        if (cSets.Category == "Main")
                        {
                            if (cSets.SettingKey == "InfoSource")
                            {
                                mainSet.InfoSource = cSets.SettingValue;
                            }
                            if (cSets.SettingKey == "ReportToFRN")
                            {
                                mainSet.ReportToFRN = cSets.SettingValue == "1" ? true : false;
                                _cellIsConfigIsValid = true;
                            }
                        }
                    }

                    lclcells.MainSetting = mainSet;
                    CellsInformation = lclcells;
                }

            }
        }

        private void LoadOBCConfig()
        {
            OperationsByCell lclOBC = OperationsByCellLogic.GetOperationByCellById(this, StationConfiguration.OperationByCellId);
            if (lclOBC != null)
            {
                _oBCIsActive = lclOBC.Active;
                
                //OBC Settings
                DataTable obcSettings = OperationsByCellLogic.GetOperationByCellConfigById(this, StationConfiguration.OperationByCellId);
                if (obcSettings.Rows.Count > 0)
                {
                    List<OperationsByCellConfig> lclOBCSettings = new List<OperationsByCellConfig>();
                    foreach (DataRow row in obcSettings.Rows)
                    {
                        OperationsByCellConfig cs = new OperationsByCellConfig
                        {
                            OBCId = int.Parse(row["OperationByCellId"].ToString()),
                            Category = row["Category"].ToString(),
                            ConfigKey = row["ConfigKey"].ToString(),
                            ConfigValue = row["ConfigValue"].ToString()
                        };
                        lclOBCSettings.Add(cs);
                    }

                    //Settings Classes
                    OBCConfigDetails_Main lclOBCConfig_Main = new OBCConfigDetails_Main();
                    OBCConfigDetails_Config lclOBCConfig_Config = new OBCConfigDetails_Config();
                    OBCConfigDetails_Tracking lclOBCConfig_Tracking = new OBCConfigDetails_Tracking();
                    List<OBCConfigDetails_Input> lclOBCConfig_Inputs = new List<OBCConfigDetails_Input>();
                    OBCConfigDetails_Labels lclOBCConfig_Labels = new OBCConfigDetails_Labels();
                    OBCConfigDetails_Racks lclOBCConfig_Racks = new OBCConfigDetails_Racks();

                    foreach (OperationsByCellConfig sconfig in lclOBCSettings)
                    {
                        if (sconfig.Category == "Main")
                        {
                            if (sconfig.ConfigKey == "Profile")
                            {
                                lclOBCConfig_Main.Profile = sconfig.ConfigValue;
                                Roles[0] = lclOBCConfig_Main.Profile;

                                if (Roles[0].ToString() == "P") //P = Print
                                    MainScreen = ChronosScreens.PrintLabels;
                                else if (Roles[0].ToString() == "T") //T = Track
                                    MainScreen = ChronosScreens.Tracking;
                                else if (Roles[0].ToString() == "RW") //RW = Rework
                                    MainScreen = ChronosScreens.Tracking;
                                else if (Roles[0].ToString() == "DT") //DT = Down Time
                                    MainScreen = ChronosScreens.DownTime;
                                else if (Roles[0].ToString() == "OC") //OC = Order Consolidate
                                    MainScreen = ChronosScreens.OrderConsolidation;
                                else if (Roles[0].ToString() == "LC") //LC = Line Consolidate
                                    MainScreen = ChronosScreens.LineConsolidation;
                            }
                        }
                        else if (sconfig.Category == "Config")
                        {
                            if (sconfig.ConfigKey == "AllowDefects")
                                lclOBCConfig_Config.AllowDefects = sconfig.ConfigValue == "1" ? true : false;
                            if (sconfig.ConfigKey == "AllowDownTime")
                                lclOBCConfig_Config.AllowDownTime = sconfig.ConfigValue == "1" ? true : false;
                        }
                        else if (sconfig.Category == "Tracking")
                        {
                            if (sconfig.ConfigKey == "AutoOutput")
                                lclOBCConfig_Tracking.AutoOutput = sconfig.ConfigValue == "1" ? true : false;
                            if (sconfig.ConfigKey == "TrackLabelPrint")
                                lclOBCConfig_Tracking.TrackLabelPrint = sconfig.ConfigValue == "1" ? true : false;
                            if (sconfig.ConfigKey == "TrackLabelReprint")
                                lclOBCConfig_Tracking.TrackLabelReprint = sconfig.ConfigValue == "1" ? true : false;
                            //Moved to cell settings
                            //if (sconfig.ConfigKey == "ReportToFRN")
                            //    lclOBCConfig_Tracking.ReportToERP = sconfig.ConfigValue == "1" ? true : false;
                        }
                        else if (sconfig.Category == "Input")
                        {
                            //Get LabelTypes
                            DataTable Labels = LabelTypesLogic.GetLabelTypeById(this, int.Parse(sconfig.ConfigValue));
                            LabelTypes SLabelTypes = new LabelTypes();
                            foreach (DataRow row in Labels.Rows)
                            {
                                SLabelTypes.LabelTypeId = int.Parse(row["Id"].ToString());
                                SLabelTypes.LabelTypeCode = row["LabelTypeCode"].ToString();
                                SLabelTypes.LabelTypeName = row["LabelTypeName"].ToString();
                            }

                            DataTable Instructions = StationsLogic.GetStationInstructions(this, SLabelTypes.LabelTypeCode);
                            StationsInstructions SInst = new StationsInstructions();
                            foreach (DataRow row in Instructions.Rows)
                            {
                                SInst.Instruction_en = row["Instruction_en"].ToString();
                                SInst.Instruction_es = row["Instruction_es"].ToString();
                                SInst.OKMessage_en = row["OKMessage_en"].ToString();
                                SInst.OKMessage_es = row["OKMessage_es"].ToString();
                                SInst.ErrorMessage_en = row["ErrorMessage_en"].ToString();
                                SInst.ErrorMessage_es = row["ErrorMessage_es"].ToString();
                            }

                            OBCConfigDetails_Input lclInputs = new OBCConfigDetails_Input
                            {
                                InputNumber = int.Parse(sconfig.ConfigKey),
                                LabelType = SLabelTypes,
                                Instructions = SInst
                            };

                            lclOBCConfig_Inputs.Add(lclInputs);

                        }
                        else if (sconfig.Category == "Labels")
                        {
                            if (sconfig.ConfigKey == "PrintLabel")
                                lclOBCConfig_Labels.PrintLabel = sconfig.ConfigValue == "1" ? true : false;
                            if (sconfig.ConfigKey == "ReLabel")
                                lclOBCConfig_Labels.ReLabel = sconfig.ConfigValue == "1" ? true : false;
                            if (sconfig.ConfigKey == "AllowReprint")
                                lclOBCConfig_Labels.AllowReprint = sconfig.ConfigValue == "1" ? true : false;
                            if (sconfig.ConfigKey == "AskUser")
                                lclOBCConfig_Labels.AskUser = sconfig.ConfigValue == "1" ? true : false;
                            if (sconfig.ConfigKey == "NumberOfCopies")
                                lclOBCConfig_Labels.NumberOfCopies = int.Parse(sconfig.ConfigValue);
                            if (sconfig.ConfigKey == "PrintingScreen")
                            {
                                lclOBCConfig_Labels.PrintingScreen = sconfig.ConfigValue;
                                _PrintingScreenType = sconfig.ConfigValue;
                            }
                        }
                        else if (sconfig.Category == "Racks")
                        {
                            if (sconfig.ConfigKey == "RackBehavior")
                                lclOBCConfig_Racks.RackBehavior = sconfig.ConfigValue;
                            if (sconfig.ConfigKey == "RackId")
                                lclOBCConfig_Racks.RackId = Array.ConvertAll(sconfig.ConfigValue.Split(','), int.Parse);
                        }
                    }

                    lclOBC.OBCConfig = lclOBCSettings;
                    lclOBC.OBCConfig_Config = lclOBCConfig_Config;
                    lclOBC.OBCConfig_Inputs = lclOBCConfig_Inputs.OrderBy(x => x.InputNumber).ToList();
                    lclOBC.OBCConfig_Labels = lclOBCConfig_Labels;
                    lclOBC.OBCConfig_Main = lclOBCConfig_Main;
                    lclOBC.OBCConfig_Racks = lclOBCConfig_Racks;
                    lclOBC.OBCConfig_Tracking = lclOBCConfig_Tracking;


                    OperationsByCellConfiguration = lclOBC;
                    _oBCIsConfigIsValid = true;
                }
            }
        }

        private void LoadFlowsConfig()
        {
            List<Flows> lclFlows = FlowsLogic.GetFlowByCurrentOBCId(this, StationConfiguration.OperationByCellId);
            if (lclFlows != null)
            {
                FlowConfiguration = lclFlows;
                _flowsConfigIsValid = true;
            }
        }
        #endregion
        
        private void GetShifts()
        {
            DataTable Shifts = _chronosService.Chronos_GetShiftsByCell(FacilityId.ToString());
        }

        private void StartDefaultMachinery()
        {
            //SearchForAndon();
        }

        private void StopDefaultMachinery()
        {
            DisconnectAndon();
        }
        
        #region AndonLights
        private void SearchForAndon()
        {
            _andonControl = new AndonLights();

            if (_andonControl.IsConnected())
            {
                CustomBarStatus1 = "Andon Conectado";
                _andonControl.Reset();
                _andonControl.TurnGreenLightOn(false);
            }
        }

        private void DisconnectAndon()
        {
            if (_andonControl != null)
                _andonControl.Reset();
        }
        #endregion
        
        #region Stations
        private void ShowTrackingScreen()
        {
            if (_trackingScreen == null)
                _trackingScreen = new Tracking(this)
                {
                    Dock = DockStyle.Fill
                };
            CurrentScreen = ChronosScreens.Tracking;
            pnlStationHolder.Controls.Add(_trackingScreen);
            _trackingScreen.Focus();
        }

        private void ShowOrderConsolidationScreen()
        {
            if (_orderConsolidationScreen == null)
                _orderConsolidationScreen = new OrderConsolidation(this)
                {
                    Dock = DockStyle.Fill
                };
            CurrentScreen = ChronosScreens.OrderConsolidation;
            pnlStationHolder.Controls.Add(_orderConsolidationScreen);
            _orderConsolidationScreen.Focus();
        }

        private void ShowLineConsolidationScreen()
        {
            if (_lineConsolidationScreen == null)
                _lineConsolidationScreen = new LineConsolidation(this)
                {
                    Dock = DockStyle.Fill
                };
            CurrentScreen = ChronosScreens.LineConsolidation;
            pnlStationHolder.Controls.Add(_lineConsolidationScreen);
            _lineConsolidationScreen.Focus();
        }

        private void ShowDownTimeScreen(string DownTimeCode)
        {
            if (_downTimeScreen == null)
                _downTimeScreen = new DownTime(this, DownTimeCode)
                {
                    Dock = DockStyle.Fill,
                    AndonControls = _andonControl
                };
            CurrentScreen = ChronosScreens.DownTime;
            pnlStationHolder.Controls.Add(_downTimeScreen);
            _downTimeScreen.Focus();
        }

        private void ShowPrintLabelsScreen()
        {
            if (_PrintingScreenType == "A")
            {
                if (_printLabelsAutoScreen == null)
                    _printLabelsAutoScreen = new LabelPrintingAuto(this)
                    {
                        Dock = DockStyle.Fill
                    };

                CurrentScreen = ChronosScreens.PrintLabels;
                pnlStationHolder.Controls.Add(_printLabelsAutoScreen);
                _printLabelsAutoScreen.ForceFocus();
            }
            else if (_PrintingScreenType == "M")
            {
                if (_printLabelsManualScreen == null)
                    _printLabelsManualScreen = new LabelPrintingManual(this)
                    {
                        Dock = DockStyle.Fill
                    };

                CurrentScreen = ChronosScreens.PrintLabels;
                pnlStationHolder.Controls.Add(_printLabelsManualScreen);
                _printLabelsManualScreen.Focus();
            }
        }

        private void ShowTrackinReport()
        {
            _reportTrackingHistory = new TrackingHistoryReport(this)
            {
                Dock = DockStyle.Fill
            };
            pnlStationHolder.Controls.Add(_reportTrackingHistory);
            _reportTrackingHistory.BringToFront();
        }

        private void ClearStations()
        {
            pnlMainHolder.Controls.Clear();
            //foreach (Control control in pnlMainHolder.Controls)
            //    if(control is EmployeeValidation)
            //        control.Dispose();
            
            pnlStationHolder.Controls.Clear();
            //foreach (Control control in pnlStationHolder.Controls)
            //    control.Dispose();

            _employeeValidation = null;
            _trackingScreen = null;
            _orderConsolidationScreen = null;
            _lineConsolidationScreen = null;
            _downTimeScreen = null;
            _printLabelsAutoScreen = null;
            _printLabelsManualScreen = null;
            _reportTrackingHistory = null;
        }
        #endregion

        private void StationHolder_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopDefaultMachinery();
        }
    }
}
