using System;
using System.IO;

namespace RayUtil.Serializer
{
    public class XmlSerializer
    {
        public static void Serialize(string path, object source)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    System.Xml.Serialization.XmlSerializer serialize =
                        new System.Xml.Serialization.XmlSerializer(source.GetType());
                    serialize.Serialize(writer, source);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T Deserialize<T>(string path)
        {
            try
            {
                object result = null;
                using (StreamReader reader = new StreamReader(path))
                {
                    System.Xml.Serialization.XmlSerializer serialize = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    result = serialize.Deserialize(reader);
                }
                return (T)result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
