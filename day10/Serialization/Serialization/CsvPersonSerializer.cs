using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class CsvPersonSerializer : IPersonSerializer
    {
        public Person[] Deserialize(string text)
        {
            var allPersons = new List<Person>();
            var allines = text.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in allines)
            {
                var items = line.Split(',');
                int age = 0;

                if (!int.TryParse(items[2], out age))
                {
                    continue;
                }

                var person = new Person()
                {
                    FirstName = items[0],
                    LastName = items[1],
                    Age = age
                };

                allPersons.Add(person);

            }

            return allPersons.ToArray();
        }

        public string Serialize(Person[] entities)
        {

            StringBuilder serializedString = new StringBuilder();

            if (0 < entities.Length)
            {
                var line = string.Format(
                    "{0},{1},{2}", 
                    entities[0].FirstName, entities[0].LastName, entities[0].Age);
            }
           
            for (int i = 0; i < entities.Length; i++)
            {
                var line = string.Format(
                    "{0},{1},{2}", 
                    entities[i].FirstName, entities[i].LastName, entities[i].Age);

                if (i == 0)
                    serializedString.Append(line);
                else
                {

                    serializedString.Append(Environment.NewLine);
                    serializedString.Append(line);
                }
            }

            return serializedString.ToString();
        }
    }
}
