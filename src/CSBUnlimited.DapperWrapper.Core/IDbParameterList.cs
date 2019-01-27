using System.Collections.Generic;

namespace CSBUnlimited.DapperWrapper
{
    public interface IDbParameterList : IList<DbDataParameter>
    {
        DbDataParameter this[string parameterName] { get; set; }

        bool Remove(string parameterName);
    }
}
