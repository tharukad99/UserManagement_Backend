using System;
using System.Data.Common;
using System.Linq;

namespace DataAccessLayer
{
    public class DataReader
    {
        private DateTime defaultDate;

        public DataReader(DbDataReader reader)
        {
            this.defaultDate = DateTime.MinValue;
            this.reader = reader;
        }


        public int GetInt32(String column)
        {
            int data = 0;

            if (DoesFieldExists(reader, column))
                data = (reader.IsDBNull(reader.GetOrdinal(column)))
                                    ? (int)0 : (int)reader[column];

            return data;
        }

        public string GetString(String column)
        {
            string data = string.Empty;

            if (DoesFieldExists(reader, column))
                data = Convert.ToString(reader[column]);

            return data;

        }

        public DateTime GetDateTime(String column)
        {
            DateTime data = defaultDate;

            if (DoesFieldExists(reader, column))
                data = (reader.IsDBNull(reader.GetOrdinal(column)))
                               ? defaultDate : (DateTime)reader[column];

            return data;
        }

        private bool DoesFieldExists(DbDataReader reader, string fieldName)
        {
            int columnCount = reader.GetColumnSchema().Where(t => t.ColumnName == fieldName).Count();
            return (columnCount > 0);
        }

        private DbDataReader reader;
    }
}
