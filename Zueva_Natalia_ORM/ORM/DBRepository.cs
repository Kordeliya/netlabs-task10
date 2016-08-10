using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class DBRepository : IRepository<DBTableObject,string>
    {
        public DBTableObject InfoTable { get; set; }
        public DBTableObject GetById(string primaryKey)
        {
            DBTableObject newObj = null;
            string sql = String.Format("SELECT * FROM {0} WHERE {1} = {2}", 
                                    InfoTable.NameTable,InfoTable.Columns.Where(c=>c.IsKey==true).FirstOrDefault(), primaryKey);

            return newObj;
        }

        public IEnumerable<DBTableObject> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
