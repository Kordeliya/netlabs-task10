using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ColumnAttribute : Attribute
    {
        private string columnName;
        private bool isPrimaryKey;

        public ColumnAttribute(string name, bool isPrimaryKey = false)
        {
            this.columnName = name;
            this.isPrimaryKey = isPrimaryKey;
        }
    }
}
