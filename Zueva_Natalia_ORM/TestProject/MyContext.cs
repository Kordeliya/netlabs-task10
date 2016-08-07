using ORM;
using ORMRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class MyContext : DBContext
    {
        public MyContext(string connectionString)
            : base(connectionString)
        {
        }

        public IRepository<Book, int> Books {get;set;}
    }
}
