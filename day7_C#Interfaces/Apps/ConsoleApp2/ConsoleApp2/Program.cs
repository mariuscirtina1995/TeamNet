using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine(new Program().Add(1, 2));
            int z;
            if (new Program().Add(100, 450, out z))
            {
                Console.WriteLine(z);
            }
            else
                Console.WriteLine("Nu este bun rezultatul!");

            z = 700000;

            if (new Program().Add1(2, 3, ref z))
            {
                Console.WriteLine(z);
            }
            else
                Console.WriteLine("Nu este bun rezultatul!");

            Console.ReadLine();

        }

        protected virtual int Add (int x, int y)
        {
            return x + y;
        }

        //overload add(x,y);
        int Add(int x, int y, int z, int t)
        {
            return x +y + z + t;
        }

        bool Add (int x, int y, out int z)
        {
            z = x + y;
            return z > 500;
       
        }

        bool Add1(int x, int y, ref int z)
        {
            //z = x + y; //nu trebuie asignat inainte de a iesi din metoda.
            return z > 500;

        }

    }

    class SubProgram : Program
    {
        protected override int Add(int x, int y)
        {
            //return x * x +y * y;
           return Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        }

        public int Add(params int[] ints)
        {
            return ints.Sum();
        }
    }
}
