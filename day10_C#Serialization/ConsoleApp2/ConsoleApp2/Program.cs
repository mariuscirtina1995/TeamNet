using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {

            //serializare CSV;
            var person1 = new Person() { FirstName = "A", LastName = "B", Age = 12 };
            var person2 = new Person() { FirstName = "C", LastName = "D", Age = 22 };
            var person3 = new Person() { FirstName = "E", LastName = "F", Age = 33 };
            var person4 = new Person() { FirstName = "G", LastName = "H", Age = 44 };
            Serialize(new Person[] { person1, person2, person3, person4 }, "persons.txt");

            Console.WriteLine("\nDeserialize CSV:");

            var allpersons = DeSerialize("persons.txt");

            foreach(var perosn in allpersons)
            {
                Console.WriteLine("First Name: {0} , Last Name {1}, Age {2}", perosn.FirstName, perosn.LastName, perosn.Age);
            }

            SerializeJson(allpersons, "PersonJson.txt");


            Console.WriteLine("\nDeserialize JSON:");

            var allpersons2 = DeSerializeJson("personJson.txt");

            foreach (var perosn in allpersons2)
            {
                Console.WriteLine("First Name: {0} , Last Name {1}, Age {2}", perosn.FirstName, perosn.LastName, perosn.Age);
            }


            Console.ReadLine();
        }

        //serializare CSV
        public static void Serialize(Person[] persons, string filePath)
        {
            var allines = new List<string>();
            foreach(var pers in persons)
            {
                var line = string.Format("{0},{1},{2}", pers.FirstName, pers.LastName, pers.Age);
                allines.Add(line);
                Console.WriteLine(line);
            }

            File.WriteAllLines(filePath, allines);
          
        }

        //DeSerializare CSV
        public static Person[] DeSerialize(string filePath)
        {
            var allines = File.ReadAllLines(filePath);
            var allPersons = new List<Person>();

            foreach (var line in allines)
            {
                var items = line.Split(',');
                int age = 0;

                if(!int.TryParse(items[2], out age))
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

        //Serializare JSon
        public static void SerializeJson(Person[] persons, string filepath)
        {
            var serializer = new JavaScriptSerializer();
            var alltext = serializer.Serialize(persons);

            File.WriteAllText(filepath, alltext);

        }

        //DeSerializare JSon
        public static Person[] DeSerializeJson(string filepath)
        {
            var serializer = new JavaScriptSerializer();

            var allText = File.ReadAllText(filepath);

            var allPersons = serializer.Deserialize<Person[]>(allText);

            return allPersons;
        }

    }
}
