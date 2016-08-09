using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class DBTableObject
    {
        public string NameTable { get; set; }

        public List<DBFieldObject> Columns { get; set; }
    }
}
