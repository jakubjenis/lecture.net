using System;
using System.Collections.Generic;

namespace LinqInternals
{
    public static partial class Enumerable
    {
        //public static IEnumerable<TResult> Empty<TResult>()
        //{
        //    yield break;
        //}

        //public static IEnumerable<TResult> Repeat<TResult>(TResult item, int count)
        //{
        //    if(count < 0) throw new ArgumentOutOfRangeException("count");
        //    while (count-- > 0)
        //    {
        //        yield return item;
        //    }
        //}

        //public static IEnumerable<int> Range(int start, int count)
        //{
        //    for (int i = start; i < start + count; i++)
        //    {
        //        yield return i;
        //    }
        //}


        public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
        {
            foreach (var item in source)
            {
                if(count == 0) yield break;
                count--;
                yield return item;
            }
        }

        public static IEnumerable<TResult> Generate<TResult>(TResult first, Func<TResult, TResult> step)
        {
            var current = first;
            while (true)
            {
                yield return current;
                current = step(first);
            }
        }

        public static IEnumerable<TResult> Empty<TResult>()
        {
            return Repeat(default(TResult), 0);
        }

        public static IEnumerable<TResult> Repeat<TResult>(TResult item, int count)
        {
            return Generate(item, o => o).Take(count);
        }

        public static IEnumerable<int> Range(int start, int count)
        {
            return Generate(start, o => o+1).Take(count);
        }
    }
}
