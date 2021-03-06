﻿using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// Use when execute query with out querying from DB.
    /// Best for Inserts, Updates and Deletes due to it returns the effected row count.
    /// </summary>
    public class NonQueryReturnItem : IReturnItem
    {
        /// <summary>
        /// Return value that return from stored procedure
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
