using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class test : IRepository<TEntity,TKey>
        where TEntity : class
    {
    }
}
