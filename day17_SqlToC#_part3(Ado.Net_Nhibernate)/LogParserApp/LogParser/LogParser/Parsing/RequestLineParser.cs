using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogParser.Parsing
{
    public class RequestLineParser : ILineParser
    {
        // @"2017-07-12 02:11:25,642 HTTP/1.1 HEAD request from ('130.204.27.14', 46368): ('http://198.211.98.122:80/mysql/admin/', ['Connection: Keep-Alive\r\n', 'Keep-Alive: 300\r\n', 'User-Agent: Mozilla/5.0 Jorgee\r\n', 'Host: 198.211.98.122\r\n'], None). c77efb97-ebd1-450e-b014-a52291bf4bbf";
        // 'User-Agent:\s+(?<UserAgent>[\w\s\./])\\r\\n
        Regex regEx = new Regex(@"(?<RequestDate>\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2},\d{3})\s+(?<Protocol>[\w/\.]+)\s+HEAD\s+request\s+from\s+\('(?<Ip>\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})'.+'User-Agent:\s+(?<UserAgent>[\w\s\./]+)", RegexOptions.Compiled);

        public bool CanParse(string line, out Dictionary<string, string> result)
        {
            result = new Dictionary<string, string>();

            var match = regEx.Match(line);

            if (!match.Success)
                return false;

            foreach (string groupName in regEx.GetGroupNames())
            {
                var group = match.Groups[groupName];

                if (!group.Success)
                    continue;

                result.Add(groupName, group.Value);
            }

            return true;
        }
    }
}
