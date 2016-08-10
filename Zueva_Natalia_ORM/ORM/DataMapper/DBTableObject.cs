using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class DBTableObject
    {
        public DBTableObject(string name)
        {
            NameTable = name;
            Columns = new List<DBFieldObject>();
        }

        public string NameTable { get; private set; }

        public List<DBFieldObject> Columns { get; set; }
    }
}
