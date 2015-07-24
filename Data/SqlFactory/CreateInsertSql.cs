using System;
using System.Collections.Generic;
using System.Text;
using RayUtil.DataHelper.EntityAttribute;

namespace RayUtil.DataHelper.SqlFactory
{
    public class CreateInsertSql : ISqlFactory
    {
        public string GetSql<T>(T entity)
        {
            Type type = entity.GetType();
            SqlInfoModel sim = Common.GetSqlInfoModel(entity);
            string tableName = sim.TableName;
            List<FieldAttribute> fields = sim.FieldNames;
            string fieldStr = GetFieldStr(fields);
            List<string> values = sim.FieldValues;
            string valuesStr = GetValuesStr(values);
            string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tableName, fieldStr, valuesStr);
            return sql;
        }

        private string GetFieldStr(List<FieldAttribute> fields)
        {
            StringBuilder sb = new StringBuilder();
            fields.ForEach(
                item =>
                {
                    sb.Append(item.FiledName).Append(',');
                }
                );
            return sb.ToString().TrimEnd(',');
        }

        private string GetValuesStr(List<string> values)
        {
            StringBuilder sb = new StringBuilder();
            values.ForEach(
                item =>
                {
                    sb.Append(item).Append(',');
                }
                );
            return sb.ToString().TrimEnd(',');
        }
    }
}
