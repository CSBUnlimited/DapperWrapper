using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace CSBUnlimited.DapperWrapper.Base
{
    public partial class BaseDbConnector : IDbConnector
    {
        /// <summary>
		/// Executes non-query sql text - Async.
		/// </summary>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>NonQueryReturnItem</returns>
		public virtual async Task<NonQueryReturnItem> ExecuteNonQuerySqlTextAsync(string sqlQueryText, IDbParameterList parametersCollection, bool isReturnValueExists = false)
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

            OpenConnectionForSingleTransaction();

            await ExecuteNonQueryAsync(sqlQueryText, CommandType.Text, parameters);

            CloseConnectionForSingleTransaction();

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
		/// Executes query sql text for a list - Async.
		/// </summary>
		/// <typeparam name="T">Type of the list of returned model</typeparam>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>QueryReturnItem</returns>
		public virtual async Task<QueryReturnItem<T>> ExecuteQuerySqlTextAsync<T>(string sqlQueryText, IDbParameterList parametersCollection, bool isReturnValueExists = false)
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

            OpenConnectionForSingleTransaction();

            returnItem.DataItemList = await ExecuteQueryAsync<T>(sqlQueryText, CommandType.Text, parameters);

            CloseConnectionForSingleTransaction();

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
		/// Executes query sql text for single data record - Async.
		/// </summary>
		/// <typeparam name="T">Type of the returned model</typeparam>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>QuerySingleOrDefaultReturnItem</returns>
		public virtual async Task<QuerySingleOrDefaultReturnItem<T>> ExecuteQuerySqlTextSingleOrDefaultAsync<T>(string sqlQueryText, IDbParameterList parametersCollection, bool isReturnValueExists = false)
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

            OpenConnectionForSingleTransaction();

            returnItem.DataItem = await ExecuteSingleOrDefaultQueryAsync<T>(sqlQueryText, CommandType.Text, parameters);

            CloseConnectionForSingleTransaction();

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
		/// Executes query sql text for multiple datasets - Async.
		/// </summary>        
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>QueryMultipleReturnItem</returns>
		public virtual async Task<QueryMultipleReturnItem> ExecuteQueryMultipleSqlTextAsync(string sqlQueryText, IDbParameterList parametersCollection, bool isReturnValueExists = false)
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

            OpenConnectionForSingleTransaction();

            using (GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQueryText, CommandType.Text, parameters))
            {
                while (!gridReader.IsConsumed)
                {
                    returnedLists.Add(gridReader.Read());
                }
            }

            CloseConnectionForSingleTransaction();

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
		/// Executes query sql text for item with list - Async.
		/// </summary>
		/// <typeparam name="TFirst">Type of first item</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		public virtual async Task<QueryMultipleSingleAndListReturnItem<TFirst, TSecond>> QueryMultipleSingleWithListSqlTextAsync<TFirst, TSecond>(string sqlQueryText, IDbParameterList parametersCollection, bool isReturnValueExists = false)
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

            OpenConnectionForSingleTransaction();

            using (GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQueryText, CommandType.Text, parameters))
            {
                returnItem.FirstItem = gridReader.ReadSingleOrDefault<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
            }

            CloseConnectionForSingleTransaction();

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
		/// Executes query sql text for 2 lists - Async.
		/// </summary>
		/// <typeparam name="TFirst">Type of first list</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond>(string sqlQueryText, IDbParameterList parametersCollection, bool isReturnValueExists = false)
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

            OpenConnectionForSingleTransaction();

            using (GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQueryText, CommandType.Text, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
            }

            CloseConnectionForSingleTransaction();

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
		/// Executes query sql text for 3 lists - Async.
		/// </summary>
		/// <typeparam name="TFirst">Type of first list</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <typeparam name="TThird">Type of third list</typeparam>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird>(string sqlQueryText, IDbParameterList parametersCollection, bool isReturnValueExists = false)
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

            OpenConnectionForSingleTransaction();

            using (GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQueryText, CommandType.Text, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
            }

            CloseConnectionForSingleTransaction();

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
        /// Executes query sql text for 4 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird, TForth>(string sqlQueryText, IDbParameterList parametersCollection, bool isReturnValueExists = false)
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

            OpenConnectionForSingleTransaction();

            using (GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQueryText, CommandType.Text, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
                returnItem.FourthCollection = gridReader.Read<TForth>();
            }

            CloseConnectionForSingleTransaction();

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
        /// Executes query sql text for 5 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird, TForth, TFifth>(string sqlQueryText, IDbParameterList parametersCollection, bool isReturnValueExists = false)
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

            OpenConnectionForSingleTransaction();

            using (GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQueryText, CommandType.Text, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
                returnItem.FourthCollection = gridReader.Read<TForth>();
                returnItem.FifthCollection = gridReader.Read<TFifth>();
            }

            CloseConnectionForSingleTransaction();

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
        /// Executes query sql text for 6 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of fifth list</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth>(string sqlQueryText, IDbParameterList parametersCollection, bool isReturnValueExists = false)
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

            OpenConnectionForSingleTransaction();

            using (GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQueryText, CommandType.Text, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
                returnItem.FourthCollection = gridReader.Read<TForth>();
                returnItem.FifthCollection = gridReader.Read<TFifth>();
                returnItem.SixthCollection = gridReader.Read<TSixth>();
            }

            CloseConnectionForSingleTransaction();

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
        /// Executes query sql text for 7 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of sixth list</typeparam>
        /// <typeparam name="TSeventh">Type of seventh list</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>(string sqlQueryText, IDbParameterList parametersCollection, bool isReturnValueExists = false)
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

            OpenConnectionForSingleTransaction();

            using (GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQueryText, CommandType.Text, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
                returnItem.FourthCollection = gridReader.Read<TForth>();
                returnItem.FifthCollection = gridReader.Read<TFifth>();
                returnItem.SixthCollection = gridReader.Read<TSixth>();
                returnItem.SeventhCollection = gridReader.Read<TSeventh>();
            }

            CloseConnectionForSingleTransaction();

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
        /// Executes query sql text for 8 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of sixth list</typeparam>
        /// <typeparam name="TSeventh">Type of seventh list</typeparam>
        /// <typeparam name="TEighth">Type of eighth list</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>(string sqlQueryText, IDbParameterList parametersCollection, bool isReturnValueExists = false)
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

            OpenConnectionForSingleTransaction();

            using (GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQueryText, CommandType.Text, parameters))
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

            CloseConnectionForSingleTransaction();

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
        /// Executes query sql text for 9 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of sixth list</typeparam>
        /// <typeparam name="TSeventh">Type of seventh list</typeparam>
        /// <typeparam name="TEighth">Type of eighth list</typeparam>
        /// <typeparam name="TNineth">Type of nineth list</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>(string sqlQueryText, IDbParameterList parametersCollection, bool isReturnValueExists = false)
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

            OpenConnectionForSingleTransaction();

            using (GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQueryText, CommandType.Text, parameters))
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

            CloseConnectionForSingleTransaction();

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
        /// Executes query sql text for 10 lists - Async.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of sixth list</typeparam>
        /// <typeparam name="TSeventh">Type of seventh list</typeparam>
        /// <typeparam name="TEighth">Type of eighth list</typeparam>
        /// <typeparam name="TNineth">Type of nineth list</typeparam>
        /// <typeparam name="TTenth">Type of tenth list</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>(string sqlQueryText, IDbParameterList parametersCollection, bool isReturnValueExists = false)
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

            OpenConnectionForSingleTransaction();

            using (GridReader gridReader = await ExecuteQueryMultipleAsync(sqlQueryText, CommandType.Text, parameters))
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

            CloseConnectionForSingleTransaction();

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
