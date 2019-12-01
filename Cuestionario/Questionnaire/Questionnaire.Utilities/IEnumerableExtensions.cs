using System;
using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.Utilities
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            Random r = new Random();
            return source.OrderBy(x => r.Next());
        }
    }
}
