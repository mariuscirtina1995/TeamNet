using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class PersonBuilder
    {
        private Person person = new Person();

        public PersonBuilder WithFirstName(string value)
        {
            person.FirstName = value;
            return this;
        }

        public PersonBuilder WithLastName(string value)
        {
            person.LastName = value;
            return this;
        }

        public PersonBuilder WithAge(int value)
        {
            person.Age = value;
            return this;
        }

        public Person Get()
        {
            return person;
        }
    }
}
