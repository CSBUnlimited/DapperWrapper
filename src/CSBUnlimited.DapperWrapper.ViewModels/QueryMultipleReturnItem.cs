using CSBUnlimited.DapperWrapper.Core;
using System.Collections.Generic;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// Use when execute query with multiple(any number of) queries from DB.
    /// Returned IEnumerable of dynamic type. 
    /// </summary>
    public class QueryMultipleReturnItem : IReturnItem
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
        /// List of dynamic data items. 
        /// </summary>
        public IEnumerable<dynamic> DataLists { get; set; }

        /// <summary>
        /// Initialize to default values
        /// </summary>
        public QueryMultipleReturnItem()
        {
            ReturnParametersCollection = new DbParameterList();
        }
    }
}
