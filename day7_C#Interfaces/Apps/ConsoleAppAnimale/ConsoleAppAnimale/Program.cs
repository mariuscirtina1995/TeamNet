using System;

namespace ConsoleAppAnimale
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Jurasic World!");
            Console.WriteLine();

            //var the system knows what it is it cat be refactorized!
            var din1 = new Trex();
            var din2 = new Triceropots();
            var din3 = new Pterodactil();

            Console.WriteLine("Trex: ");
            din1.Eat();
            din1.Move();

            Console.WriteLine();
            Console.WriteLine("Triceropots: ");
            din2.Eat();
            din2.Move();

            Console.WriteLine();
            Console.WriteLine("Pterodactil: ");
            din3.Eat();
            din3.Move();

            Console.WriteLine();
            Console.WriteLine("Number of Dinozauri: " + Dinozaur.number);

            Console.ReadLine();

        }
    }

    public interface IDinozaur
    {
         void Eat();
         void Move();
    }

    public abstract class Dinozaur : IDinozaur
    {
        public static int number = 0;

        public Dinozaur()
        {
            number += 1;
        }

        public void Eat()
        {
            Console.WriteLine("Mananca!");
        }

        public abstract void Move(); //Abstract class for no definition!!

    }

    public class Trex : Dinozaur
    {
        public Trex() { }

        public override void Move() //override from abstract class
        {
            Console.WriteLine("Alearga repede!");
        }

    }

    public class Triceropots : Dinozaur
    {
        public Triceropots() { }

        public override void Move() //override from abstract class
        {
            Console.WriteLine("Abia se misca!");
        }

    }

    public class Pterodactil : Dinozaur
    {
        public Pterodactil() { }

        public override void Move() //override from abstract class
        {
            Console.WriteLine("Zboara!");
        }

    }

}