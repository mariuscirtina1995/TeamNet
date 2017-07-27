using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Serialization
{
    public class JsonPersonSerializer : IPersonSerializer
    {
        public Person[] Deserialize(string text)
        {
            return new JavaScriptSerializer().Deserialize<Person[]>(text);
        }

        public string Serialize(Person[] entities)
        {
            return new JavaScriptSerializer().Serialize(entities);
        }
    }
}
