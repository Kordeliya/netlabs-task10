using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class SQLConnection : Connection
    {
        public override bool ExecuteCommand(string command)
        {
            return true;
        }
    }
}
