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
        private bool _isTransactionStarted;

        /// <summary>
        /// Whether Query is executing using this connection or ot
        /// </summary>
        private bool _isSingleTransactionStarted;

        protected BaseDbConnector()
        { }

        protected BaseDbConnector(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Open connection for there respective Database
        /// </summary>
        public abstract void OpenConnection();

        /// <summary>
        /// Close connection with database
        /// </summary>
        public void CloseConnection()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();

            Transaction?.Dispose();

            Connection.Dispose();
        }

        /// <summary>
        /// To track and open connection for a query
        /// </summary>
        public void CheckAndOpenConnectionForSingleTransaction()
        {
            if (_isSingleTransactionStarted)
                return;

            if (Transaction?.Connection == null)
            {
                OpenConnection();
                _isSingleTransactionStarted = true;
            }
        }

        /// <summary>
        /// To track and close connection with database
        /// </summary>
        public void CheckAndCloseConnectionForSingleTransaction()
        {
            if (!_isSingleTransactionStarted)
                return;

            CloseConnection();
            _isSingleTransactionStarted = false;
        }

        /// <summary>
        /// Begin a transaction
        /// </summary>
        public void BeginTransaction()
        {
            if (_isTransactionStarted)
                return;

            Transaction = Connection.BeginTransaction();
            _isTransactionStarted = true;
        }

        /// <summary>
        /// Commit a transaction
        /// </summary>
        public void CommitTransaction()
        {
            if (_isTransactionStarted)
                return;

            Transaction.Commit();
            _isTransactionStarted = false;
        }

        /// <summary>
        /// Rollback a transaction
        /// </summary>
        public void RollbackTransaction()
        {
            if (!_isTransactionStarted)
                return;

            Transaction.Rollback();
            _isTransactionStarted = false;
            Transaction.Dispose();
        }

        /// <summary>
        /// Dispose connection data
        /// </summary>
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
