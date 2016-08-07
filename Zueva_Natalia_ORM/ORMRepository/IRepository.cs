using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMRepository
{
    public interface IRepository<TEntity, TKey>
    {
        TEntity GetById(TKey primaryKey);
    }
}
