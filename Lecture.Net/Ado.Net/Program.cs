using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace AdoNetSample
{
    class Program
    {
        /*  CommandType.TableDirect - TableDirect is only supported by the .NET Framework Data Provider for OLE DB. Multiple table access is not supported when CommandType is set to TableDirect.
         * 
         * SQL Server Data Type Mappings http://msdn.microsoft.com/en-us/library/cc716729%28v=vs.110%29.aspx
         * Oracle Data Type Mappings http://msdn.microsoft.com/en-us/library/cc716726(v=vs.110).aspx
         * 
         * CommandBehavior http://msdn.microsoft.com/query/dev12.query?appId=Dev12IDEF1&l=EN-US&k=k(System.Data.CommandBehavior);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5);k(DevLang-csharp)&rd=true
         * 
         * reader.getInt(lastNameIndex) - InvalidCastException
         * 
         */

        private static void Main(string[] args)
        {
            NaiveWay();
            GoodWay();
            SmartWay();
            SuperSmartWay();
        }

        private static void NaiveWay()
        {
            string connectionString = "Server=.; Database=Skolenie; Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            
            DbCommand command = new SqlCommand();
            command.CommandText = "Select * from Students";
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            connection.Open();
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var firstName = (string)reader["firstName"];
                var lastName = (string)reader["lastName"];
                Console.WriteLine("{0,-10} {1,-10}", firstName, lastName);
            }
            Console.WriteLine();
            connection.Close();
        }

        private static void GoodWay()
        {
            DbConnection connection = null;
            try
            {
                connection = new SqlConnection("Server=.; Database=Skolenie; Integrated Security=true");
                //Command
                //Execute
            }
            catch (Exception)
            {
                //Logging, handling
            }
            finally
            {
                if(connection != null) connection.Dispose(); //or connection.Close
            }
        }

        private static void SmartWay()
        {
            using (DbConnection connection = 
                new SqlConnection(ConfigurationManager.ConnectionStrings["Skolenie"].ConnectionString))
            {
                //Command
                //Execute
            }
        }

        private static void SuperSmartWay()
        {
            ConnectionFactory.Initialize(ConfigurationManager.ConnectionStrings["Skolenie"].ConnectionString);
            using (SqlConnection connection = ConnectionFactory.GetOpenConnection())
            {
                using (SqlCommand command = CommandFactory.CreateCommand("Select * From Teachers", connection))
                {
                    DbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {  
                        Console.WriteLine("{0,-10} {1,-10}", reader.GetString("firstName"), reader.GetString("lastName"));
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
