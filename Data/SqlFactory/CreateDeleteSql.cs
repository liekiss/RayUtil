using System;

namespace RayUtil.DataHelper.SqlFactory
{
    public class CreateDeleteSql : ISqlFactory
    {
        public string GetSql<T>(T entity)
        {
            Type type = entity.GetType();
            SqlInfoModel sim = Common.GetSqlInfoModel(entity);
            if (string.IsNullOrEmpty(sim.KeyField))
                throw new ArgumentException("请给Key字段加上特性IsKey=true");
            string tableName = sim.TableName;
            string where = string.Format("WHERE {0}={1}", sim.KeyField, sim.KeyValue);
            string sql = string.Format("DELETE FROM  {0} {1}", tableName, where);
            return sql;
        }
    }
}
