using Chronos.Data.DBAccess.DataAccess;
using Chronos.Data.Shared;
using System.Data;

namespace Chronos.Data.DBAccess.BLogic
{
    public static class ReportsLogic
    {
        public static DataTable GetTrackingReport(IChronosGlobal chronosGlobal, string Filter, string FilterValue)
        {
            return ReportsData.GetTrackingReport(chronosGlobal, Filter, FilterValue);
        }

        public static DataTable GetProductionByEmployeeReport(IChronosGlobal chronosGlobal, string OperationByCellId)
        {
            return ReportsData.GetProductionByEmployeeReport(chronosGlobal, OperationByCellId, "","");
        }



        public static DataTable GetProductionByOperationReport(IChronosGlobal chronosGlobal, string OperationByCellId)
        {
            return ReportsData.GetProductionByOperationReport(chronosGlobal, OperationByCellId, "", "");
        }
    }
}
