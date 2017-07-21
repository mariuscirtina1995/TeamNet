using Countries.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Tests
{
    public abstract class AbstractTest<T>
                 where T : IEntity, new()
    {
        protected string connectionString = @"Data Source=INTERN2017-12;Initial Catalog=Countries;User ID=sa;Password=1234%asd;";

        protected abstract IRepository<T> CreateTarget();

        protected abstract void AssertSame(T expected, T actual, bool testId = false);

        protected abstract string GetCleanupSql();

        protected abstract T CreateObject();

        protected abstract void UpdateObject(T entity);

        [TestMethod]
        public void WhenInsertingOneWeCanGetThatObject()
        {
            var expected = CreateObject();

            var target = CreateTarget();

            var countInitial = target.GetAll().Count;

            var code = target.Insert(expected);
            Assert.IsTrue(code != "");

            var countFinal = target.GetAll().Count;

            var actual = target.GetById(code);

            Assert.AreEqual(countInitial + 1, countFinal);
            Assert.IsNotNull(actual);
            AssertSame(expected, actual);
        }

        [TestMethod]
        public void WhenUpdatingOneWeCanGetThatObject()
        {
            var expected = CreateObject();

            var target = CreateTarget();

            var countInitial = target.GetAll().Count;

            var code = target.Insert(expected);
            Assert.IsTrue(code != "");

            expected = target.GetById(code);
            Assert.IsNotNull(expected);

            var countFinal = target.GetAll().Count;

            UpdateObject(expected);

            target.Update(expected);

            var actual = target.GetById(code);

            Assert.AreEqual(countInitial + 1, countFinal);
            Assert.IsNotNull(actual);
            AssertSame(expected, actual, true);
        }

        [TestMethod]
        public void WhenDeleteingOneWeCanGetThatObject()
        {
            var expected = CreateObject();

            var target = CreateTarget();

            var countInitial = target.GetAll().Count;

            var code = target.Insert(expected);
            Assert.IsTrue(code != "");

            var actual = target.GetById(code);
            Assert.IsNotNull(actual);

            target.Delete(code);

            actual = target.GetById(code);
            Assert.IsNull(actual);
        }
    }
}
