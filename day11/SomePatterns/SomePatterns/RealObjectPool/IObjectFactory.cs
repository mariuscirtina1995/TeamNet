using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.RealObjectPool
{
    public interface IObjectFactory<T>
    {
        T Create(T obj);
    }
}
