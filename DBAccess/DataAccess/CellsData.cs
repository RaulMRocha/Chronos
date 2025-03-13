using Chronos.Data.DBAccess.General;
using Chronos.Data.Shared;
using System.Data;

namespace Chronos.Data.DBAccess.DataAccess
{
    public static class CellsData
    {
        public static DataTable GetCellById(IChronosGlobal _chronosGlobal, int CellId)
        {
            string Select = @"SELECT [Id]
                                      ,[CellName]
                                      ,[BUId]
                                      ,[DepartmentNumber]
                                      ,[WorkCenter]
                                      ,[UnityFacilityId]
                                      ,[UnityCellId]
                                      ,[FacilityNumber]
                                      ,[CreationDate]
                                      ,[CreatedBy]
                                      ,[LastUpdatedDate]
                                      ,[LastUpdatedBy]
                                      ,[Active] 
                                  FROM [Chronos].[dbo].[Cells] 
	                            WHERE Id = '" + CellId + "' ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }

        public static DataTable GetCellsSettingsByCellId(IChronosGlobal _chronosGlobal, int CellId)
        {
            string Select = @"SELECT [SettingId]
                                      ,[CellId]
                                      ,[Category]
                                      ,[SettingKey]
                                      ,[SettingValue]
                                      ,[Comments]
                                  FROM [Chronos].[dbo].[CellSettings] 
	                            WHERE CellId = '" + CellId + "' ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }
    }
}
