using System;
using System.Collections.Generic;
using System.Linq;

namespace SiphoinUnityHelpers.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
        {
            System.Random random = new System.Random();

            return collection.OrderBy(x => random.Next());
        }

        public static T GetRandomElement<T>(this IEnumerable<T> source)
        {
            return source.ElementAt(UnityEngine.Random.Range(0, source.Count()));
        }
    }
    }
}
