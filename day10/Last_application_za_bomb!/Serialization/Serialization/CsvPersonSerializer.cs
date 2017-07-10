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
            var allLines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var allPersons = new List<Person>();

            foreach (var line in allLines)
            {
                var items = line.Split(',');
                int age = 0;

                if (!int.TryParse(items[2], out age))
                {
                    continue;
                }

                var person = new Person
                {
                    FirstName = items[0],
                    LastName = items[1],
                    Age = age
                };

                allPersons.Add(person);
            }

            return allPersons.ToArray();
        }

        private string Serialize(Person person)
        {
            return string.Format(@"{0},{1},{2}"
                        , person.FirstName
                        , person.LastName
                        , person.Age);
        }

        public string Serialize(Person[] entities)
        {
            var sb = new StringBuilder();

            if(0 < entities.Length)
            {
                sb.Append(Serialize(entities[0]));
            }

            for (int i = 1; i < entities.Length; i++)
            {
                var person = entities[i];

                sb.AppendLine();

                sb.Append(Serialize(person));
            }


            return sb.ToString();
        }
    }
}
