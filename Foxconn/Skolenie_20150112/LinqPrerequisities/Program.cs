using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using BinaryTree;
using LinqPrerequisities.Lib;

namespace LinqPrerequisities
{
    class Program
    {
       

        static void Main(string[] args)
        {
            var cust = new Customer
            {
                Name = "Ferdo",
                LastName = "Mravec"
            };
            IEnumerable<Customer> list = new List<Customer>
            {
                cust, 
                cust,
                cust
            };

            UserRights rights = UserRights.Login | UserRights.Edit;
            var ss = rights.HasFlag(UserRights.Edit);
            
            foreach (var right in EnumHelper.GetValues<UserRights>())
            {
                Console.WriteLine(right);
            }

            list.Vypis<Customer>();

            var list2 = new List<int> {1, 2, 3, 4};
            list2.Vypis<int>();

            // Binary tree
            var strom = new Node<int>(2);
            strom.Insert(8);
            strom.Insert(16);
            strom.Insert(4); 
            strom.Insert(9);
            strom.Insert(1);

            var sw = new Stopwatch();
            sw.Start();
            var rnd = new Random();
            for (int i = 0; i <= 20000; i++)
            {
                strom.Insert(rnd.Next(200000000));
            }
            sw.Stop();
            Console.WriteLine("Elapsed time: {0}", sw.Elapsed.Seconds);

            Console.WriteLine(strom.HasValue(3)); //false
            Console.WriteLine(strom.HasValue(9)); //true

            //strom.Vypis();

           // ArrayList nonGenericList = new ArrayList();
            List<int> genericList = new List<int>();

            var telefonnyZoznam = new Dictionary<int, string>
            {
                {148198349, "Ferdo Mravec"},
                {448148349, "CFerdo Mravec"},
                {348148349, "BFerdo Mravec"},
                {241498349, "AFerdo Mravec"}
            };

            Console.WriteLine("Dictionary");
            foreach (var keyValue in telefonnyZoznam)
            {
                Console.WriteLine("{0} {1}", keyValue.Key, keyValue.Value);
            }

            Console.WriteLine("Sorted List");
            var telefonnyZoznam2 = new SortedList<int, string>
            {
                {148198349, "Ferdo Mravec"},
                {448148349, "CFerdo Mravec"},
                {348148349, "BFerdo Mravec"},
                {241498349, "AFerdo Mravec"}
            };

            foreach (var keyValue in telefonnyZoznam2)
            {
                Console.WriteLine("{0} {1}", keyValue.Key, keyValue.Value);
            }
            
            //  Hashtable hashtable = new Hashtable();
            Dictionary<int, string> genericDictionary  = new Dictionary<int, string>();

            SortedList<int, string> sortedList = new SortedList<int, string>();
            HashSet<int> hashSet = new HashSet<int>();
       
            Stack<int> stack = new Stack<int>();
            stack.Push(2);
            stack.Push(3); 
            stack.Push(4);
            var stackTop = stack.Peek();
            stackTop = stack.Pop();

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(2);
            queue.Dequeue();

            ConcurrentDictionary<int, string> dictionary;
            //http://geekswithblogs.net/BlackRabbitCoder/archive/2011/06/16/c.net-fundamentals-choosing-the-right-collection-class.aspx


            MyCustomDelegate pointerToFunction = NamedFunction;
            pointerToFunction("halo", 1);

            pointerToFunction = delegate(string input, int value)
            {
                var textMessage = value + input;
                Console.WriteLine(textMessage);
            };

            //Lamdba function
            pointerToFunction = (input, value) =>
            {
                var textMessage = value + input;
                Console.WriteLine(textMessage);
            };

            MyCustomIntDelegate pointerToIntFunction =
                (input, value) =>
                {
                    return value * 2;
                };

            //ExpressionLambda
            pointerToIntFunction = 
                (input, value) => value * 2;

            Func<int> funcInt = () => 2*2;
            Func<string, int> funcStringInt = s => s.Length;
            GetLength funcGetLength = s => s.Length;

            Action funcDummy = () => Console.WriteLine("hello");
            Action<int> actionInt = i => Console.WriteLine("hello" + i);

        }

        private delegate int GetLength(string s);

        private delegate void MyCustomDelegate(string input, int value);

        private delegate int MyCustomIntDelegate(string input, int value);

        public static void NamedFunction(string input, int value)
        {
            Console.WriteLine(value + input);
        }
    }
}
