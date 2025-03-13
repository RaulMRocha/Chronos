using Chronos.Data.Shared.Model;
using System.Collections.Generic;

namespace Chronos.Modules.LabelManager.LabelTemplates
{
    public partial class LabelTemplate_Component128 : DevExpress.XtraReports.UI.XtraReport
    {
        public LabelTemplate_Component128()
        {
            InitializeComponent();
        }

        public void LoadData(List<Template_Component128_Data> lbl)
        {
            this.DataSource = lbl;
        }

    }
}
