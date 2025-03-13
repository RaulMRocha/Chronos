using Chronos.Data.Shared.Model;
using System.Collections.Generic;

namespace Chronos.Modules.LabelManager.LabelTemplates
{
    public partial class LabelTemplate_ComponentSet128 : DevExpress.XtraReports.UI.XtraReport
    {
        public LabelTemplate_ComponentSet128()
        {
            InitializeComponent();
        }

        public void LoadData(List<Template_ComponentSet128_Data> lbl)
        {
            this.DataSource = lbl;
        }

    }
}
