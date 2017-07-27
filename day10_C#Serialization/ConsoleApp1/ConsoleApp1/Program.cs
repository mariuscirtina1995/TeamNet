using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fisiere !!");

            //read/write example
            //this is in Bin/Debug
            //File.WriteAllText(@"myFirstWrittenFile.txt", "Ana a mancat prea multe mere peste weekend");
            //var text = File.ReadAllText("myFirstWrittenFile.txt");
            //Console.WriteLine(text);


            ////do not forget extension .txt !
            //using (var streamWriter = new FileStream(@"myFirstWrittenFile.txt", FileMode.Create))
            //{
            //    using (var stringReader = new StreamWriter(streamWriter))
            //    {
            //        stringReader.Write("Ana a mancar prea multe pere peste weekend. Mai multe decat Irina!");
            //    }

            //}
            ////var text = File.ReadAllText(@"myFirstWrittenFile.txt");
            ////Console.WriteLine(text);

            //string text = null;
            //using (var streamReader = new FileStream(@"myFirstWrittenFile.txt", FileMode.Open))
            //{
            //    using (var stringReader = new StreamReader(streamReader))
            //    {
            //        text = stringReader.ReadToEnd();
            //    }
            //}
            //Console.WriteLine(text);
            string filePath = null;
            string searchString = null;
            filePath = @"myFirstWrittenFile.txt";
            searchString = @"man";
            Console.WriteLine("Search for string: {0}\n", searchString);

            Console.WriteLine("\nNumber of words that contain the string: {0}", CountWordsThatStartsWith(filePath,searchString));


            Console.ReadLine();
        }

        //just File class
        public static int CountWordsThatStartsWith(string filePath, string searchString)
        {

            var lines = File.ReadAllLines(filePath);
            
            return CountWordsThatStartsWith(lines, searchString);
        }

        //refactorizare cod pentru alti parametrii:
        public static int CountWordsThatStartsWith(string[] lines, string searchString)
        {

            int count = 0;

            foreach (var line in lines)
            {
                String[] elements = line.Split(' ');

                foreach (var elem in elements)
                    if (elem.StartsWith(searchString))
                    {
                        count++;
                    }

                Console.WriteLine(line);
            }
            return count;
        }

        //using streamReader
        public static int CountWordsThatStartsWith2(string filePath, string searchString)
        {

            int count = 0;

            using (var streamReader = new FileStream(filePath, FileMode.Open))
            {
                using (var stringReader = new StreamReader(streamReader))
                {
                    string line = stringReader.ReadLine();
                    while (line != null)
                    {
                        String[] elements = line.Split(' ');

                        foreach (var elem in elements)

                            if (elem.StartsWith(searchString))
                            {
                                count++;
                            }

                        Console.WriteLine(line);
            
                        line = stringReader.ReadLine();
                    }
                }
            }

            return count;
        }

        //var 3 with 1 for:
        public static int CountWordsThatStartsWith3(string filePath, string searchString)
        {

            int count = 0;
            var lines = File.ReadAllText(filePath);

            String[] elements = lines.Split(new String[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var elem in elements)
                if (elem.StartsWith(searchString))
                {
                    count++;
                }

            Console.WriteLine(lines);
            
            return count;
        }

  


    }
}
