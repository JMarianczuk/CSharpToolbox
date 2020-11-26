using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpToolbox.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool None<TElement>(this IEnumerable<TElement> source, Func<TElement, bool> predicate)
        {
            return !source.Any(predicate);
        }

        public static IEnumerable<TElement> WhereNot<TElement>(this IEnumerable<TElement> source,
            Func<TElement, bool> predicate)
        {
            return source.Where(x => !predicate(x));
        }
    }
}