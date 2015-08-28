using System;
using System.Data.SqlClient;
using System.Data;

namespace SQLLib
{
    public static class Execute
    {
        public static SqlDataReader Reader(string query, params SqlParameter[] par)
        {
            using (var conn = Connection.GetOpen())
            {
                return Reader(query, conn, par);
            }
        }

        public static SqlDataReader Reader(string query, SqlConnection conn, params SqlParameter[] par)
        {
            using (var cmd = Command.Create(query, conn, CommandType.Text, par))
            {
                return cmd.ExecuteReader();
            }
        }

        public static int NonQuery(string query, params SqlParameter[] par)
        {
            using (var conn = Connection.GetOpen())
            {
                return NonQuery(query, conn, par);
            }
        }

        public static int NonQuery(string query, SqlConnection conn, params SqlParameter[] par)
        {
            using (var cmd = Command.Create(query, conn, CommandType.Text, par))
            {
                return cmd.ExecuteNonQuery();
            }
        }

        public static SqlDataReader ReaderSP(string query, params SqlParameter[] par)
        {
            using (var conn = Connection.GetOpen())
            {
                return ReaderSP(query, conn, par);
            }
        }

        public static SqlDataReader ReaderSP(string query, SqlConnection conn, params SqlParameter[] par)
        {
            using (var cmd = Command.Create(query, conn, CommandType.StoredProcedure, par))
            {
                return cmd.ExecuteReader();
            }
        }

        public static int NonQuerySP(string query, params SqlParameter[] par)
        {
            using (var conn = Connection.GetOpen())
            {
                return NonQuerySP(query, conn, par);
            }
        }

        public static int NonQuerySP(string query, SqlConnection conn, params SqlParameter[] par)
        {
            using (var cmd = Command.Create(query, conn, CommandType.StoredProcedure, par))
            {
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public static class Command
    {
        //Conn, Type, Text, Parameters

        public static SqlCommand Create(string text, SqlConnection conn, CommandType type, params SqlParameter[] par)
        {
            var cmd = new SqlCommand(text, conn) { CommandType = type };
            for (i = 0; i < par.Length; i++)
            {
                cmd.Parameters.Add(par);
            }
            return cmd;
        }

    }

    public static class Connection
    {
        private static string _queryString;

        public static void Init(String qs)
        {
            _queryString = qs;
        }

        public static SqlConnection GetOpen()
        {
            return GetOpen(_queryString);
        }

        public static SqlConnection GetOpen(string qs)
        {
            var conn = new SqlConnection(qs);
            conn.Open();
            return conn;
        }

        public static string QueryString { get { return _queryString; } }
    }
}
