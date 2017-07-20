using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Entities;
using System.IO;

namespace Countries.Parsers
{
    public class CsvCountrieFileParser : ICsvCountrieFileParser
    {
        

        public IList<Country> Read(string filePath)
        {
            var countries = new List<Country>();

            var lines = File.ReadAllLines(filePath);
   
            for (int i= 1; i < lines.Length; i++)
            {
                var columns = lines[i].Split(new char[] { ',' });

                var code = columns[0];
                Decimal? latitude;

                if (columns[1] == "")
                    latitude = null;
                else
                    latitude = Convert.ToDecimal(columns[1]);

                Decimal? longitude;

                if (columns[1] == "")
                    longitude = null;
                else
                    longitude = Convert.ToDecimal(columns[2]);
        
                var name = columns[3];

                Country country = new Country()
                {
                    Code = code,
                    Latitude = latitude,
                    Longitude = longitude,
                    Name = name,

                };

                countries.Add(country);
            }

            return countries;

        }
    }
}
