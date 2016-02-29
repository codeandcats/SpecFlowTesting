using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace BookFace.Core.Infrastructure.Extensions
{
    public static class ObjectHelper
    {
        public static T Clone<T>(this T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
    }
}
