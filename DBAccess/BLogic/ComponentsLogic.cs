using Chronos.Data.DBAccess.DataAccess;
using Chronos.Data.Shared;
using Chronos.Data.Shared.Model;
using System.Collections.Generic;
using System.Data;

namespace Chronos.Data.DBAccess.BLogic
{
    public static class ComponentsLogic
    {
        public static Components GetComponentById(IChronosGlobal chronosGlobal, int ComponentId)
        {
            Components Comps = new Components();
            DataTable comp = ComponentsData.GetComponentById(chronosGlobal, ComponentId);
            List<ComponentsLabelsConfig> ListComps = GetComponentLabelConfigByComponentId(chronosGlobal, ComponentId);
            if (comp.Rows.Count > 0)
            {
                foreach (DataRow row in comp.Rows)
                {
                    Comps.ComponentId = int.Parse(row["ComponentId"].ToString());
                    Comps.ModelId = int.Parse(row["ModelId"].ToString());
                    Comps.ModelName = row["ModelName"].ToString();
                    Comps.ComponentName = row["ComponentName"].ToString();
                    Comps.ComponentDesc = row["ComponentDesc"].ToString();
                    Comps.OnePerOrder = bool.Parse(row["OnePerOrder"].ToString());
                    Comps.UsesFRN = bool.Parse(row["UsesFRN"].ToString());
                    Comps.LabelTypeId = int.Parse(row["LabelTypeId"].ToString());
                    Comps.LabelTypeCode = row["LabelTypeCode"].ToString();
                    Comps.LabelTypeName = row["LabelTypeName"].ToString();
                    Comps.LabelTypeTemplateId = int.Parse(row["LabelTypeTemplateId"].ToString());
                    Comps.LabelTemplateName = row["LabelTemplateName"].ToString();
                    Comps.LabelTemplateCode = row["LabelTemplateCode"].ToString();
                    Comps.DataSlots = int.Parse(row["DataSlots"].ToString());
                    Comps.LabelCode = row["LabelCode"].ToString();
                    Comps.LabelQtyFRNSegment = row["LabelQtyFRNSegment"].ToString();
                    Comps.LabelConfiguration = ListComps;
                    Comps.IsActive = bool.Parse(row["Active"].ToString());
                }

            }
            return Comps;
        }

        public static int GetComponentIdByLicensePlate(IChronosGlobal chronosGlobal, string LicensePlate)
        {
            int ComponentId = 0;
            DataTable comp = ComponentsData.GetComponentIdByLicensePlate(chronosGlobal, LicensePlate);
            if (comp.Rows.Count > 0)
            {
                foreach (DataRow row in comp.Rows)
                {
                    ComponentId = int.Parse(row["ComponentId"].ToString());
                }
            }
            return ComponentId;
        }

        public static DataTable GetComponentByLabelTypeCode(IChronosGlobal chronosGlobal, string LabelTypeCode)
        {
            return ComponentsData.GetComponentByLabelTypeCode(chronosGlobal, LabelTypeCode);
        }

        public static List<ComponentsLabelsConfig> GetComponentLabelConfigByComponentId(IChronosGlobal chronosGlobal, int ComponentId)
        {
            List<ComponentsLabelsConfig> ListComps = new List<ComponentsLabelsConfig>();
            DataTable dtComp = ComponentsData.GetComponentLabelConfigByComponentId(chronosGlobal, ComponentId);
            if (dtComp.Rows.Count > 0)
            {
                foreach (DataRow row in dtComp.Rows)
                {
                    ComponentsLabelsConfig comps = new ComponentsLabelsConfig
                    {
                        ComponentId = int.Parse(row["ComponentId"].ToString()),
                        DataSlotNumber = int.Parse(row["DataSlotNumber"].ToString()),
                        ConstantValue = row["ConstantValue"].ToString(),
                        VariableValue = row["VariableValue"].ToString()
                    };
                    ListComps.Add(comps);
                }
            }

            return ListComps;
        }

        public static List<ComponentSetComponents> GetComponentSetComponents(IChronosGlobal chronosGlobal, string ComponentIds, string WorkTag, int CurrentOBCId)
        {
            List<ComponentSetComponents> ListComps = new List<ComponentSetComponents>();
            DataTable comp = ComponentsData.GetComponentSetComponents(chronosGlobal, ComponentIds, WorkTag);
            if (comp.Rows.Count > 0)
            {
                foreach (DataRow row in comp.Rows)
                {
                    ComponentSetComponents comps = new ComponentSetComponents
                    {
                        ComponentId = int.Parse(row["ComponentId"].ToString()),
                        ModelId = int.Parse(row["ModelId"].ToString()),
                        ModelName = row["ModelName"].ToString(),
                        ComponentName = row["ComponentName"].ToString(),
                        ComponentDesc = row["ComponentDesc"].ToString(),
                        RunNumber = row["RunNumber"].ToString(),
                        WorkTag = row["WorkTag"].ToString(),
                        InputLicensePlate = row["InputLicensePlate"].ToString(),
                        OutputLicensePlate = row["OutputLicensePlate"].ToString(),
                        OnePerOrder = bool.Parse(row["OnePerOrder"].ToString()),
                        UsesFRN = bool.Parse(row["UsesFRN"].ToString()),
                        LabelTypeId = int.Parse(row["LabelTypeId"].ToString()),
                        LabelTypeCode = row["LabelTypeCode"].ToString(),
                        LabelTypeName = row["LabelTypeName"].ToString(),
                        LabelTypeTemplateId = int.Parse(row["LabelTypeTemplateId"].ToString()),
                        LabelTemplateName = row["LabelTemplateName"].ToString(),
                        LabelTemplateCode = row["LabelTemplateCode"].ToString(),
                        DataSlots = int.Parse(row["DataSlots"].ToString()),
                        LabelCode = row["LabelCode"].ToString(),
                        LabelQtyFRNSegment = row["LabelQtyFRNSegment"].ToString(),
                        Processed = TrackingLogsLogic.IsPartAlreadyProcessed(chronosGlobal, row["RunNumber"].ToString(), row["InputLicensePlate"].ToString(), CurrentOBCId)
                    };
                    ListComps.Add(comps);
                }
            }

            return ListComps;
        }
    }
}
