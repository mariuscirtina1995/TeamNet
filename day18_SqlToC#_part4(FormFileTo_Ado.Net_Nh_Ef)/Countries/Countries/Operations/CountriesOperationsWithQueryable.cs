using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Entities;

namespace Countries.Operations
{
    public class CountriesOperationsWithQueryable : ICountriesOperations
    {
        IList<Country> countries;

        public CountriesOperationsWithQueryable(IList<Country> countries)
        {
            this.countries = countries;
        }

        public IList<Country> AllWithPosition()
        {
            return countries.Where(c => c.Latitude != null && c.Latitude != null).ToList();
        }

        public IList<Country> FirstCountiesOrderdByName(int howMany, string nume)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<Country>> GroupByNameFirstLetter()
        {
            return countries
                .GroupBy(a => a.Name.Substring(0, 1))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.ToList());
        }

        public IList<Country> ListNameStartsWith(string name)
        {
            return countries.Where(c => c.Name.StartsWith(name))
                .ToList();
        }

        public decimal MedianOfSumsOfLatAnLongForNameStartsWith(string name)
        {
            return countries.Where(c => 
                    c.Name.StartsWith(name) && 
                    c.Latitude.HasValue && 
                    c.Longitude.HasValue
                )
                .Average(c => c.Latitude.Value + c.Longitude.Value);
        }

        public Country SingleByCode(string code)
        {
            return countries.SingleOrDefault(c => c.Code == code);
        }

        public decimal SumOfLatitudeForNameStartsWith(string name)
        {
            //return countries.Where(c => c.Name.StartsWith(name) && c.Latitude.HasValue).Sum(c => c.Latitude).Value;

            return AllWithPosition().Where(c => c.Name.StartsWith(name)).Sum(c => c.Latitude).Value;
        }
    }
}
