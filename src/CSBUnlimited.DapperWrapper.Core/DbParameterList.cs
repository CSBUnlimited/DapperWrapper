using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSBUnlimited.DapperWrapper
{
    public class DbParameterList : IDbParameterList
    {
        private readonly IList<DbDataParameter> _parameterCollection;
        public DbParameterList(object model)
        {
            _parameterCollection = new DbDataParameterBuilder().GetParameters(model);
        }

        public DbParameterList()
        {
            _parameterCollection = new List<DbDataParameter>();
        }

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

        public DbDataParameter this[int index]
        {
            get => _parameterCollection[index];
            set => _parameterCollection[index] = value;
        }

        public int Count => _parameterCollection.Count;

        public bool IsReadOnly => _parameterCollection.IsReadOnly;

        public void Add(DbDataParameter item)
        {
            _parameterCollection.Add(item);
        }

        public void Clear()
        {
            _parameterCollection.Clear();
        }

        public bool Contains(DbDataParameter item)
        {
            return _parameterCollection.Contains(item);
        }

        public void CopyTo(DbDataParameter[] array, int arrayIndex)
        {
            _parameterCollection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<DbDataParameter> GetEnumerator()
        {
            return _parameterCollection.GetEnumerator();
        }

        public int IndexOf(DbDataParameter item)
        {
            return _parameterCollection.IndexOf(item);
        }

        public void Insert(int index, DbDataParameter item)
        {
            _parameterCollection.Insert(index, item);
        }

        public bool Remove(DbDataParameter item)
        {
            return _parameterCollection.Remove(item);
        }

        public bool Remove(string parameterName)
        {
            return _parameterCollection.Remove(_parameterCollection.Single(p => p.ParameterName.Equals(parameterName)));
        }

        public void RemoveAt(int index)
        {
            _parameterCollection.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _parameterCollection.GetEnumerator();
        }
    }
}
