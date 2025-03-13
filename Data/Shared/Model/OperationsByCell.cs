using System.Collections.Generic;

namespace Chronos.Data.Shared.Model
{
    public class OperationsByCell
    {
        public int OBCId { get; set; }
        public int CellId { get; set; }
        public int UnityFacilityId { get; set; }
        public int UnityCellId { get; set; }
        public int BUId { get; set; }
        public string CellName { get; set; }
        public string WorkCenter { get; set; }
        public int DepartmentNumber { get; set; }
        public int OperationId { get; set; }
        public string OperationName_en { get; set; }
        public string OperationName_es { get; set; }
        public string TRESSOperationCode { get; set; }
        public bool ForceCertification { get; set; }
        public bool IsStartOfCell { get; set; }
        public bool IsEndOfCell { get; set; }
        public List<OperationsByCellConfig> OBCConfig { get; set; }
        public OBCConfigDetails_Main OBCConfig_Main { get; set; }
        public OBCConfigDetails_Config OBCConfig_Config { get; set; }
        public OBCConfigDetails_Tracking OBCConfig_Tracking { get; set; }
        public List<OBCConfigDetails_Input> OBCConfig_Inputs { get; set; }
        public OBCConfigDetails_Labels OBCConfig_Labels { get; set; }
        public OBCConfigDetails_Racks OBCConfig_Racks { get; set; }
        public bool Active { get; set; }
    }

    public class OperationsByCellConfig
    {
        public int OBCId { get; set; }
        public string Category { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
    }

    public class OBCConfigDetails_Main
    {
        public string Profile { get; set; }
    }

    public class OBCConfigDetails_Config
    {
        public bool AllowDefects { get; set; }
        public bool AllowDownTime { get; set; }
    }

    public class OBCConfigDetails_Tracking
    {
        public bool AutoOutput { get; set; }
        public bool TrackLabelPrint { get; set; }
        public bool TrackLabelReprint { get; set; }
        public bool ReportToERP { get; set; }
    }

    public class OBCConfigDetails_Input
    {
        public int InputNumber { get; set; }
        public LabelTypes LabelType { get; set; }
        public StationsInstructions Instructions { get; set; }
    }

    public class OBCConfigDetails_Labels
    {
        public bool PrintLabel { get; set; }
        public bool ReLabel { get; set; }
        public bool AllowReprint { get; set; }
        public bool AskUser { get; set; }
        public int NumberOfCopies { get; set; }
        public string PrintingScreen { get; set; }
    }

    public class OBCConfigDetails_Racks
    {
        public string RackBehavior { get; set; }
        public int[] RackId { get; set; }
    }
}
