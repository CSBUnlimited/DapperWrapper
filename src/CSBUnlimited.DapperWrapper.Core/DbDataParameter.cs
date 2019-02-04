using System.Data;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// DB Data Parameter
    /// </summary>
    public class DbDataParameter : IDbDataParameter
    {
        /// <summary>
        /// DbType of the parameter
        /// </summary>
        public DbType DbType { get; set; }

        /// <summary>
        /// Direction of the parameter
        /// </summary>
        public ParameterDirection Direction { get; set; }

        /// <summary>
        /// Is Nullable of the parameter
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// Name of the parameter
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// Precision of the parameter
        /// </summary>
        public string SourceColumn { get; set; }

        /// <summary>
        /// Source Version of the parameter
        /// </summary>
        public DataRowVersion SourceVersion { get; set; }

        /// <summary>
        /// Value of the parameter
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Precision of the parameter
        /// </summary>
        public byte Precision { get; set; }

        /// <summary>
        /// Scale of the parameter
        /// </summary>
        public byte Scale { get; set; }

        /// <summary>
        /// Size of the parameter
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DbDataParameter()
        {
            DbType = DbType.Object;
            Direction = ParameterDirection.Input;
        }

        /// <summary>
        /// Default constructor to be used
        /// </summary>
        /// <param name="parameterName">Name of the parameter. ex: @Name</param>
        /// <param name="value">Value of the parameter</param>
        /// <param name="dbType">Default: DbType.Object, Database type of the parameter</param>
        /// <param name="direction">Default: ParameterDirection.Input, Direction of the parameter. ex: Input/Output</param>
        public DbDataParameter(string parameterName, object value, DbType dbType = DbType.Object, ParameterDirection direction = ParameterDirection.Input)
        {
            ParameterName = parameterName;
            Value = value;
            DbType = dbType;
            Direction = direction;
        }
    }
}
