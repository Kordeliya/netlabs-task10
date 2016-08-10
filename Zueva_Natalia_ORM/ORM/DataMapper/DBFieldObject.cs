using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class DBFieldObject
    {

        public DBFieldObject(string name)
        {
            ColumnName = name;
        }
        public string ColumnName { get; private set; }

        public string Value { get; set; }

        public bool IsKey { get; set; }
    }
}
