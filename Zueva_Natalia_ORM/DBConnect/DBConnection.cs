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

        public abstract void ExecuteCommand(string command);

        public abstract DataSet ExecuteCommand(string command, string nameTable);

    }
}
