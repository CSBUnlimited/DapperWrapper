using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    public class NonQueryReturnItem : IReturnItem
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
        /// Initialize to default values
        /// </summary>
        public NonQueryReturnItem()
        {
            ReturnValue = -1;
            ReturnParametersCollection = new DbParameterList();
        }
    }
}
