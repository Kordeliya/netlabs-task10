
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
                                    InfoTable.NameTable, InfoTable.Columns.Where(c => c.IsKey == true).FirstOrDefault().ColumnName, primaryKey);

            var dataset = ConFactory.DbConnection.ExecuteCommand(sql, InfoTable.NameTable);
            entity = (TEntity)Mapper.BackTableMapper(InfoTable, dataset, InfoTable.NameTable);
            return entity;
        }

        IEnumerable<TEntity> IRepository<TEntity, TKey>.GetList()
        {
            throw new NotImplementedException();
        }


        public void CreateNew(TEntity entity)
        {
            string fieldName = String.Empty;
            StringBuilder sql = new StringBuilder(String.Format("INSERT INTO {0} (", InfoTable.NameTable));
            for (var column = 0; column < InfoTable.Columns.Count(); column++ )
            {
                if (!InfoTable.Columns[column].IsKey)
                {
                    sql.Append(InfoTable.Columns[column].ColumnName);

                    if (column != InfoTable.Columns.Count() - 1)
                        sql.Append(", ");
                }
            }
            sql.Append(") VALUES (");
            for (var column = 0; column < InfoTable.Columns.Count(); column++)
            {
                if (!InfoTable.Columns[column].IsKey)
                {
                    var props = entity.GetType().GetProperties();
                    foreach (var prop in props)
                    {
                        if (prop.CustomAttributes != null)
                        {
                            foreach (var attr in prop.CustomAttributes)
                            {
                                if (attr.AttributeType == typeof(ColumnAttribute))
                                {
                                    if (attr.ConstructorArguments != null)
                                        fieldName = attr.ConstructorArguments[0].Value.ToString();
                                    else
                                        fieldName = prop.Name;

                                }
                            }
                        }
                        if (fieldName == InfoTable.Columns[column].ColumnName)
                        {
                            if (InfoTable.Columns[column].Type == typeof(System.String) || InfoTable.Columns[column].Type == typeof(System.DateTime))
                            {
                                sql.Append("'" + prop.GetValue(entity) + "'");
                            }
                            else
                            {
                                sql.Append(prop.GetValue(entity));
                            }
                            if (column != InfoTable.Columns.Count() - 1)
                                sql.Append(", ");
                        }
                        fieldName = String.Empty;
                    }
                }

            }
            sql.Append(")");

            ConFactory.DbConnection.ExecuteCommand(sql.ToString());

        }
    }
    
}
