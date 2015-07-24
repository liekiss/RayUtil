using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayUtil.Serializer;


namespace SerializerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            School school = new School
            {
                Name = "新东方",
                Address = "徐汇区",
                Teachers = new Teacher[]
                {
                    new Teacher {Name = "haha", Age = 10},
                    new Teacher {Name = "hehe", Age = 20}
                }
            };
            XmlSerializer.Serialize(
                 @"C:\Users\yun.huang\Documents\Visual Studio 2013\Projects\RayUtil\SerializerTest\doc\test.xml", school);

            var s =
                XmlSerializer.Deserialize<School>(
                    @"C:\Users\yun.huang\Documents\Visual Studio 2013\Projects\RayUtil\SerializerTest\doc\test.xml");

        }
    }


}
