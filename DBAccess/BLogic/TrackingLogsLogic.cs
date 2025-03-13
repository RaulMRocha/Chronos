using Chronos.Data.DBAccess.DataAccess;
using Chronos.Data.Shared;
using Chronos.Data.Shared.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Chronos.Data.DBAccess.BLogic
{
    public static class TrackingLogsLogic
    {

        public static void ValidateLastOperationResult(IChronosGlobal chronosGlobal, string InputLicensePlate, int CurrentOBCId, out bool IsValidResult)
        {
            IsValidResult = false;
        }

        public static bool IsPartAlreadyProcessed(IChronosGlobal chronosGlobal, string RunNumber, string InputLicensePlate, int OBCId)
        {
            return TrackingLogsData.IsPartAlreadyProcessed(chronosGlobal, RunNumber, InputLicensePlate, OBCId);
        }

        public static int GetPrintedLabels(IChronosGlobal chronosGlobal, string RunNumber, string WorkTag)
        {
            return TrackingLogsData.GetPrintedLabels(chronosGlobal, RunNumber, WorkTag);
        }
        
        public static TrackingLogs GetRecordData(IChronosGlobal chronosGlobal, string InputLicensePlate)
        {
            TrackingLogs RecDataList = null;
            DataTable RecData = TrackingLogsData.GetRecordData(chronosGlobal, InputLicensePlate);
            if (RecData.Rows.Count > 0)
            {
                foreach (DataRow row in RecData.Rows)
                {
                    RecDataList = new TrackingLogs
                    {
                        TrackId = new Guid(row["Id"].ToString()),
                        RunNumber = row["RunNumber"].ToString(),
                        WorkTag = row["WorkTag"].ToString(),
                        InputLicensePlate = row["InputLicensePlate"].ToString(),
                        OperationByCellId = int.Parse(row["OperationByCellId"].ToString()),
                        ComponentId = int.Parse(row["ComponentId"].ToString()),
                        SubOperationName = row["SubOperationName"].ToString(),
                        StationId = int.Parse(row["StationId"].ToString()),
                        CartName = row["CartName"].ToString(),
                        StartProcessDate = DateTime.Parse(row["StartProcessDate"].ToString()),
                        StartProcessBy = row["StartProcessBy"].ToString(),
                        EndProcessDate = string.IsNullOrEmpty(row["EndProcessDate"].ToString()) ? (DateTime?)null : DateTime.Parse(row["EndProcessDate"].ToString()),
                        EndProcessBy = row["EndProcessBy"].ToString(),
                        OutputLicensePlate = row["OutputLicensePlate"].ToString(),
                        OperationResult = row["OperationResult"].ToString(),
                    };
                }
            }

            return RecDataList;
        }

        public static void DeleteSetsInProgress(IChronosGlobal chronosGlobal, string WorkTag, int OperationByCellId, int StationId)
        {
            TrackingLogsData.DeleteSetsInProgress(chronosGlobal, WorkTag, OperationByCellId, StationId);
        }

        public static void CompleteSetInProgress(IChronosGlobal chronosGlobal, string SetLicencePlate, int OperationByCellId)
        {
            TrackingLogsData.CompleteSetInProgress(chronosGlobal, SetLicencePlate, OperationByCellId);
        }

        public static int GetComponentSetNumber(IChronosGlobal chronosGlobal, string WorkTag, string InputLicensePlate, int OperationByCellId, string LabelCode)
        {
            int LabelNumber = 0;
            DataTable LabelData = TrackingLogsData.GetComponentSetNumberFromExisting(chronosGlobal, WorkTag, InputLicensePlate, OperationByCellId, LabelCode);
            if (LabelData.Rows.Count > 0)
            {
                foreach (DataRow row in LabelData.Rows)
                    if (row["InputLicensePlate"].ToString() == InputLicensePlate)
                    {
                        LabelNumber = int.Parse(row["LabelNumber"].ToString());
                        break;
                    }
            }
            else
            { 
                DataTable LabelData2 = TrackingLogsData.GetTotalCompletedComponentSet(chronosGlobal, WorkTag, InputLicensePlate, OperationByCellId, LabelCode);
                LabelNumber = LabelData2.Rows.Count + 1;
            }

            return LabelNumber;
        }

        public static int GetComponentSetComponentsCount(IChronosGlobal chronosGlobal, string SetLicensePlate, int OperationByCellId)
        {
            DataTable LabelData = TrackingLogsData.GetTotalInProcessComponentSet(chronosGlobal, SetLicensePlate, OperationByCellId);
            return LabelData.Rows.Count;
        }

        public static string GetComponentSetComponents(IChronosGlobal chronosGlobal, string SetLicensePlate, int OperationByCellId)
        {
            string Components = "";
            DataTable LabelData = TrackingLogsData.GetComponentSetComponents(chronosGlobal, SetLicensePlate, OperationByCellId);
            if (LabelData.Rows.Count > 0)
            {
                foreach (DataRow row in LabelData.Rows)
                {
                    if (string.IsNullOrEmpty(Components))
                        Components = ChronosValidations.GetComponentFromTrackingCode(row["InputLicensePlate"].ToString());
                    else
                        Components = Components + "," + ChronosValidations.GetComponentFromTrackingCode(row["InputLicensePlate"].ToString());
                }
            }

            return Components;
        }

        public static Tuple<bool, Guid> AddTrackRecordInput(IChronosGlobal chronosGlobal, string RunNumber, string WorkTag, string InputLicensePlate, int OperationByCellId, string SubOperationName, int StationId, int ComponentId, string ProcessedBy, bool IsSet = false)
        {
            return TrackingLogsData.AddTrackRecordInput(chronosGlobal, RunNumber, WorkTag, InputLicensePlate, OperationByCellId, SubOperationName, StationId, ComponentId, ProcessedBy, IsSet);
        }

        public static bool AddTrackRecordOutput(IChronosGlobal chronosGlobal, Guid RecordId, string OutputLicensePlace, int StationId, string ProcessedBy, string OutputResult, int OutputComponentId)
        {
            return TrackingLogsData.AddTrackRecordOutput(chronosGlobal, RecordId, OutputLicensePlace, StationId, ProcessedBy, OutputResult, OutputComponentId);
        }

        public static bool AddTrackRecordOutputAuto(IChronosGlobal chronosGlobal, int StationId, string ProcessedBy, string OutputResult, int OutputComponentId)
        {
            return TrackingLogsData.AddTrackRecordOutputAuto(chronosGlobal, StationId, ProcessedBy, OutputResult, OutputComponentId);
        }
    }
}
