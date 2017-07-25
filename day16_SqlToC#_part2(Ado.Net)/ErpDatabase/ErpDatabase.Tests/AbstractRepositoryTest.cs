using ErpDatabase.Entities;
using ErpDatabase.GenericRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Tests
{
    [TestClass]
    public abstract class AbstractRepositoryTest<T>
        where T : IEntity, new()
    {
        private string connectionString = @"Data Source=intern2017-12;Initial Catalog=MagazinOnline;User ID=sa;Password=1234%asd;";

        protected abstract IRepository<T> CreateTarget(SqlConnection connection);

        protected abstract T CreateObject();

        protected abstract void AssertTSame(T expected, T actual, bool testId = false);

        public abstract void Cleanup();

        protected abstract void UpdateField(T entity);

        protected abstract void UpdateLocalField(T enity);

        protected string GetConnectionString()
        {
            return connectionString;
        }

        [TestMethod]
        public void WhenInsertingOneWeCanGetThatObject()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var expected = CreateObject();

                var target = CreateTarget(connection);

                var countInitial = target.GetAll().Count;

                var id = target.Insert(expected);
                Assert.IsTrue(id > 0);

                var countFinal = target.GetAll().Count;

                var actual = target.GetById(id);

                Assert.AreEqual(countInitial + 1, countFinal);
                Assert.IsNotNull(actual);

                AssertTSame(expected, actual);

            }

            Cleanup();
        }

        [TestMethod]
        public void WhenUpdatingOneWeCanGetThatObject()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var expected = CreateObject();

                var target = CreateTarget(connection);

                var countInitial = target.GetAll().Count;

                var id = target.Insert(expected);
                Assert.IsTrue(id > 0);

                var actual = target.GetById(id);
                Assert.IsNotNull(actual);

                var countFinal = target.GetAll().Count;

                UpdateField(actual);

                target.Update(actual);

                actual = target.GetById(id);

                UpdateLocalField(expected);

                Assert.AreEqual(countInitial + 1, countFinal);
                Assert.IsNotNull(actual);

                AssertTSame(expected, actual);

            }

            Cleanup();
        }

        [TestMethod]
        public void WhenDeleteingOneWeCanGetThatObject()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var expected = CreateObject();

                var target = CreateTarget(connection);

                var countInitial = target.GetAll().Count;

                var id = target.Insert(expected);
                Assert.IsTrue(id > 0);

                var actual = target.GetById(id);
                Assert.IsNotNull(actual);

                target.Delete(actual);

                actual = target.GetById(id);
                Assert.IsNull(actual);
            }

            Cleanup();
        }

    }
}
