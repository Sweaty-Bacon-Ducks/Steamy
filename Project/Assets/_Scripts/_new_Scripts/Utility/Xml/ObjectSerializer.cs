using System;
using System.IO;
using System.Xml.Serialization;
namespace Steamy.Utility.Xml
{
    public static class ObjectSerializer<T>
    {
        /// <summary>
        /// </summary>
        /// <param name="Destination"></param>
        /// <param name="obj"></param>
        /// <param name="subClassTypes"></param>
        public static void SaveToXml(string Destination, T obj, Type[] subClassTypes)
        {
            // Create a new serializer
            var serializer = new XmlSerializer(obj.GetType(), extraTypes: subClassTypes);

            // Open the file
            using (var filestream = new FileStream(path: Destination,
                  mode: FileMode.CreateNew))
            {
                serializer.Serialize(stream: filestream, o: obj);
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <param name="subClassTypes"></param>
        /// <returns></returns>
        public static T ReadFromXml(string xmlPath, Type[] subClassTypes)
        {
            var serializer = new XmlSerializer(typeof(T), subClassTypes);

            // Handle the unknown nodes and attributes
            serializer.UnknownNode += serializer.UnknownNodeCallback;
            serializer.UnknownAttribute += serializer.UnknownAttributeCallback;

            // Open the file
            using (var filestream = new FileStream(path: xmlPath,
                  mode: FileMode.Open))
            {
                // TODO: copy constructor
                var deserializationResult = serializer.Deserialize(stream: filestream);
                return (T)deserializationResult;
            }
        }
    }
}
