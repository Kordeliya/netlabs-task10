using DBConnect;
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
            ConnectionFactory factory = new SQLConnectionFactory(ConnectionString);

            Type ormType = this.GetType();
            PropertyInfo[] props = ormType.GetProperties();
            foreach (var p in props)
            {
                if (p.PropertyType.IsGenericType)
                {
                    if (p.PropertyType.GetGenericTypeDefinition() == typeof(IRepository<,>))
                    {
                        Type entityType = p.PropertyType.GenericTypeArguments[0];
                        Type keyType = p.PropertyType.GenericTypeArguments[1];
                        DBTableObject obj = Mapper.TableMapper(entityType, p.Name);
                        if (obj != null)
                        {
                            Type type = typeof(DBRepository<,>).MakeGenericType(entityType, keyType);
                            var repository = Activator.CreateInstance(type, obj, factory);

                            p.SetValue(this, repository);
                            // p.SetValue(this, Convert.ChangeType(repository, p.PropertyType), null);
                        }
                    }
                }
            }

        }

        public string ConnectionString { get; private set; }

        private Lazy<DbConnection> connection { get; set; }

    }
}
