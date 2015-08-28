using System.Data;
using System.Data.SqlClient;

namespace Foxconn.Dal
{
    public class CmdFactory
    {
        public static SqlCommand CreateCommand(SqlConnection connection, string query,
             params SqlParameter[] parameters)
        {
            return CreateCommandInner(connection, query, CommandType.Text, parameters);
        }

        public static SqlCommand CreateStoredProcedure(SqlConnection connection, string procedureName, 
            params SqlParameter[] parameters)
        {
            return CreateCommandInner(connection, procedureName, CommandType.StoredProcedure, parameters);
        }

        private static SqlCommand CreateCommandInner(
            SqlConnection connection, 
            string query,
            CommandType type, 
            params SqlParameter[] parameters)
        {
            var command = new SqlCommand
            {
                CommandType = type,
                CommandText = query,
                Connection = connection
            };
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }
    }
}
