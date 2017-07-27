using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Database.V1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        protected IDatabase CreateTestTarget()
        {
            return new DatabaseImpl();
        }

        [TestMethod]
        public void WhenInsertingWeCanRetrieveSameProperties()
        {
            var database = CreateTestTarget();

            var expected = new Dosar { Id = 1, Code = "PI13232", Description = "Dosar intern 1" };

            database.Insert(expected);

            var actual = database.Get(expected.Id);

            Assert.IsNotNull(actual);
            actual.AssertAllPropertiesAreEqual(expected);
        }

        [TestMethod]
        public void WhenUpdatingWeRetrieveSameThing()
        {
            var database = CreateTestTarget();

            var initialInput = new Dosar { Id = 1, Code = "PI13232", Description = "Dosar intern 1" };

            database.Insert(initialInput);

            var expected = new Dosar { Id = 1, Code = "PI13232555", Description = "Dosar intern 1555" };

            database.Update(expected);

            var actual = database.Get(expected.Id);

            Assert.IsNotNull(actual);
            actual.AssertAllPropertiesAreEqual(expected);
        }

        [TestMethod]
        public void WhenDeletingWeRetrieveNull()
        {
            var database = CreateTestTarget();

            var input = new Dosar { Id = 1, Code = "PI13232", Description = "Dosar intern 1" };

            database.Insert(input);
            database.Delete(input.Id);

            var actual = database.Get(input.Id);

            Assert.IsNull(actual);
        }
    }
}
