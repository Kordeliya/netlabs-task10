using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
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
                    obj = new DBTableObject(nameTable, entity.GetType());
                    var propertyColumn = entity.GetProperties();
                    foreach (var p in propertyColumn)
                    {
                        DBFieldObject field = FieldMapper(p);
                        if (field != null)
                        {
                            obj.Columns.Add(field);
                            if (field.IsKey == true)
                                obj.TypeKey = field.Type;
                        }
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

                    obj.IsKey = (bool)attr.ConstructorArguments[1].Value;
                }
            }
            return obj;
        }


        public static Object BackTableMapper(DBTableObject obj, IDataReader reader)
        {
            var result = Activator.CreateInstance(obj.Type);
            Type type = result.GetType();
            var properties = type.GetProperties();
            string fieldName;

            while (reader.Read())
            {
                foreach (var item in obj.Columns)
                {
                    foreach (var prop in properties)
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

                                    Type typeHelper = typeof(MapperHelper<>).MakeGenericType(item.Type);

                                    var methodInfo = typeHelper.GetMethod("Read");

                                    var resultRead = methodInfo.Invoke(null, new object[] {fieldName, reader});
                                    //var helper = (MapperHelper<>)Activator.CreateInstance(typeHelper, null);

                                    prop.SetValue(result, resultRead);
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }


    }
}
