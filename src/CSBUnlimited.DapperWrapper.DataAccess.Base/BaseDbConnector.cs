using Dapper;
using System;
using System.Data;
using CSBUnlimited.DapperWrapper.Core;

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
        private bool _isQueryExecutionStarted;

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
        /// PS: DbType.Currency cast to double if you need more accuracy please override this method.
        /// And DbType.Xml throws NotImplementedException, XML need external cast.
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(parameterDbType), parameterDbType, null);
            }
        }

        /// <summary>
        /// Get Dynamic Parameters And Return Db Parameters By DbParameters
        /// </summary>
        /// <param name="parametersCollection">Given DB parameters list</param>
        /// <param name="isReturnValueExists">Return value is required or not</param>
        /// <param name="dynamicParameters">Output. Dynamic Parameters</param>
        /// <param name="returnParameterCollection">Output. Return DB parameter list</param>
        protected void GetDynamicParametersAndReturnDbParametersByDbParameters(IDbParameterList parametersCollection,
            bool isReturnValueExists, out DynamicParameters dynamicParameters, out IDbParameterList returnParameterCollection)
        {
            returnParameterCollection = new DbParameterList();
            dynamicParameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                dynamicParameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterCollection.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                dynamicParameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }
        }

        /// <summary>
        /// Set Return Item By Return Db Parameters
        /// </summary>
        /// <param name="returnDbDataParameters">Output. Returning Db Parameter List</param>
        /// <param name="dynamicParameters">Output. Dynamic Parameters</param>
        /// <param name="isReturnValueExists">Return value required or not</param>
        /// <param name="returnItem">IReturnItem referenced object</param>
        protected void SetReturnItemByReturnDbParameters(IDbParameterList returnDbDataParameters, DynamicParameters dynamicParameters, bool isReturnValueExists, IReturnItem returnItem)
        {
            if (returnDbDataParameters.Count > 0)
            {
                foreach (DbDataParameter parameter in returnDbDataParameters)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, dynamicParameters);
                }
                returnItem.ReturnParametersCollection = returnDbDataParameters;
            }
            if (isReturnValueExists)
            {
                returnItem.ReturnValue = dynamicParameters.Get<int>(ReturnValueParameterName);
            }
        }

        /// <inheritdoc />
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
