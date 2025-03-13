using System.Collections.Generic;

namespace Chronos.Data.Shared.Model
{
    public class ChronosStation
    {
        public int StationId { get; set; }
        public string StationName_es { get; set; }
        public string StationName_en { get; set; }
        public string ADUserId { get; set; }
        public int OperationByCellId { get; set; }
        public int UnityFacilityId { get; set; }
        public int UnityCellId { get; set; }
        public int CellId { get; set; }
        public string CellName { get; set; }
        public int BUId { get; set; }
        public string WorkCenter { get; set; }
        public int DepartmentNumber { get; set; }
        public int OperationId { get; set; }
        public string OperationName_en { get; set; }
        public string OperationName_es { get; set; }
        public bool DisplayFullScreen { get; set; }
        public bool ValidateFlow { get; set; }
        public bool ValidateLastOp { get; set; }
        public StationsDetails_Labels PrinterName { get; set; }
        public bool IsActive { get; set; }
    }

    public class StationsConfig
    {
        public int ConfigId { get; set; }
        public int StationId { get; set; }
        public string Category { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
    }

    public class StationsDetails_Labels
    {
        public string PrinterName { get; set; }
    }

    public class StationsInstructions
    {
        public int InstructionId { get; set; }
        public string InputName { get; set; }
        public string Instruction_en { get; set; }
        public string Instruction_es { get; set; }
        public string OKMessage_en { get; set; }
        public string OKMessage_es { get; set; }
        public string ErrorMessage_en { get; set; }
        public string ErrorMessage_es { get; set; }
    }
}
