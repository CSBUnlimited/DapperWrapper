using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSBUnlimited.DapperWrapper
{
	public partial interface IDbConnector : IDisposable
	{
		/// <summary>
		/// Asynchronously executes non-query stored procedures. Ex: Insert, Update, Delete
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
		/// <returns>object of NonQueryReturnItem composed of data to be returned</returns>
		Task<NonQueryReturnItem> ExecuteNonQueryStoredProcedureAsync(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists);

		/// <summary>
		/// Asynchronously executes query stored procedure for a list. Ex: Select
		/// </summary>
		/// <typeparam name="T">Type of the list of returned model</typeparam>
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
		/// <returns>object of QueryReturnItem composed of data to be returned</returns>
		Task<QueryReturnItem<T>> ExecuteQueryStoredProcedureAsync<T>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists);

		/// <summary>
		/// Asynchronously executes query stored procedures for single data record. Ex: Select 1 record
		/// </summary>
		/// <typeparam name="T">Type of the returned model</typeparam>
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
		/// <returns>object of QuerySingleOrDefaultReturnItem composed of data to be returned</returns>
		Task<QuerySingleOrDefaultReturnItem<T>> ExecuteQueryStoredProcedureSingleOrDefaultAsync<T>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists);

		/// <summary>
		/// Asynchronously executes query stored procedures for multiple datasets. Ex: Parent child
		/// </summary>        
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
		/// <returns>object of QueryMultipleReturnItem composed of data to be returned</returns>
		Task<QueryMultipleReturnItem> ExecuteQueryMultipleStoredProcedureAsync(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists);

		/// <summary>
		/// Asynchronously executes query stored procedures for item + list. ex: Parent/Child
		/// </summary>
		/// <typeparam name="TFirst">Type of first item</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
		/// <returns>object of QueryMultipleListsReturnItem composed of data to be returned</returns>
		Task<QueryMultipleSingleAndListReturnItem<TFirst, TSecond>> QueryMultipleSingleWithListStoredProcedureAsync<TFirst, TSecond>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists);

		/// <summary>
		/// Asynchronously executes query stored procedures for 2 lists. ex: Parent/Child
		/// </summary>
		/// <typeparam name="TFirst">Type of first list</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
		/// <returns>object of QueryMultipleListsReturnItem composed of data to be returned</returns>
		Task<QueryMultipleListsReturnItem<TFirst, TSecond>> ExecuteQueryMultipleStoredProcedureAsync<TFirst, TSecond>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists);

		/// <summary>
		/// Asynchronously executes query stored procedures for 2 lists. ex: Parent/Child
		/// </summary>
		/// <typeparam name="TFirst">Type of first list</typeparam>
		/// <typeparam name="TSecond">Type of second list</typeparam>
		/// <typeparam name="TThird">Type of third list</typeparam>
		/// <param name="storedProcedureName">Name of the stored procedure</param>
		/// <param name="parametersCollection">Input/Output parameter list</param>
		/// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
		/// <returns>object of QueryMultipleListsReturnItem composed of data to be returned</returns>
		Task<QueryMultipleListsReturnItem<TFirst, TSecond, TThird>> ExecuteQueryMultipleStoredProcedureAsync<TFirst, TSecond, TThird>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists);
	}
}
