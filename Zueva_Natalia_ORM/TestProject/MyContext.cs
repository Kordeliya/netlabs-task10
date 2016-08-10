using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class MyContext : DBContext
    {
        public MyContext(string connectionName)
            : base(connectionName)
        {
        }

        public IRepository<Book, int> Books {get;set;}
    }
}
