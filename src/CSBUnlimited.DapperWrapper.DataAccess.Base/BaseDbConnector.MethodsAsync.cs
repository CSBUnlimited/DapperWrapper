using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace CSBUnlimited.DapperWrapper.Base
{
    public partial class BaseDbConnector : IDbConnector
    {
        /// <summary>
        /// Executes scalar sql text or stored procedure - Async.
        /// </summary>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>NonQueryReturnItem</returns>
        protected virtual async Task<QueryScalarReturnItem<T>> ExecuteScalarByCommandTypeAsync<T>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryScalarReturnItem<T> returnItem = new QueryScalarReturnItem<T>();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            OpenConnectionForQueryExecution();

            returnItem.ScalarDataItem = await ExecuteScalarAsync<T>(sqlQuery, commandType, parameters);

            CloseConnectionForQueryExecution();

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }

        /// <summary>
        /// Executes non-query sql text or stored procedure - Async.
        /// </summary>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>NonQueryReturnItem</returns>
        protected virtual async Task<NonQueryReturnItem> ExecuteNonQueryByCommandTypeAsync(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            NonQueryReturnItem returnItem = new NonQueryReturnItem();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            OpenConnectionForQueryExecution();

            returnItem.EffectedRowsCount = await ExecuteNonQueryAsync(sqlQuery, commandType, parameters);

            CloseConnectionForQueryExecution();

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for a list - Async.
        /// </summary>
        /// <typeparam name="T">Type of the list of returned model</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryReturnItem</returns>
        protected virtual async Task<QueryReturnItem<T>> ExecuteQueryByCommandTypeAsync<T>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryReturnItem<T> returnItem = new QueryReturnItem<T>();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            OpenConnectionForQueryExecution();

            returnItem.DataItemList = await ExecuteQueryAsync<T>(sqlQuery, commandType, parameters);

            CloseConnectionForQueryExecution();

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for single data record - Async.
        /// </summary>
        /// <typeparam name="T">Type of the returned model</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QuerySingleOrDefaultReturnItem</returns>
        protected virtual async Task<QuerySingleOrDefaultReturnItem<T>> ExecuteQuerySingleOrDefaultByCommandTypeAsync<T>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QuerySingleOrDefaultReturnItem<T> returnItem = new QuerySingleOrDefaultReturnItem<T>();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            OpenConnectionForQueryExecution();

            returnItem.DataItem = await ExecuteSingleOrDefaultQueryAsync<T>(sqlQuery, commandType, parameters);

            CloseConnectionForQueryExecution();

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for multiple datasets - Async.
        /// </summary>        
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleReturnItem</returns>
        protected virtual async Task<QueryMultipleReturnItem> ExecuteQueryMultipleByCommandTypeAsync(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleReturnItem returnItem = new QueryMultipleReturnItem();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            IList<dynamic> returnedLists = new List<dynamic>();

            OpenConnectionForQueryExecution();

            using (SqlMapper.GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQuery, commandType, parameters))
            {
                while (!gridReader.IsConsumed)
                {
                    returnedLists.Add(gridReader.Read());
                }
            }

            CloseConnectionForQueryExecution();

            returnItem.DataLists = returnedLists;

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for item with list - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first item</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        protected virtual async Task<QueryMultipleSingleAndListReturnItem<TFirst, TSecond>> ExecuteQueryMultipleSingleWithListByCommandTypeAsync<TFirst, TSecond>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleSingleAndListReturnItem<TFirst, TSecond> returnItem = new QueryMultipleSingleAndListReturnItem<TFirst, TSecond>();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            OpenConnectionForQueryExecution();

            using (SqlMapper.GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQuery, commandType, parameters))
            {
                returnItem.FirstItem = gridReader.ReadSingleOrDefault<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
            }

            CloseConnectionForQueryExecution();

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 2 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        protected virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond>> ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond>();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            OpenConnectionForQueryExecution();

            using (SqlMapper.GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQuery, commandType, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
            }

            CloseConnectionForQueryExecution();

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 3 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        protected virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird>> ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird>();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            OpenConnectionForQueryExecution();

            using (SqlMapper.GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQuery, commandType, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
            }

            CloseConnectionForQueryExecution();

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 4 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        protected virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth>> ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird, TForth>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth>();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            OpenConnectionForQueryExecution();

            using (SqlMapper.GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQuery, commandType, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
                returnItem.FourthCollection = gridReader.Read<TForth>();
            }

            CloseConnectionForQueryExecution();

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 5 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        protected virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth>> ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird, TForth, TFifth>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth>();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            OpenConnectionForQueryExecution();

            using (SqlMapper.GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQuery, commandType, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
                returnItem.FourthCollection = gridReader.Read<TForth>();
                returnItem.FifthCollection = gridReader.Read<TFifth>();
            }

            CloseConnectionForQueryExecution();

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 6 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of fifth list</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        protected virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth>> ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth>();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            OpenConnectionForQueryExecution();

            using (SqlMapper.GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQuery, commandType, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
                returnItem.FourthCollection = gridReader.Read<TForth>();
                returnItem.FifthCollection = gridReader.Read<TFifth>();
                returnItem.SixthCollection = gridReader.Read<TSixth>();
            }

            CloseConnectionForQueryExecution();

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 7 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of sixth list</typeparam>
        /// <typeparam name="TSeventh">Type of seventh list</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        protected virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>> ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            OpenConnectionForQueryExecution();

            using (SqlMapper.GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQuery, commandType, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
                returnItem.FourthCollection = gridReader.Read<TForth>();
                returnItem.FifthCollection = gridReader.Read<TFifth>();
                returnItem.SixthCollection = gridReader.Read<TSixth>();
                returnItem.SeventhCollection = gridReader.Read<TSeventh>();
            }

            CloseConnectionForQueryExecution();

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 8 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of sixth list</typeparam>
        /// <typeparam name="TSeventh">Type of seventh list</typeparam>
        /// <typeparam name="TEighth">Type of eighth list</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        protected virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>> ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            OpenConnectionForQueryExecution();

            using (SqlMapper.GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQuery, commandType, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
                returnItem.FourthCollection = gridReader.Read<TForth>();
                returnItem.FifthCollection = gridReader.Read<TFifth>();
                returnItem.SixthCollection = gridReader.Read<TSixth>();
                returnItem.SeventhCollection = gridReader.Read<TSeventh>();
                returnItem.EighthCollection = gridReader.Read<TEighth>();
            }

            CloseConnectionForQueryExecution();

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 9 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of sixth list</typeparam>
        /// <typeparam name="TSeventh">Type of seventh list</typeparam>
        /// <typeparam name="TEighth">Type of eighth list</typeparam>
        /// <typeparam name="TNineth">Type of ninth list</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        protected virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>> ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            OpenConnectionForQueryExecution();

            using (SqlMapper.GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQuery, commandType, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
                returnItem.FourthCollection = gridReader.Read<TForth>();
                returnItem.FifthCollection = gridReader.Read<TFifth>();
                returnItem.SixthCollection = gridReader.Read<TSixth>();
                returnItem.SeventhCollection = gridReader.Read<TSeventh>();
                returnItem.EighthCollection = gridReader.Read<TEighth>();
                returnItem.NinethCollection = gridReader.Read<TNineth>();
            }

            CloseConnectionForQueryExecution();

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 10 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of sixth list</typeparam>
        /// <typeparam name="TSeventh">Type of seventh list</typeparam>
        /// <typeparam name="TEighth">Type of eighth list</typeparam>
        /// <typeparam name="TNineth">Type of ninth list</typeparam>
        /// <typeparam name="TTenth">Type of tenth list</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        protected virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>> ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>();
            IDbParameterList returnParameterList = new DbParameterList();
            DynamicParameters parameters = new DynamicParameters();

            foreach (DbDataParameter parameter in parametersCollection)
            {
                parameters.Add(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);

                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    returnParameterList.Add(parameter);
                }
            }

            if (isReturnValueExists)
            {
                parameters.Add(ReturnValueParameterName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue, size: ReturnValueSize);
            }

            OpenConnectionForQueryExecution();

            using (SqlMapper.GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQuery, commandType, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
                returnItem.FourthCollection = gridReader.Read<TForth>();
                returnItem.FifthCollection = gridReader.Read<TFifth>();
                returnItem.SixthCollection = gridReader.Read<TSixth>();
                returnItem.SeventhCollection = gridReader.Read<TSeventh>();
                returnItem.EighthCollection = gridReader.Read<TEighth>();
                returnItem.NinethCollection = gridReader.Read<TNineth>();
                returnItem.TenthCollection = gridReader.Read<TTenth>();
            }

            CloseConnectionForQueryExecution();

            if (returnParameterList.Count > 0)
            {
                foreach (DbDataParameter parameter in returnParameterList)
                {
                    parameter.Value = GetOutputParameterValue(parameter.ParameterName, parameter.DbType, parameters);
                }

                returnItem.ReturnParametersCollection = returnParameterList;
            }

            if (isReturnValueExists)
            {
                returnItem.ReturnValue = parameters.Get<int>(ReturnValueParameterName);
            }

            return returnItem;
        }
    }
}
