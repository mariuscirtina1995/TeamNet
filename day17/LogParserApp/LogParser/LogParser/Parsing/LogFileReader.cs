using LogParser.Entities;
using LogParser.Transforming;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Parsing
{
    public class LogFileReader
    {
        private string filePath;
        private ILineParser[] lineParsers;
        private DictionaryToAtacLogTransformer transformer;

        public LogFileReader(string filePath, ILineParser[] lineParsers, DictionaryToAtacLogTransformer transformer)
        {
            this.lineParsers = lineParsers;
            this.filePath = filePath;
            this.transformer = transformer;
        }

        public IList<AtacLog> Read()
        {
            var result = new List<AtacLog>();

            var allLines = File.ReadAllLines(filePath);

            foreach(var line in allLines)
            {
                foreach(var parser in lineParsers)
                {
                    Dictionary<string, string> dict;

                    if(!parser.CanParse(line, out dict))
                    {
                        continue;
                    }

                    var entity = transformer.Execute(dict);

                    result.Add(entity);
                }
            }

            return result;
        }
    }
}
