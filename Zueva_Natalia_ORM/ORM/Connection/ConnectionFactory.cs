using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public abstract class ConnectionFactory
    {
        public Connection Connection { get; set; }
    }
}
