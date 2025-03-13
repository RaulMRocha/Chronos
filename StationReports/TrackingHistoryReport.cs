using Chronos.Data.DBAccess;
using Chronos.Data.DBAccess.BLogic;
using Chronos.Data.Shared;
using System;
using System.Windows.Forms;

namespace Chronos.Modules.StationReports
{
    public partial class TrackingHistoryReport : UserControl
    {
        private IChronosGlobal _chronosGlobal;
        public TrackingHistoryReport(IChronosGlobal chronosGlobal)
        {
            InitializeComponent();
            _chronosGlobal = chronosGlobal;
            cbSelection.SelectedIndex = 1;

        }

        private void TxtInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
        }


        void LoadData()
        {
            try
            {
                var c = ReportsLogic.GetTrackingReport(_chronosGlobal, cbSelection.Text, txtInput.Text);
                gvTracking.DataSource = c;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Inesperado: " + ex.Message);
            }
        }

        private void BtnF10_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
