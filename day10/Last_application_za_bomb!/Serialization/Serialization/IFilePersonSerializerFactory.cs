using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public interface IFilePersonSerializerFactory
    {
        IFilePersonSerializer Create(FormattingType type);
    }
}
