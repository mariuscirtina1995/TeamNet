using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program : BalanceAccount
    {


        static void Main(string[] args)
        {

            IList<IBalanceAccount> list = new List<IBalanceAccount>()
            {
                new BalanceAccount { Value = 1 },
                new BalanceAccount { Value = 2 },
                new BalanceAccount { Value = 3 },

            };


            Console.WriteLine(Divide(list, 2));
            Console.WriteLine(Divide(list, 0));

            Console.ReadLine();

        }

        public static int Divide (IList<IBalanceAccount> list, int divider)
        {
            int sum = 0;

            foreach ( BalanceAccount val in list)
            {
                sum += val.Value;
            }

            try
            {
                sum = sum / divider;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Divizion by zero!");
            }

            return sum;
        }
    }

    public class BalanceAccount : IBalanceAccount
    {
        public int Value { get; set; }
    }

    public interface IBalanceAccount
    {
        int Value { get; }
    }



}
