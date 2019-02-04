using Dapper;
using System;
using System.Data;

namespace CSBUnlimited.DapperWrapper.Base
{
    /// <summary>
    /// Base implementation of IDbConnector
    /// </summary>
    public abstract partial class BaseDbConnector : IDbConnector
    {
        /// <summary>
        /// Constant for ReturnValue parameter name
        /// </summary>
        protected readonly string ReturnValueParameterName;

        /// <summary>
        /// Constant for ReturnValue size
        /// </summary>
        protected readonly DbType ReturnValueDbType;

        /// <summary>
        /// Constant for ReturnValue dbtype
        /// </summary>
        protected readonly int? ReturnValueSize;

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

        private BaseDbConnector()
        { }

        /// <summary>
        /// Base Db Connector - Constructor
        /// Set ReturnValueParameterName as @RETURN_VALUE.
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        protected BaseDbConnector(string connectionString) : this()
        {
            ConnectionString = connectionString;
            ReturnValueParameterName = "@RETURN_VALUE";
            ReturnValueDbType = DbType.Int16;
            ReturnValueSize = null;
        }

        /// <summary>
        /// Base Db Connector - Constructor
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <param name="returnValueParameterName">Stored proceure's return value parameter name(should be Int16 type or lower)</param>
        protected BaseDbConnector(string connectionString, string returnValueParameterName) : this()
        {
            ConnectionString = connectionString;
            ReturnValueParameterName = returnValueParameterName;
        }

        /// <summary>
        /// Get Output Parameter Value - This method is overridable.
        /// Cast DbTypes to Dotnet Types.
        /// PS: DbType.Currency cast to doubale and DbType.Xml throws NotImplementedException.
        /// </summary>
        /// <param name="parameterName">Parameter Name</param>
        /// <param name="parameterDbType">Parameter DbType</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Object</returns>
        protected virtual object GetOutputParameterValue(string parameterName, DbType parameterDbType, DynamicParameters parameters)
        {
            switch (parameterDbType)
            {
                case DbType.AnsiString:
                    return parameters.Get<string>(parameterName);
                case DbType.Binary:
                    return parameters.Get<byte[]>(parameterName);
                case DbType.Byte:
                    return parameters.Get<byte?>(parameterName);
                case DbType.Boolean:
                    return parameters.Get<bool?>(parameterName);
                case DbType.Currency:
                    return parameters.Get<double?>(parameterName); // Over ride this if need more accuracy
                case DbType.Date:
                    return parameters.Get<DateTime?>(parameterName);
                case DbType.DateTime:
                    return parameters.Get<DateTime?>(parameterName);
                case DbType.Decimal:
                    return parameters.Get<decimal?>(parameterName);
                case DbType.Double:
                    return parameters.Get<double?>(parameterName);
                case DbType.Guid:
                    return parameters.Get<Guid?>(parameterName);
                case DbType.Int16:
                    return parameters.Get<short?>(parameterName);
                case DbType.Int32:
                    return parameters.Get<int?>(parameterName);
                case DbType.Int64:
                    return parameters.Get<long?>(parameterName);
                case DbType.Object:
                    return parameters.Get<object>(parameterName);
                case DbType.SByte:
                    return parameters.Get<sbyte?>(parameterName);
                case DbType.Single:
                    return parameters.Get<float?>(parameterName);
                case DbType.String:
                    return parameters.Get<string>(parameterName);
                case DbType.Time:
                    return parameters.Get<TimeSpan?>(parameterName);
                case DbType.UInt16:
                    return parameters.Get<ushort?>(parameterName);
                case DbType.UInt32:
                    return parameters.Get<uint?>(parameterName);
                case DbType.UInt64:
                    return parameters.Get<ulong?>(parameterName);
                case DbType.VarNumeric:
                    return parameters.Get<decimal?>(parameterName);
                case DbType.AnsiStringFixedLength:
                    return parameters.Get<string>(parameterName);
                case DbType.StringFixedLength:
                    return parameters.Get<string>(parameterName);
                case DbType.Xml:
                    throw new NotImplementedException("Custom Implemetation required for Xml."); // Implement your own
                case DbType.DateTime2:
                    return parameters.Get<DateTime?>(parameterName);
                case DbType.DateTimeOffset:
                    return parameters.Get<DateTimeOffset?>(parameterName);
            }

            return null;
        }

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
        protected virtual void OpenConnectionForSingleTransaction()
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
        protected virtual void CloseConnectionForSingleTransaction()
        {
            if (!_isSingleTransactionStarted)
                return;

            CloseConnection();
            _isSingleTransactionStarted = false;
        }

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

        /// <summary>
        /// Dispose connection data
        /// </summary>
        public virtual void Dispose()
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
