using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LinqDeffered
{
    public static class EnumerableExtender
    {
        public static IEnumerable<T> EagerWhere<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            var selectedItems = new List<T>();
            foreach (var item in list)
            {
                if (predicate(item)) selectedItems.Add(item);
            }
            return selectedItems;
        }

        //Deffered execution
        public static IEnumerable<T> DefferedWhere<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item)) yield return item;
            }
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
        public static IEnumerable<string> CreateList()
        {
            yield return "prvy";
            yield return "druhy";
            yield return "treti";
        }

        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id=1,
                    Name = "Fero",
                    LastName = "Hora",
                    Vek = 60,
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

            var eagerCustomers = customers.EagerWhere(o =>
            {
                Console.WriteLine("Pridavam item {0}", o.LastName);
                return o.Vek > 50;
            });

            customers.Add(new Customer
            {
                Id = 4,
                Name = "Frantisek",
                LastName = "Vesely",
                Vek = 80
            });

            Console.WriteLine("Dochodcovia:");
            foreach (var customer in eagerCustomers)
            {
                Console.WriteLine(customer.Name + " " + customer.LastName);
            }

            customers = new List<Customer>
            {
                new Customer
                {
                    Id=1,
                    Name = "Fero",
                    LastName = "Hora",
                    Vek = 60,
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
            Console.WriteLine();
            Console.WriteLine();

            var filteredCustomers = customers.DefferedWhere(o =>
            {
                Console.WriteLine("Pridavam item {0}", o.LastName);
                return o.Vek > 50;
            });

            Console.WriteLine("Dochodcovia:");
            foreach (var customer in filteredCustomers.ToList())
            {
                Console.WriteLine(customer.Name + " " + customer.LastName);
            }

            customers.Add(new Customer
            {
                Id = 4,
                Name = "Frantisek",
                LastName = "Vesely",
                Vek = 80
            });

            Console.WriteLine("Dochodcovia:");
            foreach (var customer in filteredCustomers.ToList())
            {
                Console.WriteLine(customer.Name + " " + customer.LastName);
            }

            var xmlList =  customers.Select(o => 
                new XElement("Customer",
                    new XElement("FirstName", 
                        new XAttribute("Attribute", 10),
                        new XElement("Fixed"),
                        o.Name),
                    new XElement("LastName", o.LastName),
                    new XElement("Age", o.Vek) 
                ));
            foreach (var xml in xmlList)
            {
                    Console.WriteLine(xml);
            }
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Vek { get; set; }
    }
}
