using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Program
    {
        static void Main(string[] args)
        {
            var adriana1 = new Adriana { Id = 1, Name = "Adriana" };
            var adriana2 = new Adriana { Id = 1, Name = "Adriana" };
            var adriana3 = new Adriana { Id = 3, Name = "Adriana" };
            var adriana4 = adriana1;

            Console.WriteLine(adriana1.Equals(adriana2));
            Console.WriteLine(adriana1.Equals(adriana3));
            Console.WriteLine(adriana1 == adriana2);

            Console.WriteLine(adriana1.Equals(adriana4));
            Console.WriteLine(adriana1 == adriana4);

            Console.ReadLine();
        }
    }

    public class Adriana
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            Adriana x = obj as Adriana; //object cast to Adriana chiar daca e null
            if (x == null)
                return false;
            else
                return x.Id == this.Id && x.Name == this.Name;

        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }


    }




}
