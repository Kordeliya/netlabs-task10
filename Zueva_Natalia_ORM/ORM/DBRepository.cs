using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class DBRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    {
        public DBTableObject InfoTable { get; set; }

        public Connection Connect {get;set;}

        public TEntity GetByKey(TKey primaryKey)
        {
            TEntity entity;
            string sql = String.Format("SELECT * FROM {0} WHERE {1} = {2}", 
                                    InfoTable.NameTable,InfoTable.Columns.Where(c=>c.IsKey==true).FirstOrDefault(), primaryKey);

            Connect.ExecuteCommand(sql);
            entity = (TEntity)Mapper.BackTableMapper(InfoTable);
            return entity;
        }




        public IEnumerable<DBTableObject> GetList()
        {
            throw new NotImplementedException();
        }
    
}
