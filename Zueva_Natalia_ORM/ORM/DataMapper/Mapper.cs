using ORM.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public static class Mapper
    {
        public static DBTableObject TableMapper(Type entity, string tableName)
        {
            DBTableObject obj = null;
            string nameTable;
            var attributes = entity.CustomAttributes;

            foreach (var attr in attributes)
            {

                if (attr.AttributeType == typeof(TableAttribute))
                {
                    if (attr.ConstructorArguments != null)
                        nameTable = attr.ConstructorArguments[0].Value.ToString();
                    else
                        nameTable = tableName;
                    obj = new DBTableObject(nameTable,entity.GetType());
                    var propertyColumn = entity.GetProperties();
                    foreach (var p in propertyColumn)
                    {
                        DBFieldObject field = FieldMapper(p);
                        if (field != null)
                            obj.Columns.Add(field);
                    }
                }
            }
            return obj;
        }

        public static DBFieldObject FieldMapper(PropertyInfo property)
        {
            DBFieldObject obj = null;
            string nameColumn;
            var attributes = property.CustomAttributes;

            foreach (var attr in attributes)
            {

                if (attr.AttributeType == typeof(ColumnAttribute))
                {
                    if (attr.ConstructorArguments != null)
                        nameColumn = attr.ConstructorArguments[0].Value.ToString();
                    else
                        nameColumn = property.Name;
                    obj = new DBFieldObject(nameColumn, property.GetType());
                    //проверка ключ ли
                  
                }
            }
            return obj;
        }


        public static Object BackTableMapper(DBTableObject obj)
        {
            Object result = null;
            result.GetType();
            return result;
          
        }



    }
}
