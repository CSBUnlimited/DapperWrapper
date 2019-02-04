using System.Collections.Generic;
using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// Use when execute query with three queries from DB.
    /// </summary>
    /// <typeparam name="TFirst">First queried list data type</typeparam>
    /// <typeparam name="TSecond">Second queried list data type</typeparam>
    /// <typeparam name="TThird">Third queried list data type</typeparam>
    public class QueryMultipleListsReturnItem<TFirst, TSecond, TThird> : IReturnItem
    {
        /// <summary>
        /// Status defined by the SP
        /// </summary>
        public int ReturnValue { get; set; }

        /// <summary>
        /// Returned parameters list
        /// </summary>
        public IDbParameterList ReturnParametersCollection { get; set; }

        /// <summary>
        /// List of data items. 
        /// </summary>
        public IEnumerable<TFirst> FirstCollection { get; set; }

        /// <summary>
        /// List of data items. 
        /// </summary>
        public IEnumerable<TSecond> SecondCollection { get; set; }

        /// <summary>
        /// List of data items. 
        /// </summary>
        public IEnumerable<TThird> ThirdCollection { get; set; }


        /// <summary>
        /// Initialize to default values
        /// </summary>
        public QueryMultipleListsReturnItem()
        {
            ReturnParametersCollection = new DbParameterList();
            FirstCollection = new List<TFirst>();
            SecondCollection = new List<TSecond>();
            ThirdCollection = new List<TThird>();
        }
    }
}
