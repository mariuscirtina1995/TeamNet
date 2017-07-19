using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Parsing
{
    public interface ILineParser
    {
        bool CanParse(string line, out Dictionary<string, string> result);
    }
}
