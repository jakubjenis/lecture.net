using System.Configuration;
using System.Data.SqlClient;

namespace Foxconn.Dal
{
    public static class ConnFactory
    {
        public static SqlConnection CreateOpenConnection()
        {
            var connection = new SqlConnection(
               ConfigurationManager.ConnectionStrings["Foxconn"].ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
