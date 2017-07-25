using Contries.Hn;
using Contries.Hn.RepositoriesImpl;
using Countries.Entities;
using Countries.FromFileToDtabase;
using Countries.Parsers;
using Countries.Tests.Nh;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Tests
{
    [TestClass]
    public class FromFileToDbTest
    {
        protected ISession session;
        protected ISessionFactory sessionFactory;
        protected string connectionString = @"Data Source=INTERN2017-12;Initial Catalog=Countries;User ID=sa;Password=1234%asd;";

        [TestInitialize]
        public void Initialize()
        {
            sessionFactory = new NhConfig(connectionString).Create();
            session = sessionFactory.OpenSession();

            using (var command = session.Connection.CreateCommand())
            {
                command.CommandText = "truncate table Country";
                command.ExecuteNonQuery();
            }

          
        }

        [TestCleanup]
        public void Cleanup()
        {
            session.Flush();
            session.Dispose();
        }

        private CountriesFromFieToDatabase CreateTarget(CsvCountrieFileParser parser, NhRepository<Country> dbOperations)
        {
            return new CountriesFromFieToDatabase(parser, dbOperations);
        }

        [TestMethod]
        public void WhenInsertingAllIntoTableAllCountriesAreInTable()
        {
           
            var parser = new CsvCountrieFileParser();
            var dbOperations = new NhRepository<Country>(session);

            var target = CreateTarget(parser, dbOperations);

            target.SaveCountriesInDatabase(@"Countries.csv");

            var expected = parser.Read(@"Countries.csv");

            var actural = dbOperations.GetAll();

            Assert.AreEqual(expected.Count, actural.Count);

            for(int i = 0; i < expected.Count; i++)
            {
                expected[i].AssertAreSame(actural[i]);
            }
        }

    }
}
