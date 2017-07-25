using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogParser.Parsing
{
    public class SnmpLineParser : ILineParser
    {
        //"2017-07-12 03:53:14,790 SNMPv2 Get request from ('184.105.139.67', 64798): 1.3.6.1.2.1.1.1.0"
        Regex regEx = new Regex(@"(?<RequestDate>\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2},\d{3})\s+SNMPv2\s+Get\s+request\s+from\s+\('(?<Ip>\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})'", RegexOptions.Compiled);

        public bool CanParse(string line, out Dictionary<string, string> result)
        {
            result = new Dictionary<string, string>();

            var match = regEx.Match(line);

            if (!match.Success)
                return false;

            result.Add("UserAgent", null);
            result.Add("Protocol", "SNMPv2");

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
