using System.Collections.Generic;
using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// Use when execute query with single query with single row of data and query a list from DB
    /// </summary>
    /// <typeparam name="TFirst">First queried row data type</typeparam>
    /// <typeparam name="TSecond">Second List queries data type</typeparam>
    public class QueryMultipleSingleAndListReturnItem<TFirst, TSecond> : IReturnItem
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
        /// List of parent data items. 
        /// </summary>
        public TFirst FirstItem { get; set; }

        /// <summary>
        /// List of children data items. 
        /// </summary>
        public IEnumerable<TSecond> SecondCollection { get; set; }

        /// <summary>
        /// Initialize to default values
        /// </summary>
        public QueryMultipleSingleAndListReturnItem()
        {
            ReturnParametersCollection = new DbParameterList();
            SecondCollection = new List<TSecond>();
        }
    }
}
