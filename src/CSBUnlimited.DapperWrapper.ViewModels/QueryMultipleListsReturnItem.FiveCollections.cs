using System.Collections.Generic;
using CSBUnlimited.DapperWrapper.Core;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// Use when execute query with five queries from DB.
    /// </summary>
    /// <typeparam name="TFirst">First queried list data type</typeparam>
    /// <typeparam name="TSecond">Second queried list data type</typeparam>
    /// <typeparam name="TThird">Third queried list data type</typeparam>
    /// <typeparam name="TFourth">Forth queried list data type</typeparam>
    /// <typeparam name="TFifth">Fifth queried list data type</typeparam>
    public class QueryMultipleListsReturnItem<TFirst, TSecond, TThird, TFourth, TFifth> : IReturnItem
    {
        /// <summary>
        /// Return value that return from stored procedure
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
        /// List of data items. 
        /// </summary>
        public IEnumerable<TThird> ThirdCollection { get; set; }

        /// <summary>
        /// List of data items. 
        /// </summary>
        public IEnumerable<TFourth> FourthCollection { get; set; }


        /// <summary>
        /// List of data items. 
        /// </summary>
        public IEnumerable<TFifth> FifthCollection { get; set; }

        /// <summary>
        /// Initialize to default values
        /// </summary>
        public QueryMultipleListsReturnItem()
        {
            ReturnParametersCollection = new DbParameterList();
            FirstCollection = new List<TFirst>();
            SecondCollection = new List<TSecond>();
            ThirdCollection = new List<TThird>();
            FourthCollection = new List<TFourth>();
            FifthCollection = new List<TFifth>();
        }
    }
}
