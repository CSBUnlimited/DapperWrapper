using System;
using System.Data;
using MySql.Data.MySqlClient;
using CSBUnlimited.DapperWrapper.Base;

namespace CSBUnlimited.DapperWrapper.MySqlConnector
{
    /// <summary>
    /// Sql server specialiezed conecctor
    /// </summary>
    public sealed class MySqlConnector : BaseDbConnector, IDbConnector
    {
        /// <summary>
        /// MySql Connector - Constructor
        /// </summary>
        /// <param name="connectionString">Connection string for database</param>
        public MySqlConnector(string connectionString) : base(connectionString)
        { }

        /// <summary>
        /// Open connection for MySql database
        /// </summary>
        protected override void OpenConnection()
        {
            if (Connection == null || String.IsNullOrEmpty(Connection.ConnectionString))
            {
                Connection = new MySqlConnection(ConnectionString);
            }

            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }
    }
}
