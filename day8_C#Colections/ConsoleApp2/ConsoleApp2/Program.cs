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
            var p = new Paprika();
            try
            {
                using (p)
                {
                    throw new Exception("abracadabra!");
                }//dispose of paprika !!!
            }
            catch
            {

            }

            p = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.ReadLine();
        }
    }

    public class Paprika : IDisposable
    {
        public Paprika()
        {
            Console.WriteLine("I HAVE PAPRIKA!");
        }

        ~Paprika()
        {
            Console.WriteLine("NO MORE PAPRIKA!");
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose PAPRIKA");
        }
    }
    
}
