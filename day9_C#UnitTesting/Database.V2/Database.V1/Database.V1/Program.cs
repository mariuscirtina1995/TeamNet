using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.V1
{
    class Program
    {
        static void Main(string[] args)
        {
            object x = new Dosar();
            //Console.WriteLine(x.GetType());
            //Console.WriteLine(typeof(Dosar));

            Print(x); //sees the type of x

            Console.ReadLine();
        }

        private static void Print<T>(T x)
        {
            Console.WriteLine(x.GetType());
            Console.WriteLine(typeof(Dosar));
            Console.WriteLine(typeof(T)); //can go type of T in method !!
        }
    }
}
