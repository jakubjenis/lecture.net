using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poznamky
{
    internal class Program
    {
        public delegate void Poziar (string message, int stanica);
        public static event Poziar Hori;

        static void Main(string[] args)
        {
            //HORI!!!!!!!!!!!!! na stanici 3, zakric UTEKAJTE
            Hori += ObsluhaPoziaru;
            if(Hori!=null) { Hori("UTEKAJTE", 3); }
            Console.ReadLine();
        }

        public static void ObsluhaPoziaru(string message, int stanica)
        {
            Console.WriteLine(message);
        }
    }
}
