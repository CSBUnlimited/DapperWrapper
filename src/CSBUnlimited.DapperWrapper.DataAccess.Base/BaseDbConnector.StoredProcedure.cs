using Dapper;
using System.Collections.Generic;
using System.Data;
using static Dapper.SqlMapper;

namespace CSBUnlimited.DapperWrapper.Base
{
    public abstract partial class BaseDbConnector : IDbConnector
    {
        /// <summary>
        /// Executes non-query stored procedures.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>NonQueryReturnItem</returns>
        public virtual NonQueryReturnItem ExecuteNonQueryStoredProcedure(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true)
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

            ExecuteNonQuery(storedProcedureName, CommandType.StoredProcedure, parameters);

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
        /// Executes query stored procedure for a list.
        /// </summary>
        /// <typeparam name="T">Type of the list of returned model</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryReturnItem</returns>
        public virtual QueryReturnItem<T> ExecuteQueryStoredProcedure<T>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true)
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

            returnItem.DataItemList = ExecuteQuery<T>(storedProcedureName, CommandType.StoredProcedure, parameters);

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
        /// Executes query stored procedures for single data record.
        /// </summary>
        /// <typeparam name="T">Type of the returned model</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QuerySingleOrDefaultReturnItem</returns>
        public virtual QuerySingleOrDefaultReturnItem<T> ExecuteQueryStoredProcedureSingleOrDefault<T>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true)
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

            returnItem.DataItem = ExecuteSingleOrDefaultQuery<T>(storedProcedureName, CommandType.StoredProcedure, parameters);

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
        /// Executes query stored procedures for multiple datasets.
        /// </summary>        
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleReturnItem</returns>
        public virtual QueryMultipleReturnItem ExecuteQueryMultipleStoredProcedure(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true)
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

            using (GridReader gridReader = ExecuteQueryMultiple(storedProcedureName, CommandType.StoredProcedure, parameters))
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
        /// Executes query stored procedures for item with list.
        /// </summary>
        /// <typeparam name="TFirst">Type of first item</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleSingleAndListReturnItem<TFirst, TSecond> QueryMultipleSingleWithListStoredProcedure<TFirst, TSecond>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true)
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

            using (GridReader gridReader = ExecuteQueryMultiple(storedProcedureName, CommandType.StoredProcedure, parameters))
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
        /// Executes query stored procedures for 2 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true)
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

            using (GridReader gridReader = ExecuteQueryMultiple(storedProcedureName, CommandType.StoredProcedure, parameters))
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
        /// Executes query stored procedures for 3 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true)
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

            using (GridReader gridReader = ExecuteQueryMultiple(storedProcedureName, CommandType.StoredProcedure, parameters))
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
        /// Executes query stored procedures for 4 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird, TForth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true)
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

            using (GridReader gridReader = ExecuteQueryMultiple(storedProcedureName, CommandType.StoredProcedure, parameters))
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
        /// Executes query stored procedures for 5 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird, TForth, TFifth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true)
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

            using (GridReader gridReader = ExecuteQueryMultiple(storedProcedureName, CommandType.StoredProcedure, parameters))
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
        /// Executes query stored procedures for 6 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of fifth list</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird, TForth, TFifth, TSixth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true)
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

            using (GridReader gridReader = ExecuteQueryMultiple(storedProcedureName, CommandType.StoredProcedure, parameters))
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
        /// Executes query stored procedures for 7 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of sixth list</typeparam>
        /// <typeparam name="TSeventh">Type of seventh list</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true)
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

            using (GridReader gridReader = ExecuteQueryMultiple(storedProcedureName, CommandType.StoredProcedure, parameters))
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
        /// Executes query stored procedures for 8 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of sixth list</typeparam>
        /// <typeparam name="TSeventh">Type of seventh list</typeparam>
        /// <typeparam name="TEighth">Type of eighth list</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true)
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

            using (GridReader gridReader = ExecuteQueryMultiple(storedProcedureName, CommandType.StoredProcedure, parameters))
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
        /// Executes query stored procedures for 9 lists.
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
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true)
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

            using (GridReader gridReader = ExecuteQueryMultiple(storedProcedureName, CommandType.StoredProcedure, parameters))
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
        /// Executes query stored procedures for 10 lists.
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
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true)
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

            using (GridReader gridReader = ExecuteQueryMultiple(storedProcedureName, CommandType.StoredProcedure, parameters))
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
