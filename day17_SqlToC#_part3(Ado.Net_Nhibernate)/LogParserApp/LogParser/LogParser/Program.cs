using LogParser.Nh;
using LogParser.Parsing;
using LogParser.Transforming;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if(1 > args.Length)
            {
                Console.WriteLine(@"Primul argument este calea catre fisier");
                return;
            }

            var filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.WriteLine(string.Format(@"Fisierul {0} nu exista", filePath));
                return;
            }

            var lineParsers = new ILineParser[] { new RequestLineParser(), new SnmpLineParser() };
            var transformer = new DictionaryToAtacLogTransformer();
            var logFileReader = new LogFileReader(filePath, lineParsers, transformer);

            var entities = logFileReader.Read();

            Console.WriteLine(entities.Count);

            var cnt = 0;

            var connectionString = ConfigurationManager.ConnectionStrings["conpot"].ConnectionString;
            using (var sessionFactory = new NhConfig(connectionString).Create())
            {
                using(var session = sessionFactory.OpenSession())
                {
                    foreach(var entity in entities)
                    {
                        session.Save(entity);
                        cnt++;

                        if(cnt % 300 == 0)
                        {
                            Console.WriteLine(string.Format(@"Saved {0}", cnt));
                        }
                    }

                    session.Flush();
                }
            }

            Console.WriteLine(string.Format(@"Saved {0}", cnt));
            Console.ReadLine();

        }
    }
}
