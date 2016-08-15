using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
    public class SQLConnectionFactory : ConnectionFactory
    {
        public SQLConnectionFactory(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            DbConnection = new SQLConnection(connection);
        }
    }
}
