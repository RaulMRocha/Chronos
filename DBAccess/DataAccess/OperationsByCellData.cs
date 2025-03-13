using Chronos.Data.DBAccess.General;
using Chronos.Data.Shared;
using System.Data;

namespace Chronos.Data.DBAccess.DataAccess
{
    public static class OperationsByCellData
    {
        public static DataTable GetOperationByCellById(IChronosGlobal _chronosGlobal, int OBCId)
        {
            string Select = @"SELECT [OBCId]
                                      ,[CellId]
                                      ,[UnityFacilityId]
                                      ,[UnityCellId]
                                      ,[BUId]
                                      ,[CellName]
                                      ,[WorkCenter]
                                      ,[DepartmentNumber]
                                      ,[OperationId]
                                      ,[OperationName_en]
                                      ,[OperationName_es]
                                      ,[TRESSOperationCode]
                                      ,[ForceCertification]
                                      ,[IsStartOfCell]
                                      ,[IsEndOfCell]
                                      ,[CreationDate]
                                      ,[CreatedBy]
                                      ,[LastUpdatedDate]
                                      ,[LastUpdatedBy]
                                      ,[Active] 
                                  FROM [Chronos].[dbo].[vw_OperationsByCell] 
	                            WHERE OBCId = '" + OBCId + "' ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }

        public static DataTable GetOperationByCellConfigById(IChronosGlobal _chronosGlobal, int OBCId)
        {
            string Select = @"SELECT [Id]
                                      ,[OperationByCellId]
                                      ,[Category]
                                      ,[ConfigKey]
                                      ,[ConfigValue] 
                                  FROM [Chronos].[dbo].[OperationsByCellConfig] 
	                            WHERE OperationByCellId = '" + OBCId + "' ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }
    }
}
