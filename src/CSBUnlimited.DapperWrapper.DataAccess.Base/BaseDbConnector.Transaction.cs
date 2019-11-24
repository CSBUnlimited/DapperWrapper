namespace CSBUnlimited.DapperWrapper.Base
{
    public abstract partial class BaseDbConnector : IDbConnector
    {


        /// <inheritdoc />
        /// <summary>
        /// Begin a transaction
        /// </summary>
        public virtual void BeginTransaction()
        {
            if (_isTransactionStarted)
                return;

            Transaction = Connection.BeginTransaction();
            _isTransactionStarted = true;
        }

        /// <inheritdoc />
        /// <summary>
        /// Commit a transaction
        /// </summary>
        public virtual void CommitTransaction()
        {
            if (_isTransactionStarted)
                return;

            Transaction.Commit();
            _isTransactionStarted = false;
        }

        /// <inheritdoc />
        /// <summary>
        /// Rollback a transaction
        /// </summary>
        public virtual void RollbackTransaction()
        {
            if (!_isTransactionStarted)
                return;

            Transaction.Rollback();
            _isTransactionStarted = false;
            Transaction.Dispose();
        }
    }
}
