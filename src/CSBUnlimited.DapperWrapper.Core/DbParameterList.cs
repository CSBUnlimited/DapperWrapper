using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSBUnlimited.DapperWrapper
{
    /// <summary>
    /// Collection of Db Parameters
    /// </summary>
    public class DbParameterList : IDbParameterList
    {
        private readonly IList<DbDataParameter> _parameterCollection;

        /// <summary>
        /// Constructor - Can use for get the parameter list from an object
        /// </summary>
        /// <param name="model">Object that need to get parameter list</param>
        public DbParameterList(object model)
        {
            _parameterCollection = new DbDataParameterBuilder().GetParameters(model);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public DbParameterList()
        {
            _parameterCollection = new List<DbDataParameter>();
        }

        /// <summary>
        /// Get or Set using parameter name
        /// </summary>
        /// <param name="parameterName">Parameter name</param>
        /// <returns>DbDataParameter</returns>
        public DbDataParameter this[string parameterName]
        {
            get
            {
                return _parameterCollection.Single(p => p.ParameterName.Equals(parameterName));
            }
            set
            {
                _parameterCollection[_parameterCollection.IndexOf(_parameterCollection.Single(p => p.ParameterName.Equals(parameterName)))] = value;
            }
        }

        /// <summary>
        /// Get or Set using the index
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>DbDataParameter</returns>
        public DbDataParameter this[int index]
        {
            get => _parameterCollection[index];
            set => _parameterCollection[index] = value;
        }

        /// <summary>
        /// To get the parameter count
        /// </summary>
        public int Count => _parameterCollection.Count;

        /// <summary>
        /// Get parameter is readonly
        /// </summary>
        public bool IsReadOnly => _parameterCollection.IsReadOnly;

        /// <summary>
        /// Add a new DbDataParameter
        /// </summary>
        /// <param name="item">New DbDataParameter</param>
        public void Add(DbDataParameter item)
        {
            _parameterCollection.Add(item);
        }

        /// <summary>
        /// Clear all parameters
        /// </summary>
        public void Clear()
        {
            _parameterCollection.Clear();
        }

        /// <summary>
        /// Check DbDataParameter is already exists
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(DbDataParameter item)
        {
            return _parameterCollection.Contains(item);
        }

        /// <summary>
        /// Copy to a DbDataParameter array
        /// </summary>
        /// <param name="array">Array that need to copy</param>
        /// <param name="arrayIndex">Index need to start</param>
        public void CopyTo(DbDataParameter[] array, int arrayIndex)
        {
            _parameterCollection.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Get Enumerator from parameter collection
        /// </summary>
        /// <returns>IEnumerator of DbDataParameters</returns>
        public IEnumerator<DbDataParameter> GetEnumerator()
        {
            return _parameterCollection.GetEnumerator();
        }

        /// <summary>
        /// Find the index of a DbDataParameter
        /// </summary>
        /// <param name="item">DbDataParameter</param>
        /// <returns>Index</returns>
        public int IndexOf(DbDataParameter item)
        {
            return _parameterCollection.IndexOf(item);
        }

        /// <summary>
        /// Insert a DbDataParameter to a index
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="item">DbDataParameter</param>
        public void Insert(int index, DbDataParameter item)
        {
            _parameterCollection.Insert(index, item);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object using DbDataParameter
        /// </summary>
        /// <param name="item">DbDataParameter</param>
        /// <returns>Boolean</returns>
        public bool Remove(DbDataParameter item)
        {
            return _parameterCollection.Remove(item);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object using parameterName
        /// </summary>
        /// <param name="parameterName">Parameter Name</param>
        /// <returns>Boolean</returns>
        public bool Remove(string parameterName)
        {
            return _parameterCollection.Remove(_parameterCollection.Single(p => p.ParameterName.Equals(parameterName)));
        }

        /// <summary>
        /// Remove specific object using index
        /// </summary>
        /// <param name="index">Index</param>
        public void RemoveAt(int index)
        {
            _parameterCollection.RemoveAt(index);
        }

        /// <summary>
        /// Get Enumerator of parameter collection
        /// </summary>
        /// <returns>Enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _parameterCollection.GetEnumerator();
        }
    }
}
