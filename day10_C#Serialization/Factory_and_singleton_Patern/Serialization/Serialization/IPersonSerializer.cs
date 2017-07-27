using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public interface IPersonSerializer
    {
        string Serialize(Person[] entities);
        Person[] Deserialize(string text);
    }
}
