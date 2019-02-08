using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// Use when execute query with single row that select first column of data from DB
    /// </summary>
    /// <typeparam name="T">Queried scalar value type</typeparam>
    public class QueryScalarReturnItem<T> : IReturnItem
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
        /// Data item which returns from the Query
        /// </summary>
        public T ScalarDataItem { get; set; }

        /// <summary>
        /// Initialize to default values
        /// </summary>
        public QueryScalarReturnItem()
        {
            ReturnParametersCollection = new DbParameterList();
        }
    }
}
