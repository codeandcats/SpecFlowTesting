using System;
using System.Reflection;
using System.Linq;
using BookFace.Core.Infrastructure.Extensions;

namespace BookFace.Core.Data
{
    public class Schema
    {
        public PropertyInfo Identity { get; set; }

        public Schema(Type type)
        {
            Identity = type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(m => m.Name.EqualsIgnoreCase("Id"));
        }
    }
}
