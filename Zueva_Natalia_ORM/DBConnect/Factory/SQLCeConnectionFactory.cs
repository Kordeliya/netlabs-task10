using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
    public class SQLCeConnectionFactory : ConnectionFactory
    {
        public SQLCeConnectionFactory(string connectionString)
        {
            var connection = new SqlCeConnection(connectionString);
            DbConnection = new SQLCeConnection(connection);
        }
    }
}
