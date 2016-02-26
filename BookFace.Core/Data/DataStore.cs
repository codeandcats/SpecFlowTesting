using System;
using System.Collections.Generic;

namespace BookFace.Core.Data
{
    public interface IDataStore
    {
        void Insert<T>(T obj);
        IEnumerable<T> Select<T>();
    }

    public class DataStore : IDataStore
    {
        private readonly Dictionary<Type, object> _lists = new Dictionary<Type, object>();

        private List<T> GetListFor<T>()
        {
            var type = typeof(T);
            object result;

            if (!_lists.TryGetValue(type, out result))
            {
                var listType = typeof(List<>).MakeGenericType(type);
                result = Activator.CreateInstance(listType);
                _lists.Add(type, result);
            }

            return (List<T>)result;
        }

        public void Insert<T>(T obj)
        {
            GetListFor<T>().Add(obj);
        }

        public IEnumerable<T> Select<T>()
        {
            return GetListFor<T>();
        }
    }
}
