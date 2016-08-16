
using DataMapper;
using DBConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class DBRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    {
        public DBRepository(DBTableObject tableInfo, ConnectionFactory factory)
        {
            InfoTable = tableInfo;
            ConFactory = factory;
        }

        public ConnectionFactory ConFactory { get; set; }

        public DBTableObject InfoTable { get; set; }


        public TEntity GetById(TKey primaryKey)
        {
            TEntity entity;
            string sql = String.Format("SELECT * FROM {0} WHERE {1} = {2}",
                                    InfoTable.NameTable, InfoTable.Columns.Where(c => c.IsKey == true).FirstOrDefault(), primaryKey);

            var reader = ConFactory.DbConnection.ExecuteCommand(sql);
            entity = (TEntity)Mapper.BackTableMapper(InfoTable, reader);
            return entity;
        }

        IEnumerable<TEntity> IRepository<TEntity, TKey>.GetList()
        {
            throw new NotImplementedException();
        }
    }
    
}
