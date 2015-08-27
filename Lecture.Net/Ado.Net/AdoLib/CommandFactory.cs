using System.Data;
using System.Data.SqlClient;

namespace AdoNetSample
{
    public static class CommandFactory
    {
        public static SqlCommand CreateCommand(string query, SqlConnection connection, params SqlParameter[] parameters)
        {
            return CreateCommand(query, connection, null, CommandType.Text, parameters);
        }

        public static SqlCommand CreateCommand(string query, SqlTransaction transaction, params SqlParameter[] parameters)
        {
            return CreateCommand(query, null, transaction, CommandType.Text, parameters);
        }

        public static SqlCommand CreateProcedureCommand(string query, SqlConnection connection, params SqlParameter[] parameters)
        {
            return CreateCommand(query, connection, null, CommandType.StoredProcedure, parameters);
        }

        public static SqlCommand CreateProcedureCommand(string query, SqlTransaction transaction, params SqlParameter[] parameters)
        {
            return CreateCommand(query, null, transaction, CommandType.StoredProcedure, parameters);
        }

        private static SqlCommand CreateCommand(string query, SqlConnection connection, SqlTransaction transaction,
            CommandType type, params SqlParameter[] parameters)
        {
            if (connection == null && transaction == null) throw new AdoLibException("Connection and transaction null");
            SqlCommand command = new SqlCommand(query, connection, transaction) {CommandType = type};
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter != null &&
                        (type == CommandType.StoredProcedure ||
                         query.ToLower().Contains(parameter.ParameterName.ToLower())))
                    {
                        command.Parameters.Add(parameter);
                    }
                }
            }
            return command;
        }
    }
}
