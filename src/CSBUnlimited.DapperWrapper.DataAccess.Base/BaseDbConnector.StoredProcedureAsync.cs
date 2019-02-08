using System.Data;
using System.Threading.Tasks;

namespace CSBUnlimited.DapperWrapper.Base
{
	public abstract partial class BaseDbConnector : IDbConnector
	{
		/// <summary>
		/// Executes non-query stored procedures - Async.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>NonQueryReturnItem</returns>
		public virtual async Task<NonQueryReturnItem> ExecuteNonQueryStoredProcedureAsync(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true) =>
			await ExecuteNonQueryByCommandTypeAsync(storedProcedureName, CommandType.StoredProcedure, parametersCollection, isReturnValueExists);

		/// <summary>
		/// Executes query stored procedure for a list - Async.
		/// </summary>
		/// <typeparam name="T">Type of the list of returned model</typeparam>
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>QueryReturnItem</returns>
		public virtual async Task<QueryReturnItem<T>> ExecuteQueryStoredProcedureAsync<T>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true) =>
			await ExecuteQueryByCommandTypeAsync<T>(storedProcedureName, CommandType.StoredProcedure, parametersCollection, isReturnValueExists);

		/// <summary>
		/// Executes query stored procedures for single data record - Async.
		/// </summary>
		/// <typeparam name="T">Type of the returned model</typeparam>
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>QuerySingleOrDefaultReturnItem</returns>
		public virtual async Task<QuerySingleOrDefaultReturnItem<T>> ExecuteQuerySingleOrDefaultStoredProcedureAsync<T>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true) =>
			await ExecuteQuerySingleOrDefaultByCommandTypeAsync<T>(storedProcedureName, CommandType.StoredProcedure, parametersCollection, isReturnValueExists);

		/// <summary>
		/// Executes query stored procedures for multiple datasets - Async.
		/// </summary>        
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>QueryMultipleReturnItem</returns>
		public virtual async Task<QueryMultipleReturnItem> ExecuteQueryMultipleStoredProcedureAsync(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true) =>
			await ExecuteQueryMultipleByCommandTypeAsync(storedProcedureName, CommandType.StoredProcedure, parametersCollection, isReturnValueExists);

		/// <summary>
		/// Executes query stored procedures for item with list - Async.
		/// </summary>
		/// <typeparam name="TFirst">Type of first item</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		public virtual async Task<QueryMultipleSingleAndListReturnItem<TFirst, TSecond>> ExecuteQueryMultipleSingleWithListStoredProcedureAsync<TFirst, TSecond>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true) =>
			await ExecuteQueryMultipleSingleWithListByCommandTypeAsync<TFirst, TSecond>(storedProcedureName, CommandType.StoredProcedure, parametersCollection, isReturnValueExists);

		/// <summary>
		/// Executes query stored procedures for 2 lists - Async.
		/// </summary>
		/// <typeparam name="TFirst">Type of first list</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond>> ExecuteQueryMultipleStoredProcedureAsync<TFirst, TSecond>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true) =>
			await ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond>(storedProcedureName, CommandType.StoredProcedure, parametersCollection, isReturnValueExists);

		/// <summary>
		/// Executes query stored procedures for 3 lists - Async.
		/// </summary>
		/// <typeparam name="TFirst">Type of first list</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <typeparam name="TThird">Type of third list</typeparam>
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird>> ExecuteQueryMultipleStoredProcedureAsync<TFirst, TSecond, TThird>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true) =>
			await ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird>(storedProcedureName, CommandType.StoredProcedure, parametersCollection, isReturnValueExists);

		/// <summary>
		/// Executes query stored procedures for 4 lists - Async.
		/// </summary>
		/// <typeparam name="TFirst">Type of first list</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <typeparam name="TThird">Type of third list</typeparam>
		/// <typeparam name="TForth">Type of forth list</typeparam>
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return value, needed to be included</param>
		/// <returns>QueryMultipleListsReturnItem</returns>
		public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth>> ExecuteQueryMultipleStoredProcedureAsync<TFirst, TSecond, TThird, TForth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true) =>
			await ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird, TForth>(storedProcedureName, CommandType.StoredProcedure, parametersCollection, isReturnValueExists);

		/// <summary>
		/// Executes query stored procedures for 5 lists - Async.
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
		public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth>> ExecuteQueryMultipleStoredProcedureAsync<TFirst, TSecond, TThird, TForth, TFifth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true) =>
			await ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird, TForth, TFifth>(storedProcedureName, CommandType.StoredProcedure, parametersCollection, isReturnValueExists);

		/// <summary>
		/// Executes query stored procedures for 6 lists - Async.
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
		public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth>> ExecuteQueryMultipleStoredProcedureAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true) =>
			await ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth>(storedProcedureName, CommandType.StoredProcedure, parametersCollection, isReturnValueExists);

		/// <summary>
		/// Executes query stored procedures for 7 lists - Async.
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
		public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>> ExecuteQueryMultipleStoredProcedureAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true) =>
			await ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>(storedProcedureName, CommandType.StoredProcedure, parametersCollection, isReturnValueExists);

		/// <summary>
		/// Executes query stored procedures for 8 lists - Async.
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
		public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>> ExecuteQueryMultipleStoredProcedureAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true) =>
			await ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>(storedProcedureName, CommandType.StoredProcedure, parametersCollection, isReturnValueExists);

		/// <summary>
		/// Executes query stored procedures for 9 lists - Async.
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
		public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>> ExecuteQueryMultipleStoredProcedureAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true) =>
			await ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>(storedProcedureName, CommandType.StoredProcedure, parametersCollection, isReturnValueExists);

		/// <summary>
		/// Executes query stored procedures for 10 lists - Async.
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
		public virtual async Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>> ExecuteQueryMultipleStoredProcedureAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true) =>
			await ExecuteQueryMultipleByCommandTypeAsync<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>(storedProcedureName, CommandType.StoredProcedure, parametersCollection, isReturnValueExists);
	}
}
