using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Xml;
using SQLLib;
using System.Threading;
using System.Diagnostics;

namespace DbCLient
{
    public static class MyExtensions
    {
        public static string Osekni(this string slovo, int pocet)
        {
            return slovo.Trim().Substring(pocet);
        }
    }

    class Program
    {
        public delegate void BezParametru();

        public event BezParametru myEvent;

        public string Slovo;

        static void Main()
        {
            const int threadCount = 10;
            var vlakna = new Thread[threadCount];
            Connection.Init("Server=Revizie.ukf.sk,1433;Database=Skolenie;User Id=Skolenie;Password=12345;");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            var doc = new XmlDocument();
            doc.Load("input.xml");
            var produkty = new List<Product>();

            var sw = new Stopwatch();
            sw.Start();

            foreach (XmlNode n in doc.SelectNodes("//product"))
            {
                var p = new Product(n);
                if (p.IsValid)
                    produkty.Add(p);
            }

            string nazvy = produkty.Select((x) => x.Nazov).Take(3).Aggregate((seed, akt) => seed + "..." + akt);
            Console.WriteLine(nazvy);
            
            double priemer = produkty.Sum((x) => x.Cena);

            produkty.Select((x) => x.Cena).Where((x) => x > 30).Skip(10).Take(10);

            //produkty.Where((x) => x.Cena > 30);

            //int varka = produkty.Count / threadCount;
            //for (int i = 0; i < vlakna.Length; i++)
            //{
            //    vlakna[i] = new Thread(Download);
            //    var param = new DownloadParam()
            //        {
            //            Pocet = varka,
            //            Produkty = produkty,
            //            StartIndex = i * varka
            //        };
            //    vlakna[i].Start(param);
            //}
            //for (int i = 0; i < vlakna.Length; i++)
            //{
            //    vlakna[i].Join();
            //}

            sw.Stop();
            Console.WriteLine("Elapsed time:{1}m {0}s", sw.Elapsed.Seconds, sw.Elapsed.Minutes);
            Console.WriteLine("Done");
            Console.ReadLine();

            var list = new List<int>() {1, 2, 3, 4, 5};
            AplikujFunkciu(list, (x, y) => x + y);

            //LINQ

            foreach (var l in list)
            {
                Console.WriteLine(l);
            }

            var slovo = "abcd";
            slovo.Osekni(4);

        }

    
        public delegate int Funkcia(int i, int j);
        
        public static void AplikujFunkciu(IList<int> list, Funkcia funkcia)
        {
            for (int i = 0; i < list.Count; i++ )
            {
                list[i] = funkcia(list[i], 2);
            }
        }

        public static int Nasob(int i)
        {
            return i*2;
        }

        public static void Download(object par)
        {
            using (var conn = Connection.GetOpen())
            {
                var param = (DownloadParam)par;
                for (int i = param.StartIndex; i < param.StartIndex + param.Pocet; i++)
                {
                    param.Produkty[i].Save(conn);
                }
            }
          
        }
    }

    public class DownloadParam
    {
        public List<Product> Produkty { get; set; }
        public int StartIndex { get; set; }
        public int Pocet { get; set; }
    }
}

