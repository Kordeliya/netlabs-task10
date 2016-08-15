using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
    public class SQLConnection : DBConnection
    {
        public SQLConnection(SqlConnection conection)
        {
            Connection = conection;
        }

        public override IDataReader ExecuteCommand(string command)
        {
            Object result = null;
            SqlCommand sqlCommand = new SqlCommand(command, (SqlConnection)Connection);
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
            finally
            {
                Connection.Close();
            }
        }
    }
}
