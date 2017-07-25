using Countries.Parsers;
using Countries.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Entities;

namespace Countries.FromFileToDtabase
{
    public class CountriesFromFieToDatabase
    { 

        public ICsvCountrieFileParser parser;
        public IRepository<Country> databaseOperations;


        public CountriesFromFieToDatabase(ICsvCountrieFileParser parser, IRepository<Country> databaseOperations)
        {
            this.parser = parser;
            this.databaseOperations = databaseOperations;
        }

        public void SaveCountriesInDatabase(string filepath)
        {
            IList<Country> countries = parser.Read(filepath);

            foreach(var country in countries)
            {
                databaseOperations.Insert(country);
            }
            
        }

    }
}
