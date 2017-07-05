using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass("Marius");
            myClass.MyIntProperty = 12;
            //myClass.MyStringProperty = "Imi este foame !!";

            Console.WriteLine(myClass.MyIntProperty);
            Console.WriteLine(myClass.MyStringProperty);
            Console.WriteLine(myClass[1]);

            //String Formating
            string bla = "Abracadabra {0} {1}!!!";
            string format_String = String.Format("text {0} {1} {0}", "1", "Rovert");
            bla = String.Format(bla, "1", "Robert");
            Console.WriteLine(format_String);
            Console.WriteLine(bla);
            Console.WriteLine();

            //ToString Method Override
            Console.WriteLine(myClass.ToString());
            var dayTime = new DateTime(2017, 07, 05);
            Console.WriteLine(dayTime);

            //Culture
            var culture = new CultureInfo("ro-RO");
            dayTime = DateTime.Now;
            Console.WriteLine(dayTime.ToString(culture));
            Console.WriteLine();

            decimal d = 1.5m; //for currency
            Console.WriteLine(d.ToString("C4", culture));
            int i = 5;
            Console.WriteLine(i.ToString("#.00", culture));
            //documentation: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#CFormatString
            d = 1.555555m;
            Console.WriteLine(d.ToString("G4"));
            Console.WriteLine();

            ////string parse
            //var tr = int.tryparse(console.readline(), out i); //variabila cu nume unic in contextul (metoda in care ne aflam)
            //console.writeline(i + " " + tr); //default int i = 0; tr bool from tryparse
            //console.writeline();

            Console.WriteLine(default(int)); //default int;
            Console.WriteLine("'" + default(string) + "'"); //defautl string
            Console.WriteLine(default(DateTime)); //default daytine
            Console.WriteLine();

            var date = DateTime.Parse("01.02.2000");
            Console.WriteLine(date.ToString(CultureInfo.InvariantCulture));
            Console.WriteLine();

            //Converting between types
            //long l = long.MaxValue;
            //int f = 10;
            //l = f; //automatic conversion long -> int
            //Console.WriteLine(l);
            //l = long.MaxValue - int.MaxValue;
            //f = (int) l; //cast form long to int 
            //Console.WriteLine(f);

            var x = Convert.ToInt32('A'); //returns ASCHI code of A
            Console.WriteLine(x);
            Console.WriteLine();

            var new_reference_class = new Class1("1234");
            var new_var = new_reference_class.GetMyint(); //class1 goes getMyInt();
            Console.WriteLine(new_var);
            Console.WriteLine();

            //var s = "test";
            //s.GetValue();


            //Console.WriteLine("Exceptii");
            ////exception controll:
            //int tr = 0;

            //try
            //{
            //    //throw new MyException();
            //    tr = int.Parse(Console.ReadLine()); //nu ajunge aici Warning!!
            //}

            //catch (ArgumentNullException e) //Nu prinde aceasta excpetie!!!
            //{
            //    //tratare exceptie!!! 
            //    Console.WriteLine("EROARE!");
            //    Console.WriteLine(e);
            //}

            //catch (MyException e)
            //{
            //    Console.WriteLine(e.ToString());
            //    // throw; //can throw this exception to another try block;
            //}

            //catch (FormatException e)
            //{
            //    //tratare exceptie!!!
            //    Console.WriteLine("EROARE Format EXception!");
            //    Console.WriteLine(e);
            //}
            //finally
            //{
            //    Console.WriteLine("Am terminat rezultatul este :");
            //    Console.WriteLine(tr);
            //}
            //Console.WriteLine();

            //Arrtays:
            //Console.WriteLine();
            //Console.WriteLine("ARRAYES!!!");
            //Console.WriteLine();

            //int[] arr = new int[10]; //verctor de 10 el
            //int[,] arr2 = new int[10,10]; //matrice de array; arr2[0,0] -- first element
            //int[][] arr3 = new int[20][];  //jagged array array de array;
            //arr3[0] = new int[20]; //first array form arr3; arr3[0][0] -- first element

            //int[] v = new int[4] { 1, 2, 3, 4 }; //initializare;

            //for(i = 0; i < v.Length; i++)
            //{
            //    Console.WriteLine(i + " " + v[i]);
            //}

            //foreach (int index in v)
            //{
            //    Console.WriteLine(index);
            //}

            Console.WriteLine("Lists!!!");
            List<int> v = new List<int>();
            v.Add(1); //index 0
            v.Add(2); //index 1
            v.Add(3); // 2
            v.Add(4); // 3
            v.Add(5); // 4

            v.Insert(4, 6); // index 5, val 6;

            foreach (int val in v)
                Console.WriteLine(val);

            Console.WriteLine();

            i = 0;
            while( i < 5)
            {
                Console.WriteLine("While !!" + "  " + i);
                i++;
            }

            i = 0;
            Console.WriteLine();

            do
            {
                Console.WriteLine("Do While !!" + "  " + i);
                i++;
            }
            while (i < 5);
            
            MyEnum x2 = MyEnum.Value3;
            switch (x2)
            {
                case MyEnum.Value1:
                    Console.WriteLine();
                    Console.WriteLine((int)MyEnum.Value1);
                    break;

                case MyEnum.Value2:
                    Console.WriteLine();
                    Console.WriteLine((int)MyEnum.Value2);
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Nimic!");
                    break;

            }
            Console.WriteLine();

            //DONE !!!

            

            Console.ReadLine();
        }
    }

    public enum MyEnum
    {
        Value1 = 0,
        Value2 = 1,
        Value3 = 2,
    }

    public class MyClass
    {
        public MyClass(string name)
        {
            MyStringProperty = name;
        }

        private int myIntProperty;

        public int MyIntProperty
        {
            get
            {
                Console.WriteLine("Colling getter!");
                return myIntProperty;
            }
            set
            {
                Console.WriteLine("Colling Setter!");
                myIntProperty = value;
            }
        }

        public string MyStringProperty { get; private set; } //accesibility control!!

        public int this[int i] //property 
        {
            get
            {
                return i;
            }

        }

        public override String ToString()
        {
            return MyStringProperty;
        }

    }

    public static class MyExtention
    {
        public static int GetMyint(this Class1 c) //class1 extends GetMyInt()
        {
            return int.Parse(c.GetMyString());
            //return Convert.ToInt32(c.GetMyString());

        }

        public static int GetValue(this string s)
        {
            return s.Length / 2;
        }

    }

    public class MyException : Exception
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
