using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.RealObjectPool
{
    public class ObjectFactory<T> : IObjectFactory<T>
    {
        public T Create(T obj)
        {
            return obj;
        }
    }
}
