using Countries.Ef;
using Countries.Entities;
using Countries.FromFileToDtabase;
using Countries.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Operations
{
    public class EfCountriesOperationsDB : ICountriesOperations
    {
        protected ContryContext context;

        public EfCountriesOperationsDB(ContryContext context)
        {
            this.context = context;
        }

        public IList<Country> AllWithPosition()
        {
            return context.Country
                .Where(c => c.Latitude.HasValue && c.Longitude.HasValue)
                .ToList();
        }

        public IList<Country> FirstCountriesOrderedByName(int howMany, string name)
        {
            return
                context.Country
                    .Where(c => c.Name.StartsWith(name))
                    .OrderBy(c => c.Name)
                    .Take(howMany)
                    .ToList();
        }

        private class myPrivateClass : IEqualityComparer<Country>
        {
            public bool Equals(Country x, Country y)
            {
                return x.Code == y.Code && x.Name == y.Name;
            }

            public int GetHashCode(Country obj)
            {
                return obj.Code.GetHashCode();
            }
        }

        public IList<VeryLittleCountry> GetAllCountryNames()
        {
            return context.Country
                .Distinct(new myPrivateClass())
                .Select(c => new LittleCountry
                {
                    Code = c.Code,
                    Name = c.Name
                })
                    .Where(lc => lc.Code.StartsWith("d"))
                    .Select(lc => new VeryLittleCountry { Code = lc.Code })
                    .Where(vlc => vlc.Code == "ss")
                    .ToList();
        }

        public IList<Country> GetPageFilterByNameOrderByName(int howMany, int pageNumber, string name)
        {
            return
                context.Country
                    .Where(c => c.Name.StartsWith(name))
                    .OrderBy(c => c.Name)
                    .Skip(pageNumber * howMany)
                    .Take(howMany)
                    .ToList();
        }

        public Dictionary<string, List<Country>> GroupByNameFirstLetter()
        {
            return context.Country
                .GroupBy(a => a.Name.Substring(0, 1))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.ToList());
        }

        public IList<Country> ListNameStartsWith(string name)
        {
            return context.Country.Where(c => c.Name.StartsWith(name)).ToList();
        }

        public decimal MedianOfSumsOfLatAnLongForNameStartsWith(string name)
        {
            var x = context.Country.Where(c =>
                    c.Latitude.HasValue && c.Longitude.HasValue && c.Name.StartsWith(name))
                    .Average(c => (double)c.Latitude.Value + (double)c.Longitude.Value);

            return Convert.ToDecimal(x);
        }

        public Country SingleByCode(string code)
        {
            return context.Country.SingleOrDefault(c => c.Code == code);
        }

        public decimal SumOfLatitudeForNameStartsWith(string name)
        {
            var x = context.Country.Where(c =>
                c.Latitude.HasValue && c.Longitude.HasValue && c.Name.StartsWith(name))
                        .Sum(c => (double)c.Latitude.Value);

            return Convert.ToDecimal(x);
        }

        IList<LittleCountry> ICountriesOperations.GetAllCountryNames()
        {
            throw new NotImplementedException();
        }
    }
}
