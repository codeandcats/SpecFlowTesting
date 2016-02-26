using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow.Assist;

namespace BookFace.Specs.Infrastructure.ValueRetrievers
{
    public class FriendNamesValueRetriever : IValueRetriever
    {
        public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return propertyType == typeof(List<string>);
        }

        public object Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return keyValuePair.Value.Split(',').Select(n => n.Trim()).ToList();
        }
    }
}
