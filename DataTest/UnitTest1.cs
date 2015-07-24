using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayUtil.DataHelper.EntityAttribute;
using RayUtil.DataHelper.SqlFactory;

namespace DataTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestModel tm = new TestModel() { Date = DateTime.Now, Name = "Ray" };
            ISqlFactory sf = new CreateUpdateSql();
            string s = sf.GetSql(tm);
        }
    }

    [Table(TableName = "testTable")]
    public class TestModel
    {
        [Field(FiledName = "key", Type = DbType.Int32, IsKey = true)]
        public int Key { get; set; }

        [Field(FiledName = "Name", Type = DbType.String)]
        public string Name { get; set; }

        [Field(FiledName = "date", Type = DbType.DateTime)]
        public DateTime Date { get; set; }

    }
}
