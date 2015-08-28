using System;
using System.Collections.Generic;

namespace LinqInternals
{
    public static partial class Enumerable
    {


        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");

            return WhereInner(source, predicate);
        }

        private static IEnumerable<TSource> WhereInner<TSource>(
            this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }


















        //Naive implementation with parameter handling
        
     
        //public static IEnumerable<TSource> Where<TSource>
        //    (this IEnumerable<TSource> source,
        //        Func<TSource, bool> predicate)
        //{
        //    if (source == null) throw new ArgumentNullException("source");
        //    if (predicate == null) throw new ArgumentNullException("predicate");

        //    var list = new List<TSource>();
        //    foreach (TSource item in source)
        //    {
        //        if (predicate(item))
        //        {
        //            list.Add(item);
        //        }
        //    }
        //    return list;   
        //}


        //Deferred execution with deferred parameter handling

        //public static IEnumerable<TSource> Where<TSource>
        //    (this IEnumerable<TSource> source,
        //        Func<TSource, bool> predicate)
        //{
        //    if (source == null) throw new ArgumentNullException("source");
        //    if (predicate == null) throw new ArgumentNullException("predicate");

        //    foreach (TSource item in source)
        //    {
        //        if (predicate(item))
        //        {
        //            yield return item;
        //        }
        //    }
        //}

        //Correct

        //public static IEnumerable<TSource> Where<TSource>(
        //    this IEnumerable<TSource> source,
        //    Func<TSource, bool> predicate)
        //{
        //    if (source == null) throw new ArgumentNullException("source");
        //    if (predicate == null) throw new ArgumentNullException("predicate");
            
        //    return WhereImpl(source, predicate);
        //}

        //private static IEnumerable<TSource> WhereImpl<TSource>(
        //    this IEnumerable<TSource> source,
        //    Func<TSource, bool> predicate)
        //{
        //    foreach (TSource item in source)
        //    {
        //        if (predicate(item))
        //        {
        //            yield return item;
        //        }
        //    }
        //}
    }
}
