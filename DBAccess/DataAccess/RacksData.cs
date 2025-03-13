using Chronos.Data.DBAccess.General;
using Chronos.Data.Shared;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Chronos.Data.DBAccess.DataAccess
{
    public static class RacksData
    {
        public static Tuple<bool, string> AssignComponentToRack(IChronosGlobal chronosGlobal, int CellId, int StationId, int OBCId, string WorkTag, string LicensePlate)
        {
            try
            {
                string returnValue;
                using (SqlConnection connection = DBConnection.GetConnection(chronosGlobal.ConnectToProd, chronosGlobal.ServerName, chronosGlobal.DatabaseName))
                {
                    using (SqlCommand command = new SqlCommand("sp_RacksAllocationsComponents_Add", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        SqlParameter returnParameter = command.Parameters.Add("@Result", SqlDbType.VarChar, 50);
                        returnParameter.Direction = ParameterDirection.Output;

                        command.Parameters.AddWithValue("@CellId", CellId);
                        command.Parameters.AddWithValue("@StationId", StationId);
                        command.Parameters.AddWithValue("@OBCId", OBCId);
                        command.Parameters.AddWithValue("@WorkTag", WorkTag);
                        command.Parameters.AddWithValue("@LicensePlate", LicensePlate);
                        
                        connection.Open();
                        command.ExecuteNonQuery();
                        returnValue = returnParameter.Value.ToString();
                        connection.Close();
                    }
                }
                return new Tuple<bool, string>(true, returnValue);
            }
            catch (SqlException ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
        }

        public static DataTable GetRackStatusByOrder(IChronosGlobal chronosGlobal, int CellId, int OBCId, string RackIds)
        {
            RackIds = RackIds.Replace(",", "','");

            string Select = @"SELECT [RackSlotCode]
		                            ,[RackId]
                                    ,[RackName]
		                            ,[RackLocation]
		                            ,[RackLocationBin]
		                            ,[RunNumber]
		                            ,[OrderNumber]
		                            ,CASE WHEN [OrderLinesToComplete] > 0 THEN [OrderNumber] + '    *** ' + CAST([OrderLinesToComplete] as VARCHAR(50)) + ' líneas faltantes ***' ELSE [OrderNumber] + '    *** Completada ***' END AS OrderNumberWithDesc
                                    ,[WorkTag]
		                            ,CASE WHEN [LineComponentsToComplete] > 0 THEN [WorkTag] + '    *** ' + CAST([LineComponentsToComplete] as VARCHAR(50)) + ' componentes faltantes ***' ELSE [WorkTag] + '    *** Completada ***' END  AS WorktagWithDesc
		                            ,[Line]
		                            ,[Unit]
		                            ,[ComponentId]
		                            ,[LicensePlate]
		                            ,[LastReportedOutputLicensePlate]
		                            ,[AssignedByStationId]
		                            ,[AssignedOn]
		                            ,[LineCompleted]
		                            ,[LineComponentsToComplete]
		                            ,[OrderCompleted]  
		                            ,[OrderLinesToComplete]
                            FROM [dbo].[fn_GetRackConsolidationReport](" + CellId + "," + OBCId + ") ORDER BY OrderLinesToComplete ASC";

            return SqlHelper.ExecuteSelectQuery(chronosGlobal, Select);
        }

        public static DataTable GetRackStatusByLine(IChronosGlobal chronosGlobal, int CellId, int OBCId, string RackIds)
        {
            RackIds = RackIds.Replace(",", "','");

            string Select = @"SELECT [RackSlotCode]
		                            ,[RackId]
                                    ,[RackName]
		                            ,[RackLocation]
		                            ,[RackLocationBin]
		                            ,[RunNumber]
		                            ,[OrderNumber]
		                            ,CASE WHEN [OrderLinesToComplete] > 0 THEN [OrderNumber] + '    *** ' + CAST([OrderLinesToComplete] as VARCHAR(50)) + ' líneas faltantes ***' ELSE [OrderNumber] + '    *** Completada ***' END AS OrderNumberWithDesc
                                    ,[WorkTag]
		                            ,CASE WHEN [LineComponentsToComplete] > 0 THEN [WorkTag] + '    *** ' + CAST([LineComponentsToComplete] as VARCHAR(50)) + ' componentes faltantes ***' ELSE [WorkTag] + '    *** Completada ***' END  AS WorktagWithDesc
		                            ,[Line]
		                            ,[Unit]
		                            ,[ComponentId]
		                            ,[LicensePlate]
		                            ,[LastReportedOutputLicensePlate]
		                            ,[AssignedByStationId]
		                            ,[AssignedOn]
		                            ,[LineCompleted]
		                            ,[LineComponentsToComplete]
		                            ,[OrderCompleted]  
		                            ,[OrderLinesToComplete]
                            FROM [dbo].[fn_GetRackConsolidationReport](" + CellId + "," + OBCId + ")";

            return SqlHelper.ExecuteSelectQuery(chronosGlobal, Select);
        }

        public static DataTable GetRackReportByOrderNumber(IChronosGlobal chronosGlobal, int CellId, int OBCId, string OrderNumber)
        {
            string Select = @"SELECT RackSlotCode,
	                                RackId,
	                                RackName,
	                                RackLocation,
	                                RackLocationBin,
	                                rcr.WorkTag,
	                                rcr.LicensePlate,
	                                rcr.ComponentId,
	                                rcr.AssignedByStationId,
	                                rcr.AssignedOn,
	                                CASE WHEN tl.Id IS NULL THEN 0 ELSE 1 END 'Completed'
                                FROM [dbo].[fn_GetRackConsolidationReport](" + CellId + ", " + OBCId + ") rcr " +
                                    "LEFT OUTER JOIN [Chronos].[dbo].[TrackingLogs] tl ON tl.RunNumber = rcr.RunNumber AND tl.InputLicensePlate = rcr.LicensePlate AND tl.OperationByCellId = " + OBCId + " " +
                                "WHERE OrderNumber = '" + OrderNumber + "' ";

            return SqlHelper.ExecuteSelectQuery(chronosGlobal, Select);
        }
    }
}
