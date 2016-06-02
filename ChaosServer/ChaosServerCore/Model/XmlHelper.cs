using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ChaosServerCore.Model
{
    public class XmlHelper
    {
        public static string Serialize<T>(T item)
        {
            string result;
            var serializer = new XmlSerializer(typeof(T));

            using (var stringWriter = new StringWriter())
            using (var writer = XmlWriter.Create(stringWriter))
            {
                serializer.Serialize(writer, item);
                result = stringWriter.ToString();
            }

            return result;
        }

        public static T Deserialize<T>(string serializedItem)
        {
            T item;
            var serializer = new XmlSerializer(typeof(T));

            using (var stringReader = new StringReader(serializedItem))
            {
                item = (T)serializer.Deserialize(stringReader);
            }

            return item;
        }
    }
}
