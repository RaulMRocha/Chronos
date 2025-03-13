using DevExpress.XtraReports;
using Chronos.Data.Shared.Model;
using System.Collections.Generic;


namespace Chronos.Modules.LabelManager.Manager
{
    public static class PrintLabel
    {
        public static IReport SimpleBarCode128(Template_SimpleBarCode128_Data TemplateSimpleBarCode128)
        {
            List<Template_SimpleBarCode128_Data> ListSimpleBarCode128 = new List<Template_SimpleBarCode128_Data>
            {
                TemplateSimpleBarCode128
            };

            LabelTemplates.LabelTemplate_SimpleBarCode128 lblTemplate = new LabelTemplates.LabelTemplate_SimpleBarCode128();
            lblTemplate.LoadData(ListSimpleBarCode128);

            return lblTemplate;
        }

        public static IReport Component128(Template_Component128_Data TemplateComponent128)
        {
            List<Template_Component128_Data> ListComponent128 = new List<Template_Component128_Data>
            {
                TemplateComponent128
            };

            LabelTemplates.LabelTemplate_Component128 lblTemplate = new LabelTemplates.LabelTemplate_Component128();
            lblTemplate.LoadData(ListComponent128);

            return lblTemplate;
        }

        public static IReport ComponentSet128(Template_ComponentSet128_Data TemplateComponentSet128)
        {
            List<Template_ComponentSet128_Data> ListComponentSet128 = new List<Template_ComponentSet128_Data>
            {
                TemplateComponentSet128
            };

            LabelTemplates.LabelTemplate_ComponentSet128 lblTemplate = new LabelTemplates.LabelTemplate_ComponentSet128();
            lblTemplate.LoadData(ListComponentSet128);

            return lblTemplate;
        }

        public static IReport Box128(Template_Box128_Data TemplateBox128)
        {
            List<Template_Box128_Data> ListBox128 = new List<Template_Box128_Data>
            {
                TemplateBox128
            };

            LabelTemplates.LabelTemplate_Box128 lblTemplate = new LabelTemplates.LabelTemplate_Box128();
            lblTemplate.LoadData(ListBox128);

            return lblTemplate;
        }
    }
}
