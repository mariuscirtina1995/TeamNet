using System;
using ClassLibrary1; //for ClassLibrary1;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        const string myFirstConst = "gigi";
        static int myFirstStatic = 0;
        int myFirstField;


        const char caracter = 'C';
        string sir = "C# e bomba!";
        private static int static_var;

        public Program(int myFirstField)
        {
            this.myFirstField = myFirstField;
            //Console.WriteLine(this.sir);
            myFirstStatic += 1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(sizeof(int));
            Console.WriteLine(sizeof(long));
            Console.WriteLine(typeof(Program));
            Console.WriteLine();

            Console.WriteLine(Convert.ToInt16(' ')); // int 32 si convert toString din WriteLine

            var a = new Program(999);
            Console.WriteLine(Program.myFirstStatic + " " + a.myFirstField);


            var b = new Program(999 - 888);
            Console.WriteLine(Program.myFirstStatic + " " + b.myFirstField);

            var dayCar = new ModelS();

            var class1 = new Class1(); //from ClassLibrary!
            class1.MyPublicMethod();


            Console.ReadLine();
        }
    }

    public interface ICar
    {
        bool Start();
        bool Stop();

    }

    public abstract class AbstractCar : ICar
    {
        public abstract bool Start();

        public bool Stop()
        {
            return true;
        }

    }

    public class ModelS : AbstractCar
    {
        public ModelS() { }

        public override bool Start()
        {
            throw new NotImplementedException();
        }

        public new bool Stop()
        {
            return true;
        }

    }

    enum DaysOfWeek
    {

        Monday = 500,
        Tuesday = 700,
        Sunday = 900

    };

    struct MySpecialDate
    {

        public uint year;
        public byte month;
        public byte day;

    }

    public class Class3 : Class1
    {
        public Class3()
        {
            this.MyProtectedInternalMethod(); //Internalll !!!!
            this.MyPublicMethod();
        }
    }

}
