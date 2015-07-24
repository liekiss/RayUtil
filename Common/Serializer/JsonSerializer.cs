using System;
using Newtonsoft.Json;

namespace RayUtil.Serializer
{
    public class JsonSerializer
    {
        public static string Serialize<T>(T source)
        {
            return Serialize(source, null);
        }

        public static string Serialize<T>(T source, JsonSerializerSettings settings)
        {
            try
            {
                string result = JsonConvert.SerializeObject(source, settings);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T Deserialize<T>(string json)
        {
            return Deserialize<T>(json, null);
        }

        public static T Deserialize<T>(string json, JsonSerializerSettings settings)
        {
            try
            {
                T result = JsonConvert.DeserializeObject<T>(json, settings);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
