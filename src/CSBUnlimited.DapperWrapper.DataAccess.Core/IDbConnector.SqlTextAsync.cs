using System;
using System.Threading.Tasks;

namespace CSBUnlimited.DapperWrapper
{
	public partial interface IDbConnector : IDisposable
	{
		/// <summary>
		/// Executes scalar sql text - Async.
		/// </summary>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>NonQueryReturnItem</returns>
		Task<QueryScalarReturnItem<T>> ExecuteScalarSqlTextAsync<T>(string sqlQueryText, IDbParameterList parametersCollection);

		/// <summary>
		/// Executes non-query sql text - Async.
		/// </summary>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>NonQueryReturnItem</returns>
		Task<NonQueryReturnItem> ExecuteNonQuerySqlTextAsync(string sqlQueryText, IDbParameterList parametersCollection);

		/// <summary>
		/// Executes query sql text for a list - Async.
		/// </summary>
		/// <typeparam name="T">Type of the list of returned model</typeparam>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>QueryReturnItem</returns>
		Task<QueryReturnItem<T>> ExecuteQuerySqlTextAsync<T>(string sqlQueryText, IDbParameterList parametersCollection);

		/// <summary>
		/// Executes query sql text for single data record - Async.
		/// </summary>
		/// <typeparam name="T">Type of the returned model</typeparam>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>QuerySingleOrDefaultReturnItem</returns>
		Task<QuerySingleOrDefaultReturnItem<T>> ExecuteQuerySingleOrDefaultSqlTextAsync<T>(string sqlQueryText, IDbParameterList parametersCollection);

		/// <summary>
		/// Executes query sql text for multiple datasets - Async.
		/// </summary>        
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>QueryMultipleReturnItem</returns>
		Task<QueryMultipleReturnItem> ExecuteQueryMultipleSqlTextAsync(string sqlQueryText, IDbParameterList parametersCollection);

		/// <summary>
		/// Executes query sql text for item with list - Async.
		/// </summary>
		/// <typeparam name="TFirst">Type of first item</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		Task<QueryMultipleSingleAndListReturnItem<TFirst, TSecond>> ExecuteQueryMultipleSingleWithListSqlTextAsync<TFirst, TSecond>(string sqlQueryText, IDbParameterList parametersCollection);

		/// <summary>
		/// Executes query sql text for 2 lists - Async.
		/// </summary>
		/// <typeparam name="TFirst">Type of first list</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		Task<QueryMultipleListsReturnItem<TFirst, TSecond>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond>(string sqlQueryText, IDbParameterList parametersCollection);

		/// <summary>
		/// Executes query sql text for 3 lists - Async.
		/// </summary>
		/// <typeparam name="TFirst">Type of first list</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <typeparam name="TThird">Type of third list</typeparam>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird>(string sqlQueryText, IDbParameterList parametersCollection);

		/// <summary>
		/// Executes query sql text for 4 lists - Async.
		/// </summary>
		/// <typeparam name="TFirst">Type of first list</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <typeparam name="TThird">Type of third list</typeparam>
		/// <typeparam name="TForth">Type of forth list</typeparam>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird, TForth>(string sqlQueryText, IDbParameterList parametersCollection);

		/// <summary>
		/// Executes query sql text for 5 lists - Async.
		/// </summary>
		/// <typeparam name="TFirst">Type of first list</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <typeparam name="TThird">Type of third list</typeparam>
		/// <typeparam name="TForth">Type of forth list</typeparam>
		/// <typeparam name="TFifth">Type of fifth list</typeparam>
		/// <param name="sqlQueryText">SQL Query Text</param>
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird, TForth, TFifth>(string sqlQueryText, IDbParameterList parametersCollection);

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
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth>(string sqlQueryText, IDbParameterList parametersCollection);

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
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>(string sqlQueryText, IDbParameterList parametersCollection);

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
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>(string sqlQueryText, IDbParameterList parametersCollection);

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
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>(string sqlQueryText, IDbParameterList parametersCollection);

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
		/// <param name="parametersCollection">Input parameter list</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>> ExecuteQueryMultipleSqlTextAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>(string sqlQueryText, IDbParameterList parametersCollection);
	}
}
