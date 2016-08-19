
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


        /// <summary>
        /// Получение записи по идентификатору
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public TEntity GetById(TKey primaryKey)
        {
            TEntity entity = default(TEntity);
            string sql = String.Format("SELECT * FROM {0} WHERE {1} = {2}",
                                    InfoTable.NameTable, InfoTable.Columns.Where(c => c.IsKey == true).FirstOrDefault().ColumnName, primaryKey);

            var dataset = ConFactory.DbConnection.ExecuteCommand(sql, InfoTable.NameTable);
            var list = (List<TEntity>)Mapper.BackTableMapper(InfoTable, dataset, InfoTable.NameTable);
            if (list != null && ((List<TEntity>)list).Count() > 0)
                entity = ((List<TEntity>)list)[0];

            return entity;
        }

        /// <summary>
        /// Создание новой записи
        /// </summary>
        /// <param name="entity"></param>
        public void CreateNew(TEntity entity)
        {
            string fieldName = String.Empty;
            StringBuilder sql = new StringBuilder(String.Format("INSERT INTO {0} (", InfoTable.NameTable));
            for (var column = 0; column < InfoTable.Columns.Count(); column++)
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

        /// <summary>
        /// Получение списка записей
        /// </summary>
        /// <returns></returns>
        public IList<TEntity> GetList()
        {
            List<TEntity> result;
            string sql = String.Format("SELECT * FROM {0}",
                                    InfoTable.NameTable);

            var dataset = ConFactory.DbConnection.ExecuteCommand(sql, InfoTable.NameTable);
            result = (List<TEntity>)Mapper.BackTableMapper(InfoTable, dataset, InfoTable.NameTable);

            return result;
        }



        public void DeleteById(TKey primaryKey)
        {
            string sql = String.Format("DELETE FROM {0} WHERE {1} = {2}",
                                    InfoTable.NameTable, InfoTable.Columns.Where(c => c.IsKey == true).FirstOrDefault().ColumnName, primaryKey);

            ConFactory.DbConnection.ExecuteCommand(sql);
        }


        public void Update(TEntity entity)
        {
            string fieldName = String.Empty;
            string where = String.Empty;
            StringBuilder sql = new StringBuilder(String.Format("UPDATE {0} SET", InfoTable.NameTable));
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
                            if (!InfoTable.Columns[column].IsKey)
                            {
                                if (InfoTable.Columns[column].Type == typeof(System.String) || InfoTable.Columns[column].Type == typeof(System.DateTime))
                                {
                                    sql.Append(fieldName + "=" + "'" + prop.GetValue(entity) + "'");
                                }
                                else
                                {
                                    sql.Append(fieldName + "=" + prop.GetValue(entity));
                                }
                                if (column != InfoTable.Columns.Count() - 1)
                                    sql.Append(", ");
                            }
                            else
                            {
                                where = String.Format("WHERE {0}={1}", fieldName, prop.GetValue(entity));
                            }
                        }
                        fieldName = String.Empty;
                    }
                }
                else
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

                    }
                }
                sql.Append(where);

                ConFactory.DbConnection.ExecuteCommand(sql.ToString());
            }
        }


    }
    
}
