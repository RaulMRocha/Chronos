using Chronos.Data.DBAccess.General;
using Chronos.Data.Shared;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Chronos.Data.DBAccess.DataAccess
{
    public static class TrackingLogsData
    {
        public static bool IsPartAlreadyProcessed(IChronosGlobal chronosGlobal, string RunNumber, string InputLicensePlate, int OBCId)
        {
            bool Printed = false;
            int Processed = 0;
            string Select = @"SELECT COUNT(*) 'Processed' 
                                  FROM [Chronos].[dbo].[TrackingLogs] 
                                  WHERE OperationByCellId = '" + OBCId + "' AND RunNumber = '" + RunNumber + "' AND InputLicensePlate = '" + InputLicensePlate + "' ";

            DataTable res = SqlHelper.ExecuteSelectQuery(chronosGlobal, Select);

            foreach (DataRow row in res.Rows)
                Processed = int.Parse(row["Processed"].ToString());

            if (Processed > 0)
                Printed = true;
            else
                Printed = false;


            return Printed;
        }

        public static int GetPrintedLabels(IChronosGlobal chronosGlobal, string RunNumber, string WorkTag)
        {
            int printed = 0;
            string Select = @"SELECT COUNT(*) 'Printed'
                                 FROM [Chronos].[dbo].[TrackingLogs]
                                 WHERE OperationByCellId = (
                                    SELECT TOP 1 [OperationByCellId]
                                    FROM [Chronos].[dbo].[TrackingLogs]
                                    WHERE WorkTag = '" + WorkTag + "' AND RunNumber = '" + RunNumber + "'  ORDER BY StartProcessDate ASC) AND  WorkTag = '" + WorkTag + "' AND RunNumber = '" + RunNumber + "' ";

            DataTable res = SqlHelper.ExecuteSelectQuery(chronosGlobal, Select);

            foreach (DataRow row in res.Rows)
            {
                printed = int.Parse(row["Printed"].ToString());
            }

            return printed;
        }

        public static DataTable GetRecordData(IChronosGlobal chronosGlobal, string InputLicensePlate)
        {
            string Select = @"SELECT TOP 1 [Id]
                                  ,[RunNumber]
                                  ,[WorkTag]
                                  ,[InputLicensePlate]
                                  ,[OperationByCellId]
                                  ,[ComponentId]
                                  ,[SubOperationName]
	                              ,[StationId]
                                  ,[CartName]
                                  ,[StartProcessDate]
                                  ,[StartProcessBy]
                                  ,[EndProcessDate]
                                  ,[EndProcessBy]
                                  ,[OutputLicensePlate]
                                  ,[OperationResult]
                              FROM [Chronos].[dbo].[TrackingLogs] 
                                WHERE InputLicensePlate = '" + InputLicensePlate + "' ORDER BY StartProcessDate DESC";

            return SqlHelper.ExecuteSelectQuery(chronosGlobal, Select);
        }

        public static void DeleteSetsInProgress(IChronosGlobal chronosGlobal, string WorkTag, int OperationByCellId, int StationId)
        {
            string Select = @"DELETE FROM [Chronos].[dbo].[TrackingLogs] 
                                WHERE [WorkTag] = '" + WorkTag + "' AND [OperationByCellId] = '" + OperationByCellId + "' AND [StationId] = '" + StationId + "' AND [IsSetCompleted] = 0 ";

            SqlHelper.ExecuteSelectQuery(chronosGlobal, Select);
        }

        public static void CompleteSetInProgress(IChronosGlobal chronosGlobal, string SetLicencePlate, int OperationByCellId)
        {
            string Select = @"UPDATE [Chronos].[dbo].[TrackingLogs] 
                                    SET [IsSetCompleted] = '1'
                                WHERE [OutputLicensePlate] = '" + SetLicencePlate + "' AND [OperationByCellId] = '" + OperationByCellId + "' AND [IsSetCompleted] = 0 ";

            SqlHelper.ExecuteSelectQuery(chronosGlobal, Select);
        }

        public static DataTable GetComponentSetNumberFromExisting(IChronosGlobal chronosGlobal, string WorkTag, string InputLicensePlate, int OperationByCellId, string LabelCode)
        {
            string Select = @"SELECT [RunNumber]
                                  ,[WorkTag]
                                  ,[InputLicensePlate]
                                  ,[OperationByCellId]
                                  ,[ComponentId]
                                  ,[SubOperationName]
                                  ,[StationId]
                                  ,[CartName]
                                  ,[IsSetCompleted]
                                  ,[OutputLicensePlate]
	                              ,LEFT(RIGHT([OutputLicensePlate], 5),3) 'LabelCode'
	                              ,RIGHT(RIGHT([OutputLicensePlate], 5),2) 'LabelNumber' 
                              FROM [Chronos].[dbo].[TrackingLogs] 
                              WHERE IsSetCompleted = 1 AND [InputLicensePlate] = '" + InputLicensePlate + "' AND [OperationByCellId] = '" + OperationByCellId + "' AND LEFT(RIGHT([OutputLicensePlate], 5),3) = '" + LabelCode +  "' ";

            return SqlHelper.ExecuteSelectQuery(chronosGlobal, Select);
        }

        public static DataTable GetTotalCompletedComponentSet(IChronosGlobal chronosGlobal, string WorkTag, string InputLicensePlate, int OperationByCellId, string LabelCode)
        {
            string Select = @"SELECT DISTINCT [OutputLicensePlate]
                              FROM [Chronos].[dbo].[TrackingLogs] 
                              WHERE IsSetCompleted = 1 AND [WorkTag] = '" + WorkTag + "' AND [OperationByCellId] = '" + OperationByCellId + "' AND LEFT(RIGHT([OutputLicensePlate], 5),3) = '" + LabelCode + "' ";

            return SqlHelper.ExecuteSelectQuery(chronosGlobal, Select);
        }
        
        public static DataTable GetTotalInProcessComponentSet(IChronosGlobal chronosGlobal, string SetLicensePlate, int OperationByCellId)
        {
            string Select = @"SELECT DISTINCT [OutputLicensePlate]
                              FROM [Chronos].[dbo].[TrackingLogs]
                              WHERE OperationByCellId = '" + OperationByCellId + "' AND IsSetCompleted = 0 AND OutputLicensePlate = '" + SetLicensePlate + "' ";

            return SqlHelper.ExecuteSelectQuery(chronosGlobal, Select);
        }

        public static DataTable GetComponentSetComponents(IChronosGlobal chronosGlobal, string SetLicensePlate, int OperationByCellId)
        {
            string Select = @"SELECT DISTINCT [InputLicensePlate]
                              FROM [Chronos].[dbo].[TrackingLogs]
                              WHERE OperationByCellId = '" + OperationByCellId + "' AND IsSetCompleted = 0 AND OutputLicensePlate = '" + SetLicensePlate + "' ";

            return SqlHelper.ExecuteSelectQuery(chronosGlobal, Select);
        }

        public static Tuple<bool, Guid> AddTrackRecordInput(IChronosGlobal chronosGlobal, string RunNumber, string WorkTag, string InputLicensePlate, int OperationByCellId, string SubOperationName, int StationId, int ComponentId, string ProcessedBy, bool IsSet)
        {
            try
            {
                Guid TNTId = Guid.NewGuid();
                using (SqlConnection connection = DBConnection.GetConnection(chronosGlobal.ConnectToProd, chronosGlobal.ServerName, chronosGlobal.DatabaseName))
                {
                    using (SqlCommand command = new SqlCommand("sp_TrackingLogsInput_Add", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        command.Parameters.AddWithValue("@TrackNTraceId", TNTId);
                        command.Parameters.AddWithValue("@RunNumber", RunNumber);
                        command.Parameters.AddWithValue("@WorkTag", WorkTag);
                        command.Parameters.AddWithValue("@InputLicensePlate", InputLicensePlate);
                        command.Parameters.AddWithValue("@OperationByCellId", OperationByCellId);
                        command.Parameters.AddWithValue("@ComponentId", ComponentId);
                        command.Parameters.AddWithValue("@StationId", StationId);
                        command.Parameters.AddWithValue("@StartProcessBy", ProcessedBy);
                        command.Parameters.AddWithValue("@SubOperationName", SubOperationName);

                        if(IsSet)
                            command.Parameters.AddWithValue("@IsSetCompleted", 0);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    return new Tuple<bool, Guid>(true, TNTId);
                }

            }
            catch (SqlException)
            {
                return new Tuple<bool, Guid>(false, Guid.Empty);
            }
        }

        public static bool AddTrackRecordOutput(IChronosGlobal chronosGlobal, Guid RecordId, string OutputLicensePlace, int StationId, string ProcessedBy, string OutputResult, int OutputComponentId)
        {
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection(chronosGlobal.ConnectToProd, chronosGlobal.ServerName, chronosGlobal.DatabaseName))
                {

                    using (SqlCommand command = new SqlCommand("sp_TrackingLogsOutput_Add", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        command.Parameters.AddWithValue("@TrackNTraceId", RecordId);
                        command.Parameters.AddWithValue("@OutputLicensePlace", OutputLicensePlace);
                        command.Parameters.AddWithValue("@StationId", StationId);
                        command.Parameters.AddWithValue("@ProcessedBy", ProcessedBy);
                        command.Parameters.AddWithValue("@OutputResult", OutputResult);
                        command.Parameters.AddWithValue("@OutputComponentId", OutputComponentId);


                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    return true;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public static bool AddTrackRecordOutputAuto(IChronosGlobal chronosGlobal, int StationId, string ProcessedBy, string OutputResult, int OutputComponentId)
        {
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection(chronosGlobal.ConnectToProd, chronosGlobal.ServerName, chronosGlobal.DatabaseName))
                {

                    using (SqlCommand command = new SqlCommand("sp_TrackingLogsOutputAuto_Add", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        command.Parameters.AddWithValue("@StationId", StationId);
                        command.Parameters.AddWithValue("@ProcessedBy", ProcessedBy);
                        command.Parameters.AddWithValue("@OutputResult", OutputResult);
                        command.Parameters.AddWithValue("@OutputComponentId", OutputComponentId);


                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    return true;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
