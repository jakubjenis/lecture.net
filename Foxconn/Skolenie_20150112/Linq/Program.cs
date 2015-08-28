using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;

namespace Linq
{
    //public class MyList : List<int>, IEnumerable<int>
    //{
    //    public IEnumerable<int> SelectItems(IEnumerable<int> list, int minValue)
    //    {
    //        var selectedItems = new List<int>();
    //        foreach (var item in list)
    //        {
    //            if (item > minValue) selectedItems.Add(item);
    //        }
    //        return selectedItems;
    //    }
    //}

    //Extension methods
    //http://msdn.microsoft.com/en-us/library/bb383977.aspx
    public static class EnumerableExtender
    {
        //public static IEnumerable<int> SelectItems(this IEnumerable<int> list, int minValue)
        //{
        //    var selectedItems = new List<int>();
        //    foreach (var item in list)
        //    {
        //        if (item > minValue) selectedItems.Add(item);
        //    }
        //    return selectedItems;
        //}

        //public static IEnumerable<int> SelectItemsDelitelne(this IEnumerable<int> list, int divider)
        //{
        //    var selectedItems = new List<int>();
        //    foreach (var item in list)
        //    {
        //        if (item % divider == 0) selectedItems.Add(item);
        //    }
        //    return selectedItems;
        //}

        public static IEnumerable<T> SuperWhere<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            var selectedItems = new List<T>();
            foreach (var item in list)
            {
                if (predicate(item)) selectedItems.Add(item);
            }
            return selectedItems;
        }

        public static IEnumerable<TResult> SuperSelect<T, TResult>(this IEnumerable<T> list, Func<T, TResult> selector)
        {
            var selectedItems = new List<TResult>();
            foreach (var item in list)
            {
                selectedItems.Add(selector(item));
            }
            return selectedItems;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>
            {
                1, 5, 4, 8, 19, 20, 14, 10, 6, 8
            };

            //foreach (var item in list.SelectItems(14))
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in list.SelectItemsDelitelne(2))
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in list.SuperWhere(DoBrutalVypocet))
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in list.SuperWhere(i => i % 2 == 0))
            //{
            //    Console.WriteLine(item);
            //}

            //var list2 = new List<string>() {"abs", "hello", "world"};
            //foreach (var item in list2.SuperWhere(s => s.Length > 5))
            //{
            //    Console.WriteLine(item);
            //}

            foreach (var item in list.Where(o => o % 2 == 0))
            {
                Console.WriteLine(item);
            }

            var customers = new List<Customer>
            {
                new Customer
                {
                    Id=1,
                    Name = "Fero",
                    LastName = "Hora",
                    Vek = 60,
                    Loans = new List<Loan>
                    {
                        new Loan
                        {
                            Amount =100
                        }
                    }
                },
                new Customer
                {
                    Id=2,
                    Name = "Janko",
                    LastName = "Hrasko",
                    Vek = 15
                },
                new Customer
                {
                    Id=3,
                    Name = "Milada",
                    LastName = "Horakova",
                    Vek = 72
                }
            };
            foreach (var item in customers.SuperSelect(o => o.LastName))
            {
                Console.WriteLine(item);
            }
            foreach (var item in customers.SuperSelect(o => o.Name))
            {
                Console.WriteLine(item);
            }
            foreach (var item in customers.SuperSelect<Customer, int>(o => o.Vek))
            {
                Console.WriteLine(item);
            }

            var transformedList = customers.SuperSelect(xxx => new
            {
                FullName = xxx.Name + " " + xxx.LastName
            });
            foreach (var item in transformedList)
            {
                Console.WriteLine(item.FullName);
            }

            var newList = customers
                .Where(o => o.LastName.Length > 5 && o.Vek < 60)
                .Where(o => true)
                .OrderByDescending(o => o.Vek)
                .Take(5)
                .Select(o => new
            {
                FullName = o.LastName + " " + o.Name
            });

            var result = from cust in customers
                         where cust.LastName.Length > 10 && cust.LastName.Length > 10
                         select new
                         {
                            FullName = cust.LastName + " " + cust.Name,
                            Vek = cust.Vek
                         };

            var result2 = from cust in customers
                where cust.LastName.Length > 10 && cust.LastName.Length > 10
                          select cust.LastName + " " + cust.Name;


            var listOut = new List<CustomerOut>
            {
                new CustomerOut
                {
                    FirstName = "Fero",
                    LastName = "Hora",
                    Vek = "60"
                },
                new CustomerOut
                {
                    FirstName = "Janko",
                    LastName = "Hrasko",
                    Vek = "50"
                },
                new CustomerOut
                {
                    FirstName = "Milada",
                    LastName = "Horakova",
                    Vek = "70"
                }
            };

            listOut.Select(o => new Customer
            {
                Name = o.FirstName,
                LastName = o.LastName,
                Vek = Int32.Parse(o.Vek)
            });


            //FILTERING
            var filteredList = customers.Where(o => o.LastName.Length > 5);
            filteredList = from cust in customers
                where cust.LastName.Length > 5
                select cust;

            //ORDERING
            filteredList.OrderBy(o => o.Vek)
                .ThenByDescending(o => o.LastName)
                .ThenByDescending(o => o.Name);

            filteredList = from cust in customers
                            orderby cust.Vek
                            select cust;

            filteredList.OrderByDescending(o => o.Vek);
            filteredList = from cust in customers
                           orderby cust.Vek, cust.LastName descending, cust.Name descending
                           select cust;

            //GROUPING
            var groupedList = filteredList
                .GroupBy(o => o.Vek)
                .OrderBy(o => o.Key)
                .Where(o => o.Key > 20)
                .Take(5);

            foreach (var groupedItem in groupedList)
            {
                Console.WriteLine(groupedItem.Key);
                foreach (var item in groupedItem)
                {
                    Console.WriteLine(item.LastName);
                }
            }

            groupedList = filteredList
                .GroupBy(o => o.Vek);
            groupedList = from cust in customers
                          group cust by cust.Vek;


            //JOINING
            var loans = new List<Loan>
            {
                new Loan
                {
                    CustomerId = 1,
                    Amount = 100
                },
                new Loan
                {
                    CustomerId = 2,
                    Amount = 200
                },
                new Loan
                {
                    CustomerId = 2,
                    Amount = 100
                },
                new Loan
                {
                    CustomerId = 2,
                    Amount = 200
                },
                new Loan
                {
                    CustomerId = 2,
                    Amount = 300
                }
            };
            var joinedList = customers.Join(loans, o => o.Id, o => o.CustomerId, (c, l) => new
            {
                CustomerName = c.Name,
                Amount = l.Amount
            }).ToList();

            var joinedList2 = from cust in customers
                join loan in loans on cust.Id equals loan.CustomerId
                select new
                {
                    Customer = cust,
                    Loan = loan
                };

            var loansList = customers.Select(o => o.Loans);
            foreach (var customerLoans in loansList)
            {
                foreach (var loan in customerLoans)
                {
                    Console.WriteLine(loan.Amount);
                }
            }

            var loans2 = customers.SelectMany(o => o.Loans);
            var averageDochodcaPozicka = 
                customers.Where(o => o.Vek > 70)
                .SelectMany(o => o.Loans)
                .Average(o => o.Amount);

            var averageAge = customers.Select(o => o.Vek).Average();
            var maxLastNameLength = customers.Select(o => o.LastName.Length).Max();

            var pocetDochodcov = customers.Select(o => o.Vek > 70).Count();

            var existujeDochodca = customers.Any(o => o.Vek > 70);
            var prvyDochodca = customers.First(o => o.Vek > 70);
            var prvyDochodca2 = customers.FirstOrDefault(o => o.Vek > 70);

            var vsetciSuDochodcovia = customers.All(o => o.Vek > 70);
        }

        private static bool DoBrutalVypocet(int i)
        {
            return true;
        }
    }

    public class CustomerOut
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Vek { get; set; }
    }

    public class Loan
    {
        public int CustomerId { get; set; }
        public double Amount { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public List<Loan> Loans { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Vek { get; set; }
    }
}
