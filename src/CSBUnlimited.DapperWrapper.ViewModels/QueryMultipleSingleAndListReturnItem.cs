using System.Collections.Generic;
using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    public class QueryMultipleSingleAndListReturnItem<TFirst, TSecond> : IReturnItem
    {
        /// <summary>
        /// Status defined by the SP
        /// </summary>
        public short ReturnValue { get; set; }

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
            ReturnValue = -1;
            ReturnParametersCollection = new DbParameterList();
            SecondCollection = new List<TSecond>();
        }
    }
}
