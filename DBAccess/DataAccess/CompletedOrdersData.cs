using Chronos.Data.DBAccess.General;
using Chronos.Data.Shared;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Chronos.Data.DBAccess.DataAccess
{
    public static class CompletedOrdersData
    {
        public static Tuple<bool, string> CheckOrderForCompletion(IChronosGlobal chronosGlobal, string Warehouse, string WorkCenter, string DepartmentNumber, string RunNumber, string OrderNumber, string WorkTag, int CellId, int OBCId, int StationId, int ReportToFRN)
        {
            try
            {
                string returnValue;
                using (SqlConnection connection = DBConnection.GetConnection(chronosGlobal.ConnectToProd, chronosGlobal.ServerName, chronosGlobal.DatabaseName))
                {
                    using (SqlCommand command = new SqlCommand("sp_CompletedOrders_CheckNAdd", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        SqlParameter returnParameter = command.Parameters.Add("@OrderCompleted", SqlDbType.Int, 50);
                        returnParameter.Direction = ParameterDirection.Output;

                        command.Parameters.AddWithValue("@Warehouse", Warehouse);
                        command.Parameters.AddWithValue("@WorkCenter", WorkCenter);
                        command.Parameters.AddWithValue("@DepartmentNumber", DepartmentNumber);
                        command.Parameters.AddWithValue("@RunNumber", RunNumber);
                        command.Parameters.AddWithValue("@OrderNumber", OrderNumber);
                        command.Parameters.AddWithValue("@CellId", CellId);
                        command.Parameters.AddWithValue("@OperationByCellId", OBCId);
                        command.Parameters.AddWithValue("@StationId", StationId);
                        command.Parameters.AddWithValue("@ReportToFRN", ReportToFRN);

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
    }
}
