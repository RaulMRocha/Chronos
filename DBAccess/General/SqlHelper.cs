using Chronos.Data.Shared;
using System.Data;
using System.Data.SqlClient;


namespace Chronos.Data.DBAccess.General
{
    public class SqlHelper
    {
        public static DataTable ExecuteSelectQuery(IChronosGlobal _chronosGlobal, string Query)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = DBConnection.GetConnection(_chronosGlobal.ConnectToProd, _chronosGlobal.ServerName, _chronosGlobal.DatabaseName))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    data.Load(command.ExecuteReader());
                    connection.Close();
                }
                return data;
            }
        }
    }
}
