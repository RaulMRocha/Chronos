using System;
using System.Collections.Generic;

namespace Chronos.Data.Shared.Model
{
    public class Racks
    {
        public int RackId { get; set; }
        public int CellId { get; set; }
        public string RackName { get; set; }
        public string RackDescription { get; set; }
        public int TotalLocations { get; set; }
        public int BinsPerLocation { get; set; }
        public int LineAllocationRuleMin { get; set; }
        public int LineAllocationRuleMax { get; set; }
        public List<RacksAllocations> Allocations { get; set; }
        public bool Active { get; set; }
    }

    public class RacksAllocations
    {
        public string RackSlotCode { get; set; }
        public int RackId { get; set; }
        public string RackName { get; set; }
        public string RackLocation { get; set; }
        public string RackLocationBin { get; set; }
        public string WorkTag { get; set; }
        public string LicensePlate { get; set; }
        public int ComponentId { get; set; }
        public int AssignedByStation { get; set; }
        public DateTime AssignedOn { get; set; }
        public int Completed { get; set; }
    }


    public class RackConsolidationReport
    {
        public string RackSlotCode { get; set; }
        public int? RackId { get; set; }
        public string RackName { get; set; }
        public string RackLocation { get; set; }
        public string RackLocationBin { get; set; }
        public string RunNumber { get; set; }
        public string OrderNumber { get; set; }
        public string OrderNumberWithDesc { get; set; }
        public string WorkTag { get; set; }
        public string WorktagWithDesc { get; set; }
        public int Line { get; set; }
        public int Unit { get; set; }
        public int ComponentId { get; set; }
        public string LicensePlate { get; set; }
        public string LastReportedOutputLicensePlate { get; set; }
        public int? AssignedByStationId { get; set; }
        public DateTime? AssignedOn { get; set; }
        public int LineCompleted { get; set; }
        public int LineComponentsToComplete { get; set; }
        public int OrderCompleted { get; set; }
        public int OrderLinesToComplete { get; set; }

    }
}
