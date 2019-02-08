using Dapper;
using System.Collections.Generic;
using System.Data;
using static Dapper.SqlMapper;

namespace CSBUnlimited.DapperWrapper.Base
{
    public partial class BaseDbConnector : IDbConnector
    {
        /// <summary>
        /// Execute Non Query
        /// </summary>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>The number of rows affected</returns>
        protected virtual int ExecuteNonQuery(string sqlQuery, CommandType commandType, DynamicParameters parameters)
        {
            return Connection.Execute(sqlQuery, parameters, transaction: (Transaction?.Connection == null) ? null : Transaction, commandType: commandType);
        }

        /// <summary>
        /// Execute and get a single value
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Value type</returns>
        protected virtual T ExecuteScalar<T>(string sqlQuery, CommandType commandType, DynamicParameters parameters)
        {
            return Connection.ExecuteScalar<T>(sqlQuery, parameters, transaction: (Transaction?.Connection == null) ? null : Transaction, commandType: commandType);
        }

        /// <summary>
        /// Execute Query
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>List of T</returns>
        protected virtual IEnumerable<T> ExecuteQuery<T>(string sqlQuery, CommandType commandType, DynamicParameters parameters)
        {
            return Connection.Query<T>(sqlQuery, parameters, transaction: (Transaction?.Connection == null) ? null : Transaction, commandType: commandType);
        }

        /// <summary>
        /// Execute Single Or Default Query.
        /// Throw exception if returns more than one.
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Object of T</returns>
        protected virtual T ExecuteSingleOrDefaultQuery<T>(string sqlQuery, CommandType commandType, DynamicParameters parameters)
        {
            return Connection.QuerySingleOrDefault<T>(sqlQuery, parameters, transaction: (Transaction?.Connection == null) ? null : Transaction, commandType: commandType);
        }

        /// <summary>
        /// Execute Query Multiple
        /// </summary>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>GridReader</returns>
        protected virtual GridReader ExecuteQueryMultiple(string sqlQuery, CommandType commandType, DynamicParameters parameters)
        {
            return Connection.QueryMultiple(sqlQuery, parameters, transaction: (Transaction?.Connection == null) ? null : Transaction, commandType: commandType);
        }
    }
}
