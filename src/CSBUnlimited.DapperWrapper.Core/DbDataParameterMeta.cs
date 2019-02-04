using System;
using System.Data;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// Used to apply the visibility in conversion Model => DbDataParameter list 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DbDataParameterMeta : Attribute
    {
        #region Public Properties
        /// <summary>
        /// Sets and gets the visibility in the parameter list
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Sets or gets the name of the parameter
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// Sets or gets the parameter db type
        /// </summary>
        public DbType DbType { get; set; }

        /// <summary>
        /// Sets or gets the parameter db type
        /// </summary>
        public ParameterDirection Direction { get; set; }

        /// <summary>
        /// Sets or gets the parameter size
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// DbDataParameterMeta - Constructor
        /// </summary>
        public DbDataParameterMeta()
        {
            Visible = true;
            DbType = DbType.Object;
            Direction = ParameterDirection.Input;
        }
        #endregion
    }
}
