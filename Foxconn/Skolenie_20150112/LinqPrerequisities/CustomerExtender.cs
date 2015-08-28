using System;
using System.Collections.Generic;
using LinqPrerequisities.Lib;

namespace LinqPrerequisities
{
    public static class CustomerExtender
    {
        public static int GetVek(this Customer customer)
        {
            return customer.DateOfBirth.Year - DateTime.Now.Year;
        }

        public static void Vypis<T>(this IEnumerable<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}