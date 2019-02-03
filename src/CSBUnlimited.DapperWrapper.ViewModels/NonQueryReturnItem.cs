using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    public class NonQueryReturnItem : IReturnItem
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
        /// Initialize to default values
        /// </summary>
        public NonQueryReturnItem()
        {
            ReturnParametersCollection = new DbParameterList();
        }
    }
}
