using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class CsvFilePersonSerializer : FilePersonSerializer
    {
        public CsvFilePersonSerializer() : 
            base(new CsvPersonSerializer())
        {

        }
    }
}
