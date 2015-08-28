using System;
using System.Collections.Generic;

namespace LinqIngredients
{
    namespace ExtensionMethods
    {

        public static class Extensions
        {
            public static int WordCount(this String str)
            {
                return str.Split(new char[] { ' ', '.', '?' },
                                 StringSplitOptions.RemoveEmptyEntries).Length;

            }

            public static void Vypis<T>(this IEnumerable<T> source)
            {
                foreach (var item in source)
                {
                    Console.Write(item);
                }
            }

            public static void Tmp()
            {
                var list = new List<string>(){};
                list.Vypis();
            }
        }
    }
}
