using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class SQLConnection : Connection
    {

        private static SqlConnection _connection;

        public override IDataReader ExecuteCommand(string command)
        {
            SqlCommand sqlCommand = new SqlCommand(command,_connection);
            _connection.Open();
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
