using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        internal protected void MyProtectedInternalMethod()
        {
            Console.WriteLine("My Protected Internal Method");
        }

        public void MyPublicMethod()
        {}

        private void MyPrivateMethod()
        {}

        internal void MyInternalMethod()
        { }

    }
}
