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

        public static T GetRandomElement<T>(this IEnumerable<T> source)
        {
            List<T> elements = source.ToList();
            int randomIndex = Random.Range(0, elements.Count);
            return elements[randomIndex];
        }
    }
    }
}
