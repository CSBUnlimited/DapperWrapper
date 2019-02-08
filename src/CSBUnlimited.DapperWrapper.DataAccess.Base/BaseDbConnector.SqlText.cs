using System.Data;

namespace CSBUnlimited.DapperWrapper.Base
{
    public partial class BaseDbConnector : IDbConnector
    {
        /// <summary>
        /// Executes scalar sql text.
        /// </summary>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>NonQueryReturnItem</returns>
        public virtual QueryScalarReturnItem<T> ExecuteScalarSqlText<T>(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteScalarByCommandType<T>(sqlQueryText, CommandType.Text, parametersCollection, false);

        /// <summary>
        /// Executes non-query sql text.
        /// </summary>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>NonQueryReturnItem</returns>
        public virtual NonQueryReturnItem ExecuteNonQuerySqlText(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteNonQueryByCommandType(sqlQueryText, CommandType.Text, parametersCollection, false);

        /// <summary>
        /// Executes query sql text for a list.
        /// </summary>
        /// <typeparam name="T">Type of the list of returned model</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>QueryReturnItem</returns>
        public virtual QueryReturnItem<T> ExecuteQuerySqlText<T>(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteQueryByCommandType<T>(sqlQueryText, CommandType.Text, parametersCollection, false);

        /// <summary>
        /// Executes query sql text for single data record.
        /// </summary>
        /// <typeparam name="T">Type of the returned model</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>QuerySingleOrDefaultReturnItem</returns>
        public virtual QuerySingleOrDefaultReturnItem<T> ExecuteQuerySingleOrDefaultSqlText<T>(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteQuerySingleOrDefaultByCommandType<T>(sqlQueryText, CommandType.Text, parametersCollection, false);

        /// <summary>
        /// Executes query sql text for multiple datasets.
        /// </summary>        
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>QueryMultipleReturnItem</returns>
        public virtual QueryMultipleReturnItem ExecuteQueryMultipleSqlText(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteQueryMultipleByCommandType(sqlQueryText, CommandType.Text, parametersCollection, false);

        /// <summary>
        /// Executes query sql text for item with list.
        /// </summary>
        /// <typeparam name="TFirst">Type of first item</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleSingleAndListReturnItem<TFirst, TSecond> ExecuteQueryMultipleSingleWithListSqlText<TFirst, TSecond>(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteQueryMultipleSingleWithListByCommandType<TFirst, TSecond>(sqlQueryText, CommandType.Text, parametersCollection, false);

        /// <summary>
        /// Executes query sql text for 2 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond> ExecuteQueryMultipleSqlText<TFirst, TSecond>(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteQueryMultipleByCommandType<TFirst, TSecond>(sqlQueryText, CommandType.Text, parametersCollection, false);

        /// <summary>
        /// Executes query sql text for 3 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird> ExecuteQueryMultipleSqlText<TFirst, TSecond, TThird>(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird>(sqlQueryText, CommandType.Text, parametersCollection, false);

        /// <summary>
        /// Executes query sql text for 4 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth> ExecuteQueryMultipleSqlText<TFirst, TSecond, TThird, TForth>(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird, TForth>(sqlQueryText, CommandType.Text, parametersCollection, false);

        /// <summary>
        /// Executes query sql text for 5 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth> ExecuteQueryMultipleSqlText<TFirst, TSecond, TThird, TForth, TFifth>(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird, TForth, TFifth>(sqlQueryText, CommandType.Text, parametersCollection, false);

        /// <summary>
        /// Executes query sql text for 6 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of fifth list</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth> ExecuteQueryMultipleSqlText<TFirst, TSecond, TThird, TForth, TFifth, TSixth>(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird, TForth, TFifth, TSixth>(sqlQueryText, CommandType.Text, parametersCollection, false);

        /// <summary>
        /// Executes query sql text for 7 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <typeparam name="TFifth">Type of fifth list</typeparam>
        /// <typeparam name="TSixth">Type of sixth list</typeparam>
        /// <typeparam name="TSeventh">Type of seventh list</typeparam>
        /// <param name="sqlQueryText">SQL Query Text</param>
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh> ExecuteQueryMultipleSqlText<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>(sqlQueryText, CommandType.Text, parametersCollection, false);

        /// <summary>
        /// Executes query sql text for 8 lists.
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
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth> ExecuteQueryMultipleSqlText<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>(sqlQueryText, CommandType.Text, parametersCollection, false);

        /// <summary>
        /// Executes query sql text for 9 lists.
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
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth> ExecuteQueryMultipleSqlText<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>(sqlQueryText, CommandType.Text, parametersCollection, false);

        /// <summary>
        /// Executes query sql text for 10 lists.
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
        /// <param name="parametersCollection">Input parameter list</param>
        /// <returns>QueryMultipleListsReturnItem</returns>
        public virtual QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth> ExecuteQueryMultipleSqlText<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>(string sqlQueryText, IDbParameterList parametersCollection) =>
            ExecuteQueryMultipleByCommandType<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>(sqlQueryText, CommandType.Text, parametersCollection, false);
    }
}
