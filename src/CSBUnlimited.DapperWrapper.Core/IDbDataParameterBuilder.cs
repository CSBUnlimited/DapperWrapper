namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// Builds db parameters using the model
    /// </summary>
    public interface IDbDataParameterBuilder
    {
        /// <summary>
        /// Extracts parameters from the model
        /// </summary>
        /// <param name="model">Model to be parsed</param>
        /// <returns>List of parameters built from the model properties</returns>
        IDbParameterList GetParameters(object model);
    }
}
