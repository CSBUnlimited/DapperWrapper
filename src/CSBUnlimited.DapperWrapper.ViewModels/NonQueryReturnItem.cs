using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// Use when execute query with out quering from DB
    /// </summary>
    public class NonQueryReturnItem : IReturnItem
    {
        /// <summary>
        /// Status defined by the SP
        /// </summary>
        public int ReturnValue { get; set; }

        /// <summary>
        /// The number of rows affected
        /// </summary>
        public int EffectedRowsCount { get; set; }

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
