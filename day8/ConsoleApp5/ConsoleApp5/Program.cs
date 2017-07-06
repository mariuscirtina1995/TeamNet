using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public static class Program
    {
        public static MailBox mailRoom = new MailBox();
        public static MailSorter boyWhoSorts = new MailSorter();

        static void Main(string[] args)
        {
            //legarea are prioritate !!!! Am pierdut jumate de ou pe asta !!
            mailRoom.MailReceived += MailRoom_MailReceived;
            boyWhoSorts.PlicWithAddress += BoyWhoSorts_PlicWithAddress;
            //boyWhoSorts.PlicWithoutAddress += BoyWhoSorts_PlicWithoutAddress;

            //anonymus method:
            boyWhoSorts.PlicWithoutAddress += (object sender, int e) =>
            {
                Console.WriteLine(String.Format("Evenimentul {0} a trimis plic fara adresa", e));
            };

            mailRoom.Generate();
            Console.ReadLine();
        }

        private static void MailRoom_MailReceived(object sender, Plic e)
        {
            boyWhoSorts.MailReceived(e);
            //mailRoom.MailReceiveExtension(e);
        }

        private static void BoyWhoSorts_PlicWithoutAddress(object sender, int e)
        {
            Console.WriteLine(String.Format("Evenimentul {0} a trimis plic fara adresa", e));
        }

        private static void BoyWhoSorts_PlicWithAddress(object sender, int e)
        {
            Console.WriteLine(String.Format("Evenimentul {0} a trimis plic cu adresa", e));
        }
    }



}
