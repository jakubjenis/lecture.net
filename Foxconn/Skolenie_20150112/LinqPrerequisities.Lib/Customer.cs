using System;
using System.Collections.Specialized;

namespace LinqPrerequisities.Lib
{
    public sealed class Customer
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Vek
        {
            get { return DateTime.Now.Year - DateOfBirth.Year; }
        }

        public void PridajSplatku()
        {
            
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, LastName);
        }
    }
}
