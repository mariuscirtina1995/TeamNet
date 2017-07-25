using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.RepositoriesImpl;
using ErpDatabase.Entities;
using System.Data.SqlClient;
using ErpDatabase.GenericRepo;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class ClientRepositoryTests : AbstractRepositoryTest<Client>
    {
       
        protected override IRepository<Client> CreateTarget(SqlConnection connection)
        {
            return new GenericRepo.ClientRepository(connection);
        }

        #region test assert and cleanup methods
        protected override void AssertTSame(Client expected, Client actual, bool testId = false)
        {
            if(testId)
                Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.CNP, actual.CNP);
            Assert.AreEqual(expected.Nume, actual.Nume);
            Assert.AreEqual(expected.Prenume, actual.Prenume);
        }

        [TestInitialize]
        public override void Cleanup()
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand(@"delete Client where Nume = 'Mimescu'", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        protected override Client CreateObject()
        {
            var client = new Client
            {
                CNP = "1111181009922",
                Nume = "Mimescu",
                Prenume = "Georgica"
            };

            return client;
        }

        protected override void UpdateField(Client entity)
        {
            entity.Prenume = "Marinica";
        }

        protected override void UpdateLocalField(Client enity)
        {
            enity.Prenume = "Marinica";
       
        }
    }
}