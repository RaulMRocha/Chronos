using Chronos.Data.IkarusWS;
using Chronos.Data.Shared;
using Chronos.Data.Shared.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChronosDashboards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IChronosGlobal
    {
        Dashboards.EmployeePerformance _employeePerformance;


        private string _windowsUserName = Environment.UserName;
        private string _pcName = Environment.MachineName;
        private string _versionNumber = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        //private Guid _assemblyGUID = new Guid(Assembly.GetExecutingAssembly().GetCustomAttribute<GuidAttribute>().Value.ToUpper());

        private ChronosWS _chronosService;
        private bool _preconfigIsValid = true;

        #region Chronos Global
        public SqlConnection ChronosDBConnection { get; set; }
        public Enumerations.ChronosScreens MainScreen  { get; set; }
        public Enumerations.ChronosScreens CurrentScreen  { get; set; }
        public bool IsUserLogged  { get; set; }
        public Employees MainUser  { get; set; }
        public ChronosStation StationConfiguration  { get; set; }
        public OperationsByCell OperationsByCellConfiguration { get; set; }
        public Cells CellsInformation { get; set; }
        public List<Flows> FlowConfiguration { get; set; }
        public bool ConnectToProd  { get; set; }
        public string ServerName  { get; set; }
        public string DatabaseName  { get; set; }
        public string AppVersionName  { get; set; }
        public int FacilityId  { get; set; }
        public string FacilityName  { get; set; }
        public string[] Roles  { get; set; }
        public string CustomBarStatus1  { get; set; }
        public string CustomBarStatus2  { get; set; }

        public void LogInLogOutUser(bool IsUserLogged)
        {
            throw new NotImplementedException();
        }

        public void SwitchScreens(Enumerations.ChronosScreens Screen, Enumerations.ChronosScreensActions Action, string Param1 = null, string param2 = null, string param3 = null)
        {
            throw new NotImplementedException();
        }
        #endregion



        public MainWindow()
        {
            InitializeComponent();
            try
            {
                AppVersionName = "Chronos Shopfloor Application" + " - v" + _versionNumber.Substring(0, _versionNumber.LastIndexOf('.'));
                _chronosService = new ChronosWS(true);
                GetConfiguration();
                _employeePerformance = new Dashboards.EmployeePerformance(this);
                brdMain.Child = _employeePerformance;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetConfiguration()
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
            }
        }
    }
}
