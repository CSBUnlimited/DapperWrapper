using System;
using System.Data;
using System.Data.SqlClient;
using CSBUnlimited.DapperWrapper.Base;

namespace CSBUnlimited.DapperWrapper
{
    public sealed class SqlServerConnector : BaseDbConnector, IDbConnector
    {
        /// <summary>
        /// Sql Server Connector - Constructor
        /// </summary>
        /// <param name="connectionString">Connection string for database</param>
        public SqlServerConnector(string connectionString) : base(connectionString)
        { }

        /// <summary>
        /// Open connection for Sql Server database
        /// </summary>
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
