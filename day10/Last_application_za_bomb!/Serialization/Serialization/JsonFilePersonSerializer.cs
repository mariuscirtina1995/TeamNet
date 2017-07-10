using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class JsonFilePersonSerializer : FilePersonSerializer
    {
        public JsonFilePersonSerializer() : 
            base(new JsonPersonSerializer())
        {

        }
    }
}
