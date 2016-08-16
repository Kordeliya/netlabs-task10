using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
    public abstract class ConnectionFactory
    {
        public DBConnection DbConnection { get; set; }
    }
}
