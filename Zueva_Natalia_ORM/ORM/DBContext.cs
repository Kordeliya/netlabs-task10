using ORM.Attributes;
using ORM.Connection;
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
            ConnectionFactory connect;

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
                       // var repository = new DBRepository<typeof(entityType),int>()
                        p.SetValue(ormType,repository);
                    }
                   

                }
            }

        }

        public string ConnectionString { get; private set; }

        private Lazy<DbConnection> connection { get; set; }

    }
}
