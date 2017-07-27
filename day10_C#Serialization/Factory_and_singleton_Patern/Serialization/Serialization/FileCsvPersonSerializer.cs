using System;
using System.Collections.Generic;
using System.IO;

namespace Serialization
{
    internal class FileCsvPersonSerializer : IFilePersonSerializer
    {
        CsvPersonSerializer serializer = new CsvPersonSerializer();

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