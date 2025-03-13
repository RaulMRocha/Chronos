namespace Chronos.Data.Shared.Model
{
    public class Flows
    {
        public int FlowId { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string ModelSettingKey { get; set; }
        public string ModelSettingValue { get; set; }
        public string ModelComments { get; set; }
        public int ComponentId { get; set; }
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
        public int Current_OBCId { get; set; }
        public int Current_CellId { get; set; }
        public int Current_UnityFacilityId { get; set; }
        public int Current_UnityCellId { get; set; }
        public int Current_BUId { get; set; }
        public int Current_OperationId { get; set; }
        public int Prev_OBCId { get; set; }
        public int Prev_CellId { get; set; }
        public int Prev_UnityFacilityId { get; set; }
        public int Prev_UnityCellId { get; set; }
        public int Prev_BUId { get; set; }
        public int Prev_OperationId { get; set; }
        public int Next_OBCId { get; set; }
        public int Next_CellId { get; set; }
        public int Next_UnityFacilityId { get; set; }
        public int Next_UnityCellId { get; set; }
        public int Next_BUId { get; set; }
        public int Next_OperationId { get; set; }
    }
}
