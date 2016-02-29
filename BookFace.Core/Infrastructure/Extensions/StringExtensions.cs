using System;

namespace BookFace.Core.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string a, string text)
        {
            return a.Equals(text, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
