using System;
using System.IO;
using System.Web.Script.Serialization;

namespace Serialization
{
    internal class FileJsonPersonSerializer : IFilePersonSerializer
    {
        JsonPersonSerializer serializer = new JsonPersonSerializer();

        public Person[] DeSerialize(string filePath)
        {
            var text = File.ReadAllText(filePath);
            return serializer.Deserialize(text);
        }

        public void Serialize(Person[] entities, string filePath)
        {
            var text = serializer.Serialize(entities);

            File.WriteAllText(filePath, text);
        }
    }
}