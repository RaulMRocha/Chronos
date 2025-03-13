using Chronos.Data.DBAccess.DataAccess;
using Chronos.Data.Shared;
using Chronos.Data.Shared.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Chronos.Data.DBAccess.BLogic
{
    public static class RacksLogic
    {
        public static Tuple<bool, string> AssignComponentToRack(IChronosGlobal chronosGlobal, int CellId, int StationId, int OBCId, string WorkTag, string LicensePlate)
        {
            bool bRealResult = true;
            string sResultText = "";

            Tuple<bool, string> Result = RacksData.AssignComponentToRack(chronosGlobal, CellId, StationId, OBCId, WorkTag, LicensePlate);

            if (Result.Item1)
            {
                sResultText = Result.Item2;
                switch (Result.Item2)
                {
                    case "NO_RACK":
                        bRealResult = false;
                        sResultText = "Error: No hay rack asignado a la operación";
                        break;
                    case "NO_LOCATIONS":
                        bRealResult = false;
                        sResultText = "Error: No hay locaciones disponibles";
                        break;
                    case "ALREADY_IN_RACK":
                        bRealResult = false;
                        sResultText = "Error: El componente ya se encuentra en el rack";
                        break;
                    default:
                        bRealResult = true;
                        break;
                }
            }

            return new Tuple<bool, string>(bRealResult, sResultText);
        }

        public static List<RackConsolidationReport> GetRackConsolidationReportByOrder(IChronosGlobal chronosGlobal, int CellId, int OBCId, int[] RackIds)
        {
            string sRackIds = string.Join(",", RackIds);


            List<RackConsolidationReport> ListRacks = new List<RackConsolidationReport>();
            DataTable dtComp = RacksData.GetRackStatusByOrder(chronosGlobal, CellId, OBCId, sRackIds);
            if (dtComp.Rows.Count > 0)
            {
                foreach (DataRow row in dtComp.Rows)
                {
                    RackConsolidationReport locs = new RackConsolidationReport
                    {
                        RackSlotCode = row["RackSlotCode"].ToString(),
                        RackId = string.IsNullOrEmpty(row["RackId"].ToString()) ? (int?)null : int.Parse(row["RackId"].ToString()),
                        RackName = row["RackName"].ToString(),
                        RackLocation = row["RackLocation"].ToString(),
                        RackLocationBin = row["RackLocationBin"].ToString(),
                        RunNumber = row["RunNumber"].ToString(),
                        OrderNumber = row["OrderNumber"].ToString(),
                        OrderNumberWithDesc = row["OrderNumberWithDesc"].ToString(),
                        WorkTag = row["WorkTag"].ToString(),
                        WorktagWithDesc = row["WorktagWithDesc"].ToString(),
                        Line = int.Parse(row["Line"].ToString()),
                        Unit = int.Parse(row["Unit"].ToString()),
                        ComponentId = int.Parse(row["ComponentId"].ToString()),
                        LicensePlate = row["LicensePlate"].ToString(),
                        LastReportedOutputLicensePlate = row["LastReportedOutputLicensePlate"].ToString(),
                        AssignedByStationId = string.IsNullOrEmpty(row["AssignedByStationId"].ToString()) ? (int?)null : int.Parse(row["AssignedByStationId"].ToString()),
                        AssignedOn = string.IsNullOrEmpty(row["AssignedOn"].ToString()) ? (DateTime?)null : DateTime.Parse(row["AssignedOn"].ToString()),
                        LineCompleted = int.Parse(row["LineCompleted"].ToString()),
                        LineComponentsToComplete = int.Parse(row["LineComponentsToComplete"].ToString()),
                        OrderCompleted = int.Parse(row["OrderCompleted"].ToString()),
                        OrderLinesToComplete = int.Parse(row["OrderLinesToComplete"].ToString()),
                    };
                    ListRacks.Add(locs);
                }
            }

            return ListRacks;
        }

        public static List<RacksAllocations> GetRackReportByOrderNumber(IChronosGlobal chronosGlobal, int CellId, int OBCId, string OrderNumber)
        {
            List<RacksAllocations> ListRacks = new List<RacksAllocations>();
            DataTable dtComp = RacksData.GetRackReportByOrderNumber(chronosGlobal, CellId, OBCId, OrderNumber);
            if (dtComp.Rows.Count > 0)
            {
                foreach (DataRow row in dtComp.Rows)
                {
                    RacksAllocations locs = new RacksAllocations
                    {
                        RackSlotCode = row["RackSlotCode"].ToString(),
                        RackId = int.Parse(row["RackId"].ToString()),
                        RackName = row["RackName"].ToString(),
                        RackLocation = row["RackLocation"].ToString(),
                        RackLocationBin = row["RackLocationBin"].ToString(),
                        WorkTag = row["WorkTag"].ToString(),
                        LicensePlate = row["LicensePlate"].ToString(),
                        ComponentId = int.Parse(row["ComponentId"].ToString()),
                        AssignedByStation = int.Parse(row["AssignedByStationId"].ToString()),
                        Completed = int.Parse(row["Completed"].ToString()),
                        AssignedOn = DateTime.Parse(row["AssignedOn"].ToString())
                    };
                    ListRacks.Add(locs);
                }
            }

            return ListRacks;
        }

    }
}
