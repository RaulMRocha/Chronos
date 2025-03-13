using System;
using System.Data.SqlClient;

namespace Chronos.Data.DBAccess.General
{
    public static class DBConnection
    {
        /// <summary>
        /// Creates a connection string using paramenters
        /// </summary>
        /// <param name="ConnectToProd"></param>
        /// <param name="ServerName">Server name</param>
        /// <param name="DatabaseName">Database name</param>
        /// <returns></returns>
        public static SqlConnection GetConnection(bool ConnectToProd, string ServerName, string DatabaseName)
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = ServerName,
                InitialCatalog = DatabaseName,
                IntegratedSecurity = true,
                ConnectTimeout = 60
            };

            string connectionString = sqlBuilder.ToString();

            return new SqlConnection(connectionString);
        }
    }
}
