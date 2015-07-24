using System;
using System.Collections.Generic;
using System.Text;
using RayUtil.DataHelper.EntityAttribute;

namespace RayUtil.DataHelper.SqlFactory
{
    public class CreateUpdateSql : ISqlFactory
    {
        public string GetSql<T>(T entity)
        {
            Type type = entity.GetType();
            SqlInfoModel sim = Common.GetSqlInfoModel(entity);
            if (string.IsNullOrEmpty(sim.KeyField))
                throw new ArgumentException("请给Key字段加上特性IsKey=true");
            string tableName = sim.TableName;
            string keyValues = GetUpdateKeyValues(sim.FieldNames, sim.FieldValues);
            string where = string.Format("WHERE {0}={1}", sim.KeyField, sim.KeyValue);
            string sql = string.Format("UPDATE {0} SET {1} {2}", tableName, keyValues, where);
            return sql;
        }

        private string GetUpdateKeyValues(List<FieldAttribute> fields, List<string> values)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < fields.Count; i++)
            {
                sb.Append(fields[i].FiledName).Append("=").Append(values[i]).Append(",");
            }
            string keyValue = sb.ToString().TrimEnd(',');
            return keyValue;
        }
    }
}
