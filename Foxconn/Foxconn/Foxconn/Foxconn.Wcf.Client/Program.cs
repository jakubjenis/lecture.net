using System;
using Foxconn.Wcf.Client.FoxconnService;

namespace Foxconn.Wcf.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new FoxconnServiceClient())
            {
                foreach (var student in client.GetStudents())
                {
                    Console.WriteLine("{0} {1} {2}",student.FirstName, student.LastName, student.DateOfBirth);
                }
            }
            Console.ReadLine();

            using (var client = new FoxconnServiceClient())
            {
                foreach (var student in client.GetStudentByName("Honza"))
                {
                    Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.DateOfBirth);
                }

                foreach (var student in client.GetStudentByName("Honza"))
                {
                    Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.DateOfBirth);
                }

                //client.InsertStudent(new Student
                //{
                //    FirstName = "Baba",
                //    LastName = "Jaga",
                //    DateOfBirth = new DateTime(1840, 2, 2)
                //});
            }
            Console.ReadLine();


        }
    }
}
