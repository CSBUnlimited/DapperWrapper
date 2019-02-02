using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    public class QueryMultipleReturnItem : IReturnItem
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
        /// List of data items. 
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// Initialize to default values
        /// </summary>
        public QueryMultipleReturnItem()
        {
            ReturnValue = -1;
            ReturnParametersCollection = new DbParameterList();
        }
    }
}
