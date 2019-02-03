﻿using System.Collections.Generic;
using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    public class QueryReturnItem<T> : IReturnItem
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
        /// List of data items. 
        /// </summary>
        public IEnumerable<T> DataItemList { get; set; }

        /// <summary>
        /// Initialize to default values
        /// </summary>
        public QueryReturnItem()
        {
            ReturnParametersCollection = new DbParameterList();
        }
    }
}
