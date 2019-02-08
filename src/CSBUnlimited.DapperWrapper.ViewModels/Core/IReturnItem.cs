namespace CSBUnlimited.DapperWrapper.Core
{
    /// <summary>
    /// Basic items required for return item.
    /// Only for internal usage not for external usage
    /// </summary>
    internal interface IReturnItem
    {
        /// <summary>
        /// SReturn value that return from stored procedure
        /// </summary>
        int ReturnValue { get; set; }

        /// <summary>
        /// Returned parameters list
        /// </summary>
        IDbParameterList ReturnParametersCollection { get; set; }
    }
}
