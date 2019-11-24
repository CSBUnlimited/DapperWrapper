using System.Data;

namespace CSBUnlimited.DapperWrapper.Base
{
    public abstract partial class BaseDbConnector : IDbConnector
    {
        /// <summary>
        /// Open connection for there respective Database
        /// </summary>
        protected abstract void OpenConnection();

        /// <summary>
        /// Close connection with database
        /// </summary>
        protected virtual void CloseConnection()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();

            Transaction?.Dispose();

            Connection.Dispose();
        }

        /// <summary>
        /// To track and open connection for a query
        /// </summary>
        protected virtual void OpenConnectionForQueryExecution()
        {
            if (_isQueryExecutionStarted)
                return;

            if (Transaction?.Connection != null)
                return;

            OpenConnection();
            _isQueryExecutionStarted = true;
        }

        /// <summary>
        /// To track and close connection with database
        /// </summary>
        protected virtual void CloseConnectionForQueryExecution()
        {
            if (!_isQueryExecutionStarted)
                return;

            CloseConnection();
            _isQueryExecutionStarted = false;
        }
    }
}
