using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{

    public delegate void ForShowingInt(int x, int y, int z);

    class Program
    {

        //delegate:
        delegate int Add(int x1, int x2);

        public static int Maria(int x1, int x2)
        {
            return x1 + x2;
        }

        public int Ion(int x1, int x2)
        {
            return x1 + x2;
        }

        //public int NewMethod(int x1, int x2)
        //{
        //    return Ion(x1, x2);
        //}


        static void Main(string[] args)
        {
            //Delegate Test:
            //Console.WriteLine(Maria(1, 2));
            //Add MyReference = Maria;
            //Console.WriteLine(MyReference(1,2));
            //var p = new Program();
            //Add MyReference2 = p.Ion;
            //Console.WriteLine(MyReference2(1, 2));

            var factura = new Factura();
            //factura.FacuraChanged += Factura_FacuraChanged; //legam delegatul din dreapta la evenimentul din factura;
            //factura.FacuraChanged += Factura_FacuraChanged2; //--//-- legam alta functie la eveniment;

            //factura.FacturaReallyChanged += ShowValoare; //legare de ShowValoare a eventului din factura;
            factura.FacturaReallyChanged += (a, b, c) =>
            {
                Console.WriteLine(String.Format("Factura este: {0}, dublu este :{1}, tripul este: {2}", a, b, c)); //metoda Anonima!!
            };

            factura.Valoare = 2;
            factura.Valoare = 3;
            factura.Valoare = 4;

            ShowSold(factura);
            factura.Sold = 100;
            ShowSold(factura);
            factura.Sold = null;
            ShowSold(factura);

            Console.ReadLine();
        }

        private static void Factura_FacuraChanged(object sender, int e)
        {
            ShowValoare(e);
        }
        private static void Factura_FacuraChanged2(object sender, int e)
        {
            Console.WriteLine("I have been called!");
        }

        private static void ShowValoare(Factura factura)
        {
            //Console.WriteLine(String.Format("Factura are valoarea = {0}", factura.Valoare));
            ShowValoare(factura.Valoare);
        }

        private static void ShowValoare(int valoare)
        {
            Console.WriteLine(String.Format("Factura are valoarea = {0}", valoare));
        }

        private static void ShowSold(Factura factura)
        {
            if(factura.Sold.HasValue)
            {
                Console.WriteLine(String.Format("Factura are soldul: {0}", factura.Sold.Value));
            }
            else
            {
                Console.WriteLine("Factura nu are sold!");
            }

        }
    }

    
}
