namespace Chronos.Data.Shared.Model
{
    public class Cells
    {
        public int CellId { get; set; }
        public string CellName { get; set; }
        public int BUId { get; set; }
        public int DepartmentNumber { get; set; }
        public string WorkCenter { get; set; }
        public int UnityFacilityId { get; set; }
        public int UnityCellId { get; set; }
        public int FacilityNumber { get; set; }
        public CellSettings_Main MainSetting { get; set; }

        public bool Active { get; set; }
    }

    public class CellsSettings
    {
        public int SettingId { get; set; }
        public int CellId { get; set; }
        public string Category { get; set; }
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }
        public string Comments { get; set; }
    }

    public class CellSettings_Main
    {
        public string InfoSource { get; set; }
        public bool ReportToFRN { get; set; }
    }
}
