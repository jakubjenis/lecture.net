using System.Data.Entity;
using System.Linq.Expressions;
using LinqInternals;

namespace LinqIngredients
{
    class Customer
    {
        public string Name { get; set; }    
        public string Surname { get; set; }
        public int Age { get; set; }
    }

    class MyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } 
    }

    class Queryable
    {
        public Queryable()
        {
            using (var context = new MyContext())
            {
                var result = from c in context.Customers
                              where c.Age > 10
                              select new {FullName = c.Name + " " + c.Surname};

                var result2 = context.Customers.Where(o => o.Age > 10 ).Select(o => new
                {
                    FullName = o.Name + " " + o.Surname
                });
            }
        }
    }
}
