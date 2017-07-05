using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public interface IBallanceAccount
    {
         int Value { get; }
    }

    public class BallanceAccount : IBallanceAccount
    {
        public int Value { get; set; }
    }

    public class Service
    {
        public bool Divide(IList<IBallanceAccount> list , int divider, out int div)
        {
            var suma = list.Select(a => a.Value).Sum();

            int rezult = 1;
            try
            {
                rezult = suma / divider;
            }
            catch (DivideByZeroException)
            {
                rezult = -1;
                return false;

            }

            return true;


        }

        class Program
        {
            public static void main ()
            {
                IList<IBallanceAccount> list = new List<IBallanceAccount>();

                int rezult;

                if(new Service().Divide(list, 1, out rezult))
                {
                    Console.WriteLine(rezult);
                }
                else
                {
                    Console.WriteLine("Some Error!");
                }

            }
        }
    }

}
