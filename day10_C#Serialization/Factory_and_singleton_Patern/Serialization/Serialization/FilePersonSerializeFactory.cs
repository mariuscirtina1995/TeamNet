using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class FilePersonSerializeFactory : IFilePersonSerializerFactory
    {
        public IFilePersonSerializer Create(FormattingType type)
        {
            switch (type)
            {
                case FormattingType.Csv:
                    return new FileCsvPersonSerializer();
                case FormattingType.Json:
                    return new FileJsonPersonSerializer();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
