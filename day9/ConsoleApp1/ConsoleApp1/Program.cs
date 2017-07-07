using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Day 10 !\n");

            var factura = new Factura() { Id = 1, Name = "Gigi" };
            var factura1 = new Factura() { Id = 2, Name = "Ming" };

            var list = new List<Factura>
            {
                factura
            };

            var dict = new Dictionary<string, List<Factura>>();
            dict.Add("2017", new List<Factura>() { factura, factura1 });
            dict.Add("2018", new List<Factura>() { factura1 });


            var retreived = dict["2017"];
            var retreived2 = dict["2018"];


            Console.WriteLine(
               String.Format(
                   @"Got List pe 2017 Conut {0}, Name = {1}, Name = {2}",
                   retreived.Count,
                   retreived[0].Id,
                   retreived[0].Name));

            Console.WriteLine(
                String.Format(
                    @"Got List pe 2017 Conut {0}, Name = {1}, Name = {2}", 
                    retreived2.Count, 
                    retreived2[0].Id, 
                    retreived2[0].Name ));




            Console.ReadLine();
        }
    }
}
