using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class FilePersonSerializer : IFilePersonSerializer
    {
        public Person[] DeSerialize(string filePath)
        {
            throw new NotImplementedException();
        }

        public void Serialize(Person[] entities, string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
