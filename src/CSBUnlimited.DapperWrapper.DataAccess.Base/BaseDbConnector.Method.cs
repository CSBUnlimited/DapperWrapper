using System.Collections.Generic;
using System.Data;
using Dapper;

namespace CSBUnlimited.DapperWrapper.Base
{
    public partial class BaseDbConnector : IDbConnector
    {
        /// <summary>
        /// Executes scalar sql text or stored procedure.
        /// </summary>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>NonQueryReturnItem</returns>
        protected virtual QueryScalarReturnItem<T> ExecuteScalarByCommandType<T>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryScalarReturnItem<T> returnItem = new QueryScalarReturnItem<T>();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);

            OpenConnectionForQueryExecution();
            returnItem.ScalarDataItem = ExecuteScalar<T>(sqlQuery, commandType, parameters);
            CloseConnectionForQueryExecution();

            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }

        /// <summary>
        /// Executes non-query sql text or stored procedure.
        /// </summary>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>NonQueryReturnItem</returns>
        protected virtual NonQueryReturnItem ExecuteNonQueryByCommandType(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            NonQueryReturnItem returnItem = new NonQueryReturnItem();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);

            OpenConnectionForQueryExecution();
            returnItem.EffectedRowsCount = ExecuteNonQuery(sqlQuery, commandType, parameters);
            CloseConnectionForQueryExecution();

            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for a list.
        /// </summary>
        /// <typeparam name="T">Type of the list of returned model</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryReturnItem</returns>
        protected virtual QueryReturnItem<T> ExecuteQueryByCommandType<T>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryReturnItem<T> returnItem = new QueryReturnItem<T>();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);

            OpenConnectionForQueryExecution();
            returnItem.DataItemList = ExecuteQuery<T>(sqlQuery, commandType, parameters);
            CloseConnectionForQueryExecution();

            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for single data record.
        /// </summary>
        /// <typeparam name="T">Type of the returned model</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QuerySingleOrDefaultReturnItem</returns>
        protected virtual QuerySingleOrDefaultReturnItem<T> ExecuteQuerySingleOrDefaultByCommandType<T>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QuerySingleOrDefaultReturnItem<T> returnItem = new QuerySingleOrDefaultReturnItem<T>();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);

            OpenConnectionForQueryExecution();
            returnItem.DataItem = ExecuteSingleOrDefaultQuery<T>(sqlQuery, commandType, parameters);
            CloseConnectionForQueryExecution();
            
            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for multiple datasets.
        /// </summary>        
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleReturnItem</returns>
        protected virtual QueryMultipleReturnItem ExecuteQueryMultipleByCommandType(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleReturnItem returnItem = new QueryMultipleReturnItem();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);
            
            IList<dynamic> returnedLists = new List<dynamic>();

            OpenConnectionForQueryExecution();
            using (SqlMapper.GridReader gridReader = ExecuteQueryMultiple(sqlQuery, commandType, parameters))
            {
                while (!gridReader.IsConsumed)
                {
                    returnedLists.Add(gridReader.Read());
                }
            }
            CloseConnectionForQueryExecution();

            returnItem.DataLists = returnedLists;

            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for item with list.
        /// </summary>
        /// <typeparam name="TFirst">Type of first item</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        protected virtual QueryMultipleSingleAndListReturnItem<TFirst, TSecond> ExecuteQueryMultipleSingleWithListByCommandType<TFirst, TSecond>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleSingleAndListReturnItem<TFirst, TSecond> returnItem = new QueryMultipleSingleAndListReturnItem<TFirst, TSecond>();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);

            OpenConnectionForQueryExecution();
            using (SqlMapper.GridReader gridReader = ExecuteQueryMultiple(sqlQuery, commandType, parameters))
            {
                returnItem.FirstItem = gridReader.ReadSingleOrDefault<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
            }
            CloseConnectionForQueryExecution();

            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 2 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        protected virtual QueryMultipleListsReturnItem<TFirst, TSecond> ExecuteQueryMultipleByCommandType<TFirst, TSecond>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond>();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);

            OpenConnectionForQueryExecution();
            using (SqlMapper.GridReader gridReader = ExecuteQueryMultiple(sqlQuery, commandType, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
            }
            CloseConnectionForQueryExecution();

            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 3 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <param name="sqlQuery">SQL Query</param>
        /// <param name="commandType">SQL Query command type</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        protected virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird> ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird>();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);

            OpenConnectionForQueryExecution();
            using (SqlMapper.GridReader gridReader = ExecuteQueryMultiple(sqlQuery, commandType, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
            }
            CloseConnectionForQueryExecution();

            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 4 lists.
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
        protected virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth> ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird, TForth>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth>();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);

            OpenConnectionForQueryExecution();
            using (SqlMapper.GridReader gridReader = ExecuteQueryMultiple(sqlQuery, commandType, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
                returnItem.FourthCollection = gridReader.Read<TForth>();
            }
            CloseConnectionForQueryExecution();

            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 5 lists.
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
        protected virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth> ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird, TForth, TFifth>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth>();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);

            OpenConnectionForQueryExecution();
            using (SqlMapper.GridReader gridReader = ExecuteQueryMultiple(sqlQuery, commandType, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
                returnItem.FourthCollection = gridReader.Read<TForth>();
                returnItem.FifthCollection = gridReader.Read<TFifth>();
            }
            CloseConnectionForQueryExecution();

            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 6 lists.
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
        protected virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth> ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird, TForth, TFifth, TSixth>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth>();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);

            OpenConnectionForQueryExecution();
            using (SqlMapper.GridReader gridReader = ExecuteQueryMultiple(sqlQuery, commandType, parameters))
            {
                returnItem.FirstCollection = gridReader.Read<TFirst>();
                returnItem.SecondCollection = gridReader.Read<TSecond>();
                returnItem.ThirdCollection = gridReader.Read<TThird>();
                returnItem.FourthCollection = gridReader.Read<TForth>();
                returnItem.FifthCollection = gridReader.Read<TFifth>();
                returnItem.SixthCollection = gridReader.Read<TSixth>();
            }
            CloseConnectionForQueryExecution();

            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 7 lists.
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
        protected virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh> ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);

            OpenConnectionForQueryExecution();
            using (SqlMapper.GridReader gridReader = ExecuteQueryMultiple(sqlQuery, commandType, parameters))
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

            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 8 lists.
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
        protected virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth> ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);

            OpenConnectionForQueryExecution();
            using (SqlMapper.GridReader gridReader = ExecuteQueryMultiple(sqlQuery, commandType, parameters))
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

            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 9 lists.
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
        protected virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth> ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);

            OpenConnectionForQueryExecution();
            using (SqlMapper.GridReader gridReader = ExecuteQueryMultiple(sqlQuery, commandType, parameters))
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

            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }

        /// <summary>
        /// Executes query sql text or stored procedure for 10 lists.
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
        protected virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth> ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>(string sqlQuery, CommandType commandType, IDbParameterList parametersCollection, bool isReturnValueExists)
        {
            QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth> returnItem = new QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>();

            GetDynamicParametersAndReturnDbParametersByDbParameters(parametersCollection, isReturnValueExists,
                out DynamicParameters parameters, out IDbParameterList returnParameterList);

            OpenConnectionForQueryExecution();
            using (SqlMapper.GridReader gridReader = ExecuteQueryMultiple(sqlQuery, commandType, parameters))
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

            SetReturnItemByReturnDbParameters(returnParameterList, parameters, isReturnValueExists, returnItem);

            return returnItem;
        }
    }
}
