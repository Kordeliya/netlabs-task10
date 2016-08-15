using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    public class DBTableObject
    {
        public DBTableObject(string name, Type type)
        {
            NameTable = name;
            Columns = new List<DBFieldObject>();
            Type = type;
        }

        public string NameTable { get; private set; }

        public List<DBFieldObject> Columns { get; set; }

        public Type Type { get; set; }

        public Type TypeKey { get; set; }
    }
}
