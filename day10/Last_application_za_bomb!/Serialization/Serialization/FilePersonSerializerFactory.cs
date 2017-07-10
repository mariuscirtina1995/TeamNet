using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class FilePersonSerializerFactory : IFilePersonSerializerFactory
    {
        private static FilePersonSerializerFactory instance;
        private FilePersonSerializerFactory()
        { }
        static FilePersonSerializerFactory()
        {
            instance = new FilePersonSerializerFactory();
        }
        public static FilePersonSerializerFactory Instance
        {
            get
            {
                return instance;
            }
        }
             
        public IFilePersonSerializer Create(FormattingType type)
        {
            switch (type)
            {
                case FormattingType.Csv:
                    return new CsvFilePersonSerializer();
                case FormattingType.Json:
                    return new JsonFilePersonSerializer();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
