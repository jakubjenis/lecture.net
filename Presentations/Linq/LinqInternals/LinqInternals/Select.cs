using System;
using System.Collections.Generic;

namespace LinqInternals
{
    public static partial class Enumerable
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            return SelectInner(source, selector);
        }

        private static IEnumerable<TResult> SelectInner<TSource, TResult>(IEnumerable<TSource> source, 
            Func<TSource, TResult> selector)
        {
            foreach (TSource item in source)
            {
                yield return selector(item);
            }
        }
    }
}
