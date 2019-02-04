using System;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// DbConnector interface
    /// </summary>
    public partial interface IDbConnector : IDisposable
    {
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
