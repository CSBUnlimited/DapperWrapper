using System.Collections.Generic;
using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// Use when execute query with single query from DB
    /// </summary>
    /// <typeparam name="T">Queried list object data type</typeparam>
    public class QueryReturnItem<T> : IReturnItem
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
        /// List of data items. 
        /// </summary>
        public IEnumerable<T> DataItemList { get; set; }

        /// <summary>
        /// Initialize to default values
        /// </summary>
        public QueryReturnItem()
        {
            ReturnParametersCollection = new DbParameterList();
        }
    }
}
