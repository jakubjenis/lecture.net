using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace c_Reference
{
    class Program
    {
        static int[] MergeSort(int[] pole)
        {
            if ((pole.Length == 2) && (pole[0] > pole[1]))
            {
                int pom = pole[0]; pole[0] = pole[1]; pole[1] = pom;
            }
            if (pole.Length <= 2)
                return pole;
            
            int[] pole1 = new int[pole.Length / 2];
            int[] pole2 = new int[pole.Length - pole1.Length];

            //1) ROZDEL
            for (int i = 0; i<pole.Length; i++)
            {
                if (i<pole1.Length)
                {
                    pole1[i] = pole[i];
                }
                else
                {
                    pole2[i - pole1.Length] = pole[i];
                }
            }
            int[] sortedPole1 = MergeSort(pole1);
            int[] sortedPole2 = MergeSort(pole2);
            return Merge(sortedPole1, sortedPole2);
        }

        static int[] Merge(int[] pole1, int[] pole2)
        {
            var ret = new int[pole1.Length + pole2.Length];

            int uk1 = 0; int uk2 = 0; 
            while(true)
            { 
                if (pole2[uk2] > pole1[uk1])
                {
                    ret[uk1 + uk2] = pole1[uk1];
                    uk1++;
                    if (uk1 >= pole1.Length)
                    {
                        while (uk2 < pole2.Length)
                        {
                            ret[uk1 + uk2] = pole2[uk2];
                            uk2++;
                        }
                        break;
                    }
                }
                else
                {
                    ret[uk1 + uk2] = pole2[uk2];
                    uk2++;
                    if (uk2 >= pole2.Length)
                    {
                        while (uk1 < pole1.Length)
                        {
                            ret[uk1 + uk2] = pole1[uk1];
                            uk1++;
                        }
                        break;
                    }
                }
            }

            return ret;

        }

        static void Main()
        {
            foreach (int s in MergeSort(new[] {15, 2, 35, 4, 102, 7, 8, 9, 11, 205, 26, 35}))
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }


    }
}
