﻿using DataMapper;
using DBConnect;
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
            var provider = ConfigurationManager.ConnectionStrings[connectionName].ProviderName;

            ConnectionFactory factory = GetFactory(provider, ConnectionString); 

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
                        }
                    }
                }
            }

        }

        private ConnectionFactory GetFactory(string provider, string connectionString)
        {
            switch (provider)
            {
                case "System.Data.SqlClient" :
                    return new SQLConnectionFactory(connectionString);
                    break;
                case "System.Data.SqlServerCe.4.0":
                    return new SQLCeConnectionFactory(connectionString);
                    break;
                default :
                    throw new ORMException("Unknown  dbprovider");
            }                
        }

        public string ConnectionString { get; private set; }

    }
}
