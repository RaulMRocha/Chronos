using Chronos.Data.Shared.Model;
using System.Collections.Generic;


namespace Chronos.Modules.LabelManager.LabelTemplates
{
    public partial class LabelTemplate_Box128 : DevExpress.XtraReports.UI.XtraReport
    {
        public LabelTemplate_Box128()
        {
            InitializeComponent();
        }

        public void LoadData(List<Template_Box128_Data> lbl)
        {
            this.DataSource = lbl;
        }

    }
}
