using System;

namespace CSBUnlimited.DapperWrapper
{
    public partial interface IDbConnector : IDisposable
    {
        /// <summary>
        /// Connection string for database
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Open database connection
        /// </summary>
        void OpenConnection();

        /// <summary>
        /// Close database connection
        /// </summary>
        void CloseConnection();

        /// <summary>
        /// Begin a database transaction
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commit began transaction
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Rollback began transaction
        /// </summary>
        void RollbackTransaction();
    }
}
