using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = Database.Instance;

            Console.WriteLine(database.Name);

            Console.ReadLine();
        }
    }
}
