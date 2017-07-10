using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSearching
{
    public class FileTextSearcher : IFileTextSearcher
    {
        //adding interface variable for using other methods
        private ITextSearcher textSearcher;

        //get a class that has the requaired interface
        public FileTextSearcher(ITextSearcher textSearcher)
        {
            this.textSearcher = textSearcher;
        }

        public int Count(string filePath, string searchString)
        {
            var lines = File.ReadAllText(filePath);

            //use requaired interface methods for Count
            return textSearcher.Count(lines, searchString);
        }

    }
}
