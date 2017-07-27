using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSearching
{
    public class TextSearcher : ITextSearcher
    {
        public int Count(string text, string searchString)
        {
            //get number of appearances of substring in another string
            //int count = (text.Length - text.Replace(searchString, "").Length) / searchString.Length;
            //return count;
            int count = 0;
            string[] allText = text.Split(' ');

            foreach (var word in allText)
            {
                if (word.Contains(searchString))
                    count++;
            }

            return count;
        }
    }
}
