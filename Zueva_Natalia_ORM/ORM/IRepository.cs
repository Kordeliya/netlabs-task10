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

        IList<TEntity> GetList();

        void CreateNew(TEntity entity);

        void DeleteById(TKey primaryKey);

        void Update(TEntity entity);

    }

}
