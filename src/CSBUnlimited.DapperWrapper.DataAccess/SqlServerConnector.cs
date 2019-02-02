using System;
using System.Data;
using System.Data.SqlClient;

namespace CSBUnlimited.DapperWrapper
{
    public class SqlServerConnector : BaseDbConnector, IDbConnector
    {
        public SqlServerConnector(string connectionString) : base(connectionString)
        { }

        protected override void OpenConnection()
        {
            if (Connection == null || String.IsNullOrEmpty(Connection.ConnectionString))
            {
                Connection = new SqlConnection(ConnectionString);
            }

            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }
    }
}
