using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Chronos.Data.Shared.Model;
using System.Collections.Generic;

namespace Chronos.Modules.LabelManager.LabelTemplates
{
    public partial class LabelTemplate_SimpleBarCode128 : DevExpress.XtraReports.UI.XtraReport
    {
        public LabelTemplate_SimpleBarCode128()
        {
            InitializeComponent();
        }

        public void LoadData(List<Template_SimpleBarCode128_Data> lbl)
        {
            this.DataSource = lbl;
        }

    }
}
