using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public abstract class ConnectionFactory
    {
        Connection connect { get; set; }
    }
}
