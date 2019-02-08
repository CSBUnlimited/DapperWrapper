using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// Use when execute query with single query with single row of data from DB
    /// </summary>
    /// <typeparam name="T">Queried object type</typeparam>
    public class QuerySingleOrDefaultReturnItem<T> : IReturnItem
    {
        /// <summary>
        /// Return value that return from stored procedure
        /// </summary>
        public int ReturnValue { get; set; }

        /// <summary>
        /// Returned parameters list
        /// </summary>
        public IDbParameterList ReturnParametersCollection { get; set; }

        /// <summary>
        /// Data item which returns from the SP. 
        /// </summary>
        public T DataItem { get; set; }

        /// <summary>
        /// Initialize to default values
        /// </summary>
        public QuerySingleOrDefaultReturnItem()
        {
            ReturnParametersCollection = new DbParameterList();
        }
    }
}
