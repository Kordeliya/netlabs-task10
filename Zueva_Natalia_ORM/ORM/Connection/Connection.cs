using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public abstract class Connection
    {
        public abstract IDataReader ExecuteCommand(string command);
    }
}
