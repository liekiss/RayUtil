using System;
using System.Data;

namespace RayUtil.DataHelper.EntityAttribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class FieldAttribute : Attribute
    {
        public bool IsKey { get; set; }

        public string FiledName { get; set; }

        public DbType Type { get; set; }

        public int Length { get; set; }
    }
}
