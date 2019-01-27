using System;
using System.Data;
using System.Reflection;

namespace CSBUnlimited.DapperWrapper
{
    public class DbDataParameterBuilder : IDbDataParameterBuilder
    {
        /// <summary>
        /// Extracts parameters from the model
        /// </summary>
        /// <param name="model">Model to be parsed</param>
        /// <returns>List of parameters built from the model properties</returns>
        public IDbParameterList GetParameters(object model)
        {
            Type modelT = model.GetType();
            IDbParameterList parametersCollection = new DbParameterList();

            foreach (PropertyInfo property in modelT.GetProperties())
            {
                DbDataParameterMeta attribute = property.GetCustomAttribute<DbDataParameterMeta>();

                if (attribute == null || attribute.Visible)
                {
                    DbDataParameter parameter = new DbDataParameter()
                    {
                        Value = property.GetValue(model),
                        ParameterName = (attribute == null || string.IsNullOrEmpty(attribute.ParameterName))
                            ? $"@{property.Name}"
                            : $"@{attribute.ParameterName}"
                    };

                    if (attribute != null && attribute.DbType != DbType.Object)
                        parameter.DbType = attribute.DbType;

                    if (attribute != null && attribute.Direction != ParameterDirection.Input)
                        parameter.Direction = attribute.Direction;

                    if (attribute != null && attribute.Size != 0)
                        parameter.Size = attribute.Size;

                    parametersCollection.Add(parameter);
                }
            }
            return parametersCollection;
        }
    }
}
