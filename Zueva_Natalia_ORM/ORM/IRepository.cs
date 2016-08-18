using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public interface IRepository<TEntity, TKey>
    {
        TEntity GetById(TKey primaryKey);

        IEnumerable<TEntity> GetList();

        void CreateNew(TEntity entity);

    }

}
