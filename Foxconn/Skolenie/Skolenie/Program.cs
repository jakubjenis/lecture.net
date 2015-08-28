using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Skolenie
{
    internal class Nasobic
    {
        public void Nasob(Del method)  
        {
            
        }

        public static int Podel(int x)
        {
            return x/2;
        }

        public int Zdvojnasob(int x)
        {
            return x*2;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            //Del myDel = new Del(MyDel); //explicit delegate creation
            Del myDel;
            var nasobic = new Nasobic();

            nasobic.Nasob(Method);
            nasobic.Nasob(delegate(int i) { return i; });
            nasobic.Nasob(i => i / 2);

            myDel = nasobic.Zdvojnasob;
            myDel = Nasobic.Podel;

            nasobic.Zdvojnasob(3);
            //var a = myDel.Invoke(3);

            Del myDel20 = nasobic.Zdvojnasob;

            Del myDel22 = delegate(int x) { return x/2; };
            Del myDel23 = (int x) =>
            {
                int y = x/2;
                return x;
            };

            Del myDel24 = x =>
            {
                int y = x / 2;
                return x;
            };

            Del2 myDel224 = (x, y) =>
            {
                return x / 2 + 12;
            };

            Del3 myDel31 = (out int x, string y) =>
            {
                x = 0;
                return x;
            };

            Del myDel25 = x => x/2;
            Del myDel26 = x =>
            {
                return x/2;
            };

            Del myDel2 = MyDel; //named function
            Del myDel3 = delegate { return 3; }; //delegate + anonymous function
            Del myDel4 = delegate { return 3; }; //delegate + anonymous function with implicit parameters

            Del myDel5 = i => { return 3; }; //statement lambda
            Del myDel6 = i => 3; //lambda expression


            Expression<Del> myExpression = x => x + 2;

            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            int oddNumbers = numbers.Count(n => n%2 == 1);
            string s;

            Console.WriteLine("bla");
        }

        private static int Method(int i)
        {
            throw new NotImplementedException();
        }

        private static int MyDel(int i)
        {
            throw new NotImplementedException();
        }

        #region Nested type: Del

        

        #endregion
    }
    delegate int Del(int x);
    delegate int Del2(int x, string y);
    delegate int Del3(out int x, string y);
}