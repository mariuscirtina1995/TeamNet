using Countries.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Operations
{
    public class CountriesOperationsIquary : ICountriesOperations
    {
        public IList<Country> countryList;

        public CountriesOperationsIquary(IList<Country> countryList)
        {
            this.countryList = countryList;
        }

        public Dictionary<string, List<Country>> GroupByNameFirstLetter()
        {
            //fuck >>>
            return countryList.GroupBy(k => k.Name.Substring(0, 1))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.ToList());

        }

        public IList<Country> ListNameStartsWith(string name)
        {
            //return countryList.Where(c => c.Name.StartsWith(name)).ToList();

            var countrylist = (from coun in countryList
                               where coun.Name.StartsWith(name)
                               select coun).ToList();

            return countrylist;
        }

        public Country SingleByCode(string code)
        {
            //return countryList.SingleOrDefault(c => c.Code == code);

            var country = (from coun in countryList
                           where coun.Code == code
                           select coun).SingleOrDefault();

            return country;
        }
    }
}

