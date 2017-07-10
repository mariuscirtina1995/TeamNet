using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public abstract class FilePersonSerializer : IFilePersonSerializer
    {
        protected IPersonSerializer serializer;

        public FilePersonSerializer(IPersonSerializer serializer)
        {
            this.serializer = serializer;
        }

        public Person[] Deserialize(string filePath)
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
