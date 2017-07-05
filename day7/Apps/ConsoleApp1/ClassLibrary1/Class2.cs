using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class2
    {
        public Class2()
        {
            var class1 = new Class1();
            class1.MyProtectedInternalMethod();
            class1.MyInternalMethod();
        }
    }
}
