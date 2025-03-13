using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
using Chronos.Data.DBAccess;
using Chronos.Data.DBAccess.BLogic;
using Chronos.Data.Shared;

namespace ChronosDashboards.Dashboards
{
    /// <summary>
    /// Interaction logic for EmployeePerformance.xaml
    /// </summary>
    public partial class EmployeePerformance : UserControl
    {
        private IChronosGlobal _chronosGlobal;


        public EmployeePerformance(IChronosGlobal chronosGlobal)
        {
            InitializeComponent();
            _chronosGlobal = chronosGlobal;
            FillEmployeeList();
            FillTotals();
        }


        void FillEmployeeList()
        {
            DataTable Report = ReportsLogic.GetProductionByEmployeeReport(_chronosGlobal,"2");
            int i = 0;
            if (Report != null)
            {
                if (Report.Rows.Count > 0)
                {
                    foreach (DataRow row in Report.Rows)
                    {
                        switch (i)
                        {
                            case 0:
                                lblBestEmployeeName.Text = row["FullName"].ToString();
                                BestEmployeeTotal.Text = row["Total"].ToString();
                                BestEmployeeSubProcess.Text = row["SubOperationName"].ToString();
                                break;
                            case 1:
                                lblTop1Name.Text = row["FullName"].ToString();
                                lblTop1Total.Text = row["Total"].ToString();
                                lblTop1SubProcess.Text = row["SubOperationName"].ToString();
                                break;
                            case 2:
                                lblTop2Name.Text = row["FullName"].ToString();
                                lblTop2Total.Text = row["Total"].ToString();
                                lblTop2SubProcess.Text = row["SubOperationName"].ToString();
                                break;
                            case 3:
                                lblTop3Name.Text = row["FullName"].ToString();
                                lblTop3Total.Text = row["Total"].ToString();
                                lblTop3SubProcess.Text = row["SubOperationName"].ToString();
                                break;
                            case 4:
                                lblTop4Name.Text = row["FullName"].ToString();
                                lblTop4Total.Text = row["Total"].ToString();
                                lblTop4SubProcess.Text = row["SubOperationName"].ToString();
                                break;
                            case 5:
                                lblTop5Name.Text = row["FullName"].ToString();
                                lblTop5Total.Text = row["Total"].ToString();
                                lblTop5SubProcess.Text = row["SubOperationName"].ToString();
                                break;
                            default: break;
                        }
                        i++;
                    }
                }
            }
        }

        void FillTotals()
        {
            DataTable Report = ReportsLogic.GetProductionByOperationReport(_chronosGlobal, "2");
            if (Report != null)
            {
                if (Report.Rows.Count > 0)
                {
                    foreach (DataRow row in Report.Rows)
                    {
                        lblTotalByOp.Text = row["Total"].ToString();
                    }
                }
            }
        }

    }
}
