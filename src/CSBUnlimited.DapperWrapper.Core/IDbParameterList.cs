using System.Collections.Generic;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// DbParameterList interface
    /// </summary>
    public interface IDbParameterList : IList<DbDataParameter>
    {
        /// <summary>
        /// Get or Set using parameter name
        /// </summary>
        /// <param name="parameterName">Parameter name</param>
        /// <returns>DbDataParameter</returns>
        DbDataParameter this[string parameterName] { get; set; }

        /// <summary>
        /// Removes the first occurrence of a specific object using parameterName
        /// </summary>
        /// <param name="parameterName">Parameter Name</param>
        /// <returns>Boolean</returns>
        bool Remove(string parameterName);
    }
}
