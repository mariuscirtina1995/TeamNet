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
            int x = 2;
            int y = x.VreauSaFiuDublu();
            Console.WriteLine(y);

            Console.ReadLine();

            var p_Mere = new Cutie<Mere>();
            p_Mere.Continut.AreGurstBun();

        }
    }

    //Method Extension
    public static class IntExtension
    {
        public static int VreauSaFiuDublu(this int x) //extension Method entry point
        {
            return x * 2;
        }
    }

    //Generics:
    public class Cutie<T> 
        where T : IFruct
    {
        public String Timbru { get; set; }
        public String Addresa { get; set; }
        public T Continut { get; set; }

    }

    public interface IFruct
    {
        bool AreGurstBun();
    }

    public class Mere : IFruct
    {
        public bool AreGurstBun()
        {
            return true;
        }
    }



}
