using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Entities;

namespace Countries.Operations
{
    public class CountriesOperations : ICountriesOperations
    {
        public IList<Country> countryList;

        public CountriesOperations(IList<Country> countryList)
        {
            this.countryList = countryList;
        }

        public Dictionary<string, List<Country>> GroupByNameFirstLetter()
        {
            var groupDictionary = new Dictionary<string, List<Country>>();

            foreach (var country in countryList)
            {
                var firstnameletter = Convert.ToString(country.Name[0]);

                if (!groupDictionary.ContainsKey(firstnameletter))
                    groupDictionary[firstnameletter] = new List<Country>();

                if (groupDictionary.ContainsKey(firstnameletter))
                    if(!groupDictionary[firstnameletter].Contains(country))
                        groupDictionary[firstnameletter].Add(country);
            }

            return groupDictionary;
        }

        public IList<Country> ListNameStartsWith(string name)
        {
            List<Country> listname = new List<Country>();

            foreach (var country in countryList)
            {
                if (country.Name.StartsWith(name))
                    listname.Add(country);
            }

            return listname;
        }

        public Country SingleByCode(string code)
        {
            foreach(var country in countryList)
            {
                if (country.Code == code)
                    return country;
            }

            return null;
        }
    }
}
