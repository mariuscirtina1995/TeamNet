using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class PersonSerializerFactory : IPersonSerializerFactory
    {
        public IPersonSerializer Create(FormattingType type)
        {
            switch (type)
            {
                case FormattingType.Csv:
                    return new CsvPersonSerializer();
                case FormattingType.Json:
                    return new JsonPersonSerializer();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
