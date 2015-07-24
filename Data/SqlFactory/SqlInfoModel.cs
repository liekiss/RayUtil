using System.Collections.Generic;
using RayUtil.DataHelper.EntityAttribute;

namespace RayUtil.DataHelper.SqlFactory
{
    public class SqlInfoModel
    {
        public string TableName { get; set; }

        public List<FieldAttribute> FieldNames { get; set; }

        public List<string> FieldValues { get; set; }

        public string KeyField { get; set; }

        public string KeyValue { get; set; }
    }
}
