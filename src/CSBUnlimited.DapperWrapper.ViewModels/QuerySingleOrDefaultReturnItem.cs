using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// Wraps the returned items for general query which returns single data row
    /// </summary>
    /// <typeparam name="T">Queried object type</typeparam>
    public class QuerySingleOrDefaultReturnItem<T> : IReturnItem
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
        /// Data item which returns from teh SP. 
        /// </summary>
        public T DataItem { get; set; }

        /// <summary>
        /// Initialize to default values
        /// </summary>
        public QuerySingleOrDefaultReturnItem()
        {
            ReturnValue = -1;
            ReturnParametersCollection = new DbParameterList();
        }
    }
}
