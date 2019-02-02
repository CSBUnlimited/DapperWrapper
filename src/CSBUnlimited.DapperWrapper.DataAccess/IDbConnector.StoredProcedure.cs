using System;

namespace CSBUnlimited.DapperWrapper
{
    public partial interface IDbConnector : IDisposable
    {
        /// <summary>
        /// Executes non-query stored procedures. Ex: Insert, Update, Delete
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
        /// <returns>object of NonQueryReturnItem composed of data to be returned</returns>
        NonQueryReturnItem ExecuteNonQueryStoredProcedure(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true);

        /// <summary>
        /// Executes query stored procedure for a list. Ex: Select
        /// </summary>
        /// <typeparam name="T">Type of the list of returned model</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
        /// <returns>object of QueryReturnItem composed of data to be returned</returns>
        QueryReturnItem<T> ExecuteQueryStoredProcedure<T>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true);

        /// <summary>
        /// Executes query stored procedures for single data record. Ex: Select 1 record
        /// </summary>
        /// <typeparam name="T">Type of the returned model</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
        /// <returns>object of QuerySingleOrDefaultReturnItem composed of data to be returned</returns>
        QuerySingleOrDefaultReturnItem<T> ExecuteQueryStoredProcedureSingleOrDefault<T>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true);

        /// <summary>
        /// Executes query stored procedures for multiple datasets. Ex: Parent child
        /// </summary>        
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
        /// <returns>object of QueryMultipleReturnItem composed of data to be returned</returns>
        QueryMultipleReturnItem ExecuteQueryMultipleStoredProcedure(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true);

        /// <summary>
        /// Executes query stored procedures for item + list.
        /// </summary>
        /// <typeparam name="TFirst">Type of first item</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
        /// <returns>object of QueryMultipleListsReturnItem composed of data to be returned</returns>
        QueryMultipleSingleAndListReturnItem<TFirst, TSecond> QueryMultipleSingleWithListStoredProcedure<TFirst, TSecond>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true);

        /// <summary>
        /// Executes query stored procedures for 2 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
        /// <returns>object of QueryMultipleListsReturnItem composed of data to be returned</returns>
        QueryMultipleListsReturnItem<TFirst, TSecond> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true);

        /// <summary>
        /// Executes query stored procedures for 3 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
        /// <returns>object of QueryMultipleListsReturnItem composed of data to be returned</returns>
        QueryMultipleListsReturnItem<TFirst, TSecond, TThird> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true);

        /// <summary>
        /// Executes query stored procedures for 4 lists.
        /// </summary>
        /// <typeparam name="TFirst">Type of first list</typeparam>
        /// <typeparam name="TSecond">Type of second list</typeparam>
        /// <typeparam name="TThird">Type of third list</typeparam>
        /// <typeparam name="TForth">Type of forth list</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure</param>
        /// <param name="parametersCollection">Input/Output parameter list</param>
        /// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
        /// <returns>object of QueryMultipleListsReturnItem composed of data to be returned</returns>
        QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird, TForth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true);

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
        /// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
        /// <returns>object of QueryMultipleListsReturnItem composed of data to be returned</returns>
        QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird, TForth, TFifth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true);

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
        /// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
        /// <returns>object of QueryMultipleListsReturnItem composed of data to be returned</returns>
        QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird, TForth, TFifth, TSixth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true);

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
        /// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
        /// <returns>object of QueryMultipleListsReturnItem composed of data to be returned</returns>
        QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true);

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
        /// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
        /// <returns>object of QueryMultipleListsReturnItem composed of data to be returned</returns>
        QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true);

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
        /// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
        /// <returns>object of QueryMultipleListsReturnItem composed of data to be returned</returns>
        QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true);

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
        /// <param name="isReturnValueExists">Indicates whether return values RETURN_VALUE, needed to be included</param>
        /// <returns>object of QueryMultipleListsReturnItem composed of data to be returned</returns>
        QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth> ExecuteQueryMultipleStoredProcedure<TFirst, TSecond, TThird, TForth, TFifth, TSixth, TSeventh, TEighth, TNineth, TTenth>(string storedProcedureName, IDbParameterList parametersCollection, bool isReturnValueExists = true);
    }
}
