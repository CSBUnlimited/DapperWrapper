using System.Data;

namespace CSBUnlimited.DapperWrapper
{
    public abstract partial class BaseDbConnector : IDbConnector
    {
        /// <summary>
        /// Constant for @RETURN_VALUE parameter
        /// </summary>
        protected const string RETURN_VALUE = "@RETURN_VALUE";


        /// <summary>
        /// Database configurations
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Database connection
        /// </summary>
        protected IDbConnection Connection;

        /// <summary>
        /// Database connection
        /// </summary>
        public IDbTransaction Transaction { get; set; }

        /// <summary>
        /// Whether transaction is started or not
        /// </summary>
        protected bool IsTransactionStarted;

        protected bool IsSingleTransactionStarted;

        protected BaseDbConnector()
        { }

        protected BaseDbConnector(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public abstract void OpenConnection();

        public void CloseConnection()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();

            Transaction?.Dispose();

            Connection.Dispose();
        }

        public void CheckAndOpenConnectionForSingleTransaction()
        {
            if (IsSingleTransactionStarted)
                return;

            if (Transaction?.Connection == null)
            {
                OpenConnection();
                IsSingleTransactionStarted = true;
            }
        }

        public void CheckAndCloseConnectionForSingleTransaction()
        {
            if (!IsSingleTransactionStarted)
                return;

            CloseConnection();
            IsSingleTransactionStarted = false;
        }

        public void BeginTransaction()
        {
            if (IsTransactionStarted)
                return;

            Transaction = Connection.BeginTransaction();
            IsTransactionStarted = true;
        }

        public void CommitTransaction()
        {
            if (IsTransactionStarted)
                return;

            Transaction.Commit();
            IsTransactionStarted = false;
        }

        public void RollbackTransaction()
        {
            if (!IsTransactionStarted)
                return;

            Transaction.Rollback();
            IsTransactionStarted = false;
            Transaction.Dispose();
        }

        public void Dispose()
        {
            if (Connection == null)
                return;

            if (Connection.State != ConnectionState.Closed)
                Connection.Close();

            Connection.Dispose();
            Connection = null;
        }
    }
}
