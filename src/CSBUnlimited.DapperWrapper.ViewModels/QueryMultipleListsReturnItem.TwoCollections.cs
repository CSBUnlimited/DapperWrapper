﻿using System.Collections.Generic;
using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    public class QueryMultipleListsReturnItem<TFirst, TSecond> : IReturnItem
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
        /// List of parent data items. 
        /// </summary>
        public IEnumerable<TFirst> FirstCollection { get; set; }

        /// <summary>
        /// List of children data items. 
        /// </summary>
        public IEnumerable<TSecond> SecondCollection { get; set; }


        /// <summary>
        /// Initialize to default values
        /// </summary>
        public QueryMultipleListsReturnItem()
        {
            ReturnParametersCollection = new DbParameterList();
            FirstCollection = new List<TFirst>();
            SecondCollection = new List<TSecond>();
        }
    }
}
