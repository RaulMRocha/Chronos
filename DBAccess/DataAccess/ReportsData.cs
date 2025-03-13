using Chronos.Data.DBAccess.General;
using Chronos.Data.Shared;
using System.Data;


namespace Chronos.Data.DBAccess.DataAccess
{
    public static class ReportsData
    {
        public static DataTable GetTrackingReport(IChronosGlobal _chronosGlobal, string Filter, string FilterValue)
        {
            string Select = @"SELECT TOP 100 vwOBC.[CellName]
	                              ,[RunNumber]
                                  ,[WorkTag]
                                  ,[InputLicensePlate]
                                  ,TL.[OperationByCellId]
                                  ,vwOBC.[OperationName_es]
                                  ,TL.[StationId]
	                              ,vwSt.StationName_es
                                  ,[CartName]
                                  ,[SubOperationName]
                                  ,[StartProcessDate]
                                  ,[StartProcessBy]
                                  ,[EndProcessDate]
                                  ,[EndProcessBy]
                                  ,[OutputLicensePlate]
                                  ,[OperationResult]
                              FROM [Chronos].[dbo].[TrackingLogs] TL
                              INNER JOIN [Chronos].[dbo].[vw_OperationsByCell] vwOBC ON vwOBC.OBCId = TL.OperationByCellId
                              INNER JOIN [Chronos].[dbo].[vw_Stations] vwSt ON vwSt.StationId = TL.StationId  ";


            if (Filter == "Corrida")
            {
                Select = Select + "WHERE RunNumber = '" + FilterValue + "' ";
            }
            else if (Filter == "Número de orden")
            {
                Select = Select + "WHERE WorkTag = '" + FilterValue + "' ";
            }
            else if (Filter == "Etiqueta")
            {
                Select = Select + "WHERE InputLicensePlate = '" + FilterValue + "' ";
            }
            else if (Filter == "Asociado")
            {
                Select = Select + "WHERE StartProcessBy = '" + FilterValue + "' ";
            }

            Select = Select + " ORDER BY StartProcessDate DESC";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }

        public static DataTable GetProductionByEmployeeReport(IChronosGlobal _chronosGlobal, string OperationByCellId, string FromDate, string ToDate)
        {
            string Select = @"SELECT [StartProcessBy]
                                ,CONCAT(vw3.Names, ' ', vw3.LastNameFather) 'FullName'
                                ,[OperationByCellId]
                                ,[SubOperationName]
                                ,COUNT(*) 'Total'
                            FROM [Chronos].[dbo].[TrackingLogs]
	                            LEFT OUTER JOIN vw_TRESS_AllPlants_Employees vw3 ON vw3.EmpNumber COLLATE DATABASE_DEFAULT = StartProcessBy COLLATE DATABASE_DEFAULT
                            WHERE StartProcessDate BETWEEN '" + FromDate + "' AND '" + ToDate + "' AND OperationByCellId = " + OperationByCellId + " ";

            Select = Select + @" GROUP BY [StartProcessBy] 
                                ,[OperationByCellId] 
                                ,[SubOperationName] 
                                ,CONCAT(vw3.Names, ' ', vw3.LastNameFather) 
	                        ORDER BY Total DESC";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }
        
        public static DataTable GetProductionByOperationReport(IChronosGlobal _chronosGlobal, string OperationByCellId, string FromDate, string ToDate)
        {
            string Select = @"SELECT [OperationByCellId]
                                ,COUNT(*) 'Total'
                            FROM [Chronos].[dbo].[TrackingLogs]
	                            LEFT OUTER JOIN vw_TRESS_AllPlants_Employees vw3 ON vw3.EmpNumber COLLATE DATABASE_DEFAULT = StartProcessBy COLLATE DATABASE_DEFAULT
                            WHERE StartProcessDate BETWEEN '" + FromDate + "' AND '" + ToDate + "' AND OperationByCellId = " + OperationByCellId + " ";

            Select = Select + @" GROUP BY [OperationByCellId] ORDER BY Total DESC";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }
    }
}
