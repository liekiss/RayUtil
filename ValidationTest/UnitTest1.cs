using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validations;

namespace ValidationTest
{
    public class Students
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "名字必须填")]
        [StringLength(5, ErrorMessage = "长度小于5")]
        public string Name { get; set; }

        public int Age { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Students s = new Students { Age = 10, Name = "fsdfsdafsafsadf" };
            IValidation validation = new Validation();
            validation.Validate(s);
        }
    }
}
