using System;
using System.Collections.Generic;
using System.Linq;
using BookFace.Core.Infrastructure.Extensions;

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
        private readonly Dictionary<Type, Schema> _schemas = new Dictionary<Type, Schema>();

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

        private Schema GetSchema<T>()
        {
            Schema schema;
            var type = typeof(T);

            if (!_schemas.TryGetValue(type, out schema))
            {
                schema = new Schema(type);
                _schemas.Add(type, schema);
            }

            return schema;
        }

        public virtual void Insert<T>(T obj)
        {
            var list = GetListFor<T>();
            var clone = obj.Clone();
            list.Add(clone);
        }

        public virtual IEnumerable<T> Select<T>()
        {
            return GetListFor<T>().Select(x => x.Clone());
        }

        public virtual void Update<T>(T obj)
        {
            var list = GetListFor<T>();
            var schema = GetSchema<T>();

            Func<T, object> getId = o => schema.Identity.GetValue(o);

            var id = getId(obj);

            for (var index = 0; index < list.Count; index++)
            {
                var currentId = getId(list[index]);

                if (currentId.Equals(id))
                {
                    list[index] = obj.Clone();
                    return;
                }
            }
        }
    }
}
