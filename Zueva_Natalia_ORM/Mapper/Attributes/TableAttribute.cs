using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class TableAttribute: Attribute
    {

        private string tableName;

        public TableAttribute(string name)
        {
            tableName = name;
        }
    }
}
