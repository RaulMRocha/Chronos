using Chronos.Data.DBAccess.General;
using Chronos.Data.Shared;
using System.Data;
using System.Data.SqlClient;

namespace Chronos.Data.DBAccess.DataAccess
{
    public static class StationsData
    {
        public static void UpdateStationData(IChronosGlobal _chronosGlobal, string PCName, string VersionName, string ADUser)
        {
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection(_chronosGlobal.ConnectToProd, _chronosGlobal.ServerName, _chronosGlobal.DatabaseName))
                {
                    using (SqlCommand command = new SqlCommand("sp_UpdateStationData", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        command.Parameters.AddWithValue("@PCName", PCName);
                        command.Parameters.AddWithValue("@AppVersionName", VersionName);
                        command.Parameters.AddWithValue("@ADUser", ADUser);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (SqlException)
            {
            }
        }

        public static DataTable GetMainConfiguration(IChronosGlobal _chronosGlobal, string ADUser, int UnityFacilityId)
        {
            string Select = @"SELECT [StationId]
                                  ,[StationName_es]
                                  ,[StationName_en]
                                  ,[ADUserId]
                                  ,[OperationByCellId]
                                  ,[DisplayFullScreen]
                                  ,[CellId]
                                  ,[UnityFacilityId]
                                  ,[UnityCellId]
                                  ,[CellId]
                                  ,[CellName]
                                  ,[BUId]
                                  ,[WorkCenter]
                                  ,[DepartmentNumber]
                                  ,[OperationId]
                                  ,[OperationName_en]
                                  ,[OperationName_es]
                                  ,[IsEndOfCell]
                                  ,[ValidateFlow]
                                  ,[ValidateLastOperation]
                                  ,[PCName]
                                  ,[VersionName]
                                  ,[LastLoginDate]
                                  ,[CreationDate]
                                  ,[CreatedBy]
                                  ,[LastUpdatedDate]
                                  ,[LastUpdatedBy]
                                  ,[Active] 
                              FROM [Chronos].[dbo].[vw_Stations] 
	                            WHERE ADUserId = '" + ADUser + "' AND UnityFacilityId = " + UnityFacilityId;

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }

        public static DataTable GetSecondaryConfiguration(IChronosGlobal _chronosGlobal, int StationId)
        {
            string Select = @"SELECT [Id]
                                  ,[StationId]
                                  ,[Category]
                                  ,[ConfigKey]
                                  ,[ConfigValue] 
                              FROM [Chronos].[dbo].[StationsConfig] 
	                            WHERE StationId = " + StationId;

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }

        public static DataTable GetStationInstructions(IChronosGlobal _chronosGlobal, string InputName)
        {
            string Select = @"SELECT [Id]
                                  ,[InputName]
                                  ,[Instruction_en]
                                  ,[Instruction_es] 
                                  ,[OKMessage_en]
                                  ,[OKMessage_es]
                                  ,[ErrorMessage_en]
                                  ,[ErrorMessage_es]
                              FROM [Chronos].[dbo].[StationsInstructions] 
	                            WHERE InputName = '" + InputName + "' ";

            return SqlHelper.ExecuteSelectQuery(_chronosGlobal, Select);
        }
    }
}
