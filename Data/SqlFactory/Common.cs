using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using RayUtil.DataHelper.EntityAttribute;

namespace RayUtil.DataHelper.SqlFactory
{
    public class Common
    {
        public static SqlInfoModel GetSqlInfoModel<T>(T entity)
        {
            SqlInfoModel sim = new SqlInfoModel();
            List<string> values = new List<string>();
            Type type = entity.GetType();
            PropertyInfo[] props = type.GetProperties();
            List<FieldAttribute> fields = new List<FieldAttribute>();
            foreach (var prop in props)
            {
                var atts = prop.GetCustomAttributes(false);
                foreach (var att in atts)
                {
                    if (att is FieldAttribute)
                    {
                        FieldAttribute attribute = att as FieldAttribute;
                        switch (attribute.Type)
                        {
                            case DbType.String: values.Add("'" + prop.GetValue(entity) + "'");
                                break;
                            case DbType.DateTime: string dateSql = string.Format("TO_DATE('{0}','yyyy-mm-dd hh24:mi:ss')", prop.GetValue(entity));
                                values.Add(dateSql);
                                break;
                            default: values.Add(prop.GetValue(entity).ToString());
                                break;
                        }
                        if (attribute.IsKey)
                        {
                            sim.KeyField = prop.Name;
                            sim.KeyValue = prop.GetValue(entity).ToString();
                        }
                        fields.Add(attribute);
                    }
                }
            }
            sim.TableName = GetTableName(type);
            sim.FieldNames = fields;
            sim.FieldValues = values;
            return sim;
        }

        private static string GetTableName(Type type)
        {
            var tableAttribute = (TableAttribute)type.GetCustomAttributes(false)[0];
            return tableAttribute.TableName;
        }
    }


}
