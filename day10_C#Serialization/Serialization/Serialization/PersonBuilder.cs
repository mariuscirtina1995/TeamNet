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

        public PersonBuilder PersonWithFirstName(string value)
        {
            person.FirstName = value;
            return this;
        }

        public PersonBuilder PersonWithLastName(string value)
        {
            person.LastName = value;
            return this;
        }

        public PersonBuilder Get(string value)
        {
            return this;
        }
    }
}
