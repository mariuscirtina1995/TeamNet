using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class PersonSerializing : IPersonSerializerFactory
    {
        public IPersonSerializer Create(FormatingType type)
        {
            switch (type)
            {
                case FormatingType.Csv:
                    return new CsvPersonSerializer();

                case FormatingType.Json:
                    return new JsonPersonSerializer();

                default:
                    throw new NotImplementedException();
            }
                 

        }
    }
}
