using ORM.Attributes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public abstract class DBContext
    {
        public DBContext(string connectionName)
        {            
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            ConnectionString = connectionString;
            //var connection = new SqlConnection(connectionString);
            Type ormType = this.GetType();
            PropertyInfo[] props = ormType.GetProperties();
            foreach (var p in props)
            {
                if (p.PropertyType.GetGenericTypeDefinition() == typeof(IRepository<,>))
                {
                    Type entityType = p.PropertyType.GenericTypeArguments[0];
                    DBTableObject obj = Mapper.TableMapper(entityType, p.Name);
                    if (obj != null)
                    {
                    }
                   

                }
            }

        }

        public string ConnectionString { get; private set; }

        private Lazy<DbConnection> connection { get; set; }

    }
}
