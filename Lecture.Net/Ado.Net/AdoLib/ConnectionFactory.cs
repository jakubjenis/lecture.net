using System.Data.SqlClient;

namespace AdoNetSample
{
    public static class ConnectionFactory
    {
        private static string _defaultConnectionString;
        
        public static void Initialize(string connectionString)
        {
            _defaultConnectionString = connectionString;
        }

        public static SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(_defaultConnectionString);
            connection.Open();
            return connection;
        }
    }
}