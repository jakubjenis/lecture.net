using System.Data.Common;

namespace AdoNetSample
{
    public static class DataReaderExtender
    {
        public static object GetString(this DbDataReader reader, string columnName)
        {
            return reader.GetString(reader.GetOrdinal(columnName));
        }
    }
}
