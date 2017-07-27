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
                div = rezult;
                return false;

            }

            div = rezult;
            return true;

        }

        class Program
        {
            public static void Main ()
            {
                IList<IBallanceAccount> list = new List<IBallanceAccount>()
                {
                    new BallanceAccount { Value = 1 },
                    new BallanceAccount { Value = 2 },
                    new BallanceAccount { Value = 3 },
                };


                Execute(list, 2);
                Execute(list, 0);

                Console.ReadLine();
                
            }

            public static void Execute(IList<IBallanceAccount> list, int div)
            {
                int rezult;

                if (new Service().Divide(list, div, out rezult))
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
