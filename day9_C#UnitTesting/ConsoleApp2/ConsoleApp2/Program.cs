using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Fibonaci(10));
            //Console.WriteLine(RecFib(1,1,10));

            string str = "Imi place sa ma uit la Gordon Ramsay";
            Console.WriteLine(Reverse(str));
    
            Console.WriteLine(str1);

            Console.ReadLine();
        }

        public static int Fibonaci(int x)
        {
            int x1 = 1; //0
            int x2 = 1; //1
            int rez = 0; //rezultat
            int i = 1; //index

            while(i < 10)
            {
                rez = x1 + x2;
                x1 = x2;
                x2 = rez;
                i++;
            }

            return rez;
        }

        //fibonaci Recursiv
        public static int RecFib(int x1, int x2, int n)
        {
            if (n == 1)
                return x2;
                    
            return RecFib(x2, x1 + x2, n - 1);
        }

        //varianta 
        public static string Reverse(String str)
        {
            int j = str.Length - 1;
            string s = null;

            while(j >= 0)
            {
                s += str[j];
                j--;
            }

            return s;
        }


        public static string ReverseV2(String str)
        {
            StringBuilder s1 = new StringBuilder();

        }
    }
}
