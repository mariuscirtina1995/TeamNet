using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSearching
{
    public interface IFileTextSearcher
    {
        int Count(string filePath, string searchString);
    }
}
