using System;
using System.Collections.Generic;
using System.Linq;

namespace SiphoinUnityHelpers.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
        {
            Random random = new Random();

            return collection.OrderBy(x => random.Next());
        }
    }
}
