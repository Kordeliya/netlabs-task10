using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    public static class MapperHelper<T>
    {
        public static T Read(string fieldName, DbDataReader dataReader)
        {
            int FieldIndex;
            try { FieldIndex = dataReader.GetOrdinal(fieldName); }
            catch { return default(T); }

            if (dataReader.IsDBNull(FieldIndex))
            {
                return default(T);
            }
            else
            {
                object readData = dataReader.GetValue(FieldIndex);
                if (readData is T)
                {
                    return (T)readData;
                }
                else
                {
                    try
                    {
                        return (T)Convert.ChangeType(readData, typeof(T));
                    }
                    catch (InvalidCastException)
                    {
                        return default(T);
                    }
                }
            }
        }

    }
}
