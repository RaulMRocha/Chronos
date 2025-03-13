using Chronos.Data.DBAccess.DataAccess;
using Chronos.Data.Shared;
using Chronos.Data.Shared.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Chronos.Data.DBAccess.BLogic
{
    public static class CompletedOrdersLogic
    {
        public static Tuple<bool, string> CheckOrderForCompletion(IChronosGlobal chronosGlobal, string Warehouse, string WorkCenter, string DepartmentNumber, string RunNumber, string OrderNumber, string WorkTag, int CellId, int OBCId, int StationId, int ReportToFRN)
        {
            return CompletedOrdersData.CheckOrderForCompletion(chronosGlobal, Warehouse, WorkCenter, DepartmentNumber, RunNumber, OrderNumber, WorkTag, CellId, OBCId, StationId, ReportToFRN);
        }
    }
}
