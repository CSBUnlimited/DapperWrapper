using System.Collections.Generic;
using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    public class QueryMultipleListsReturnItem<TFirst, TSecond, TThird> : IReturnItem
    {
        /// <summary>
        /// Status defined by the SP
        /// </summary>
        public long ReturnValue { get; set; }

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
            ReturnValue = -1;
            ReturnParametersCollection = new DbParameterList();
            FirstCollection = new List<TFirst>();
            SecondCollection = new List<TSecond>();
            ThirdCollection = new List<TThird>();
        }
    }
}
