namespace Chronos.Data.Shared.Model
{
    public class LabelTypes
    {
        public int LabelTypeId { get; set; }
        public string LabelTypeCode { get; set; }
        public string LabelTypeName { get; set; }
    }

    public class Template_SimpleBarCode128_Data
    {
        public string BarCodeValue { get; set; }
    }

    public class Template_Component128_Data
    {
        public string BarCodeValue { get; set; }
        public string DataSlot1 { get; set; }
        public string DataSlot2 { get; set; }
        public string DataSlot3 { get; set; }
        public string DataSlot4 { get; set; }
        public string DataSlot5 { get; set; }
        public string DataSlot6 { get; set; }
        public string DataSlot7 { get; set; }
        public string DataSlot8 { get; set; }
    }

    public class Template_ComponentSet128_Data
    {
        public string BarCodeValue { get; set; }
        public string DataSlot1 { get; set; }
        public string DataSlot2 { get; set; }
        public string DataSlot3 { get; set; }
        public string DataSlot4 { get; set; }
    }

    public class Template_Box128_Data
    {
        public string BarCodeValue { get; set; }
        public string DataSlot1 { get; set; }
        public string DataSlot2 { get; set; }
        public string DataSlot3 { get; set; }
        public string DataSlot4 { get; set; }
    }
}
