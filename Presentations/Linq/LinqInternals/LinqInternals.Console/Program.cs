using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqInternals.Out
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> {2, 25, 16, 6, 8};
            var result = from number in numbers
                         where number > 10
                         select number * 2;

            var result2 = numbers.Where(o => o > 10).Where(o => o%2 == 0);

            numbers.Clear();

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }

        }
    }
}
