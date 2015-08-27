using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace AdoNetSample
{
    public static class ParameterFactory
    {
        public static DbParameter CreateParameter(string name, SqlDbType type, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            return new SqlParameter(name, type) { Value = value, Direction = direction};
        }
    }
}
