using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.RealObjectPool
{
    public interface IObjectPool<T>
    {
        T Create();

        void Release(T current);
    }
}
