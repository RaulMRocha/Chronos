using System;

namespace Chronos.Data.Shared.Model
{
    public class TrackingLogs
    {
        public Guid TrackId { get; set; }
        public string RunNumber { get; set; }
        public string WorkTag { get; set; }
        public string InputLicensePlate { get; set; }
        public int OperationByCellId { get; set; }
        public int ComponentId { get; set; }
        public string SubOperationName { get; set; }
        public int StationId { get; set; }
        public string CartName { get; set; }
        public DateTime StartProcessDate { get; set; }
        public string StartProcessBy { get; set; }
        public DateTime? EndProcessDate { get; set; }
        public string EndProcessBy { get; set; }
        public string OutputLicensePlate { get; set; }
        public string OperationResult { get; set; }
    }
}
