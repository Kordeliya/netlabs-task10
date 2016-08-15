using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
    public abstract class DBConnection
    {

        public DbConnection Connection { get; set; }

        public abstract IDataReader ExecuteCommand(string command);

    }
}
