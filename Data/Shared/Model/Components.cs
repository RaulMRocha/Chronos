using System.Collections.Generic;

namespace Chronos.Data.Shared.Model
{
    public class Components
    {
        public int ComponentId { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string ComponentName { get; set; }
        public string ComponentDesc { get; set; }
        public bool OnePerOrder { get; set; }
        public bool UsesFRN { get; set; }
        public int LabelTypeId { get; set; }
        public string LabelTypeCode { get; set; }
        public string LabelTypeName { get; set; }
        public int LabelTypeTemplateId { get; set; }
        public string LabelTemplateName { get; set; }
        public string LabelTemplateCode { get; set; }
        public int DataSlots { get; set; }
        public string LabelCode { get; set; }
        public string LabelQtyFRNSegment { get; set; }
        public List<ComponentsLabelsConfig> LabelConfiguration { get; set; }
        public bool IsActive { get; set; }
    }

    public class ComponentsLabelsConfig
    {
        public int ComponentId { get; set; }
        public int DataSlotNumber { get; set; }
        public string ConstantValue { get; set; }
        public string VariableValue { get; set; }

    }

    public class ComponentSetComponents
    {
        public int ComponentId { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string ComponentName { get; set; }
        public string ComponentDesc { get; set; }
        public string RunNumber { get; set; }
        public string WorkTag { get; set; }
        public string InputLicensePlate { get; set; }
        public string OutputLicensePlate { get; set; }
        public bool OnePerOrder { get; set; }
        public bool UsesFRN { get; set; }
        public int LabelTypeId { get; set; }
        public string LabelTypeCode { get; set; }
        public string LabelTypeName { get; set; }
        public int LabelTypeTemplateId { get; set; }
        public string LabelTemplateName { get; set; }
        public string LabelTemplateCode { get; set; }
        public int DataSlots { get; set; }
        public string LabelCode { get; set; }
        public string LabelQtyFRNSegment { get; set; }
        public bool Processed { get; set; }
    }
}
