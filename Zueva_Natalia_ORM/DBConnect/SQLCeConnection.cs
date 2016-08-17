using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
    public class SQLCeConnection : DBConnection
    {
        public SQLCeConnection(SqlCeConnection conection)
        {
            Connection = conection;
        }

        public override IDataReader ExecuteCommand(string command)
        {
            Object result = null;
            SqlCeCommand sqlCommand = new SqlCeCommand(command, (SqlCeConnection)Connection);
            Connection.Open();
            try
            {
                var reader = sqlCommand.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
