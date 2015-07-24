using System.Xml.Serialization;

namespace SerializerTest
{
    [XmlRoot(ElementName = "School")]
    public class School
    {
        [XmlAttribute(AttributeName = "SchoolName")]
        public string Name { get; set; }

        [XmlAttribute]
        public string Address { get; set; }

        [XmlArray(ElementName = "Teachers")]
        public Teacher[] Teachers { get; set; }
    }

    [XmlRoot(ElementName = "teach")]
    public class Teacher
    {
        [XmlElement(ElementName = "TeacherName")]
        public string Name { get; set; }

        [XmlElement(ElementName = "TeacherAge")]
        public int Age { get; set; }
    }
}
