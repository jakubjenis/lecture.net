using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Caching;
using Foxconn.Bo;
using System.Data.SqlClient;

namespace Foxconn.Dal
{
    public class DatabaseRepository
    {
        public List<Students> GetStudentsEntity()
        {
            using (var context = new SkolenieEntities())
            {
                return context.Students
                    .Where(o => o.FirstName == "Honza")
                    .Take(5).ToList();
            }
        }

        public List<Student> GetStudents()
        {
            //1) Create connection
            //OracleConnection oracleConn = new OracleConnection("Server=localhost, 1433; Database=Skolenie;");
            //http://www.connectionstrings.com/oracle/

            //SqlConnection connection = null;
            //try
            //{
            //    connection = ConnFactory.CreateOpenConnection();
            //}
            //finally
            //{
            //    if (connection != null && connection.State == ConnectionState.Open)
            //        connection.Close();

            //    connection.Dispose();
            //}

            //var connection = new SqlConnection(
            //   ConfigurationManager.ConnectionStrings["Foxconn"].ConnectionString);
            //http://msdn.microsoft.com/cs-cz/library/ms254494%28v=vs.110%29.aspx
            var connection = new SqlConnection("Server=.; Database=Skolenie; Integrated security=true");
            

            //2) Create command
            var command = new SqlCommand
            {
                CommandText = "Select * from Students",
                CommandType = CommandType.Text,
                Connection = connection
            };

            //3) Open connection
            connection.Open();

            //4) Execute reader

            //ExecuteScalar
            //ExecuteReader
            //ExecuteNonQuery

            //Select scalar value
            //object scalar = command.ExecuteScalar();

            //Update, Insert
            //int nonQuery = command.ExecuteNonQuery();

            //Transaction
            //http://www.codeproject.com/Questions/541420/howplustoplususeplussqltransactionplusinplusado-ne

            //Select
            SqlDataReader reader = command.ExecuteReader();
            int firstNameIndex = reader.GetOrdinal("FirstName");
            int lastNameIndex = reader.GetOrdinal("LastName");
            int dateNameIndex = reader.GetOrdinal("DateOfBirth");

            string firstName, lastName;
            DateTime dateOfBirth;

            var students = new List<Student>();
            while (reader.Read())
            {
                //object firstName = reader["FirstName"];
                firstName = reader.GetString(firstNameIndex);
                lastName = reader.GetString(lastNameIndex);
                dateOfBirth = reader.GetDateTime(dateNameIndex);
                students.Add(new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth
                });
            }

            connection.Close();
            return students;
        }

        public List<Student> GetStudentByName(string name)
        {
            var students = new List<Student>();
            ObjectCache cache = MemoryCache.Default;

            //read form cache
            if(cache.Contains("StudentsTable"))
            {
                return (List<Student>)cache.Get("StudentsTable");
            }
            const string commandText = "Select * from Students where FirstName=@name";
            using (var connection = ConnFactory.CreateOpenConnection())
            using (var command = CmdFactory.CreateCommand(connection, commandText,
                new SqlParameter("@name", name)))
            using (var reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    students.Add(new Student
                    {
                        FirstName = reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        DateOfBirth = reader.GetDateTime("DateOfBirth")
                    });
                }
                //Add to cache
                cache.Add("StudentsTable", students, new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(10)
                });
            }
            return students;
        }

        public void InsertStudent(Student student)
        {
            using (var connection = ConnFactory.CreateOpenConnection())
            using (var command = CmdFactory.CreateStoredProcedure(connection, "sp_InsertStudent",
                new SqlParameter("@FirstName", student.FirstName),
                new SqlParameter("@LastName", student.LastName),
                new SqlParameter("@DateOfBirth", student.DateOfBirth)))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
