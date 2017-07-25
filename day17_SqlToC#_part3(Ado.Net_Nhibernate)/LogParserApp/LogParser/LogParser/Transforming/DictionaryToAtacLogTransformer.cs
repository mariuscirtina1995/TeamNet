using LogParser.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Transforming
{
    public class DictionaryToAtacLogTransformer
    {
        public AtacLog Execute(Dictionary<string,string> input)
        {
            var entity = new AtacLog();
            DateTime requestDate;

            if (!input.ContainsKey("RequestDate"))
                throw new Exception();

            if (!DateTime.TryParseExact(input["RequestDate"],
                       "yyyy-MM-dd HH:mm:ss,fff",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None, out requestDate))
                throw new Exception();

            entity.Ip = input["Ip"];
            entity.Protocol = input["Protocol"];
            entity.RequestDate = requestDate;
            entity.UserAgent = input["UserAgent"];

            return entity;
        }
    }
}
