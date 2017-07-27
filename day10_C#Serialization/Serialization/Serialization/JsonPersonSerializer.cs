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
            var serializer = new JavaScriptSerializer();

            var allPersons = serializer.Deserialize<Person[]>(text);

            return allPersons;
        }

        public string Serialize(Person[] entities)
        {
            var serializer = new JavaScriptSerializer();
            var alltext = serializer.Serialize(entities);

            return alltext;
        }
    }
}
