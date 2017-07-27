using SomePatterns.RealObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.ObjectPool
{
    public interface IFarfurieFactory// : IObjectFactory<Farfurie>
    {
        Farfurie Create();
    }
}
