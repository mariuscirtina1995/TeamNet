using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Nh.RepositoriesImpl;
using System.Collections.Generic;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class NhComandaRepositoryTests : NhAbstractTest<Comanda>
    {
        protected override void AssertSame(Comanda expected, Comanda actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);

        }

        protected override Comanda CreateObject()
        {
            var comanda = new Comanda
            {
                Client = new Client
                {
                    Id = 1,
                    CNP = "1111181009922",
                    Nume = "Mimescu",
                    Prenume = "Georgica"
                },

                Finalizata = 0,

                Linii = new List<LinieComanda>()
            };

            comanda.Linii.Add(new LinieComanda
            {
                Cantitate = 999,
                Comanda = comanda,
                Produs = new Produs { Id = 1 }
            });

            comanda.Linii.Add(new LinieComanda
            {
                Cantitate = 1000,
                Comanda = comanda,
                Produs = new Produs { Id = 1 }
            });

            return comanda;
        }

        protected override IRepository<Comanda> CreateTarget()
        {
            return new NhRepository<Comanda>(session);
        }

        protected override string GetCleanupSql()
        {
            //return "delete Client where Nume = 'Mimescu'"
            //+ " delete Comanda where Finalizata = 0";
            return "select 1";
        }

        protected override void UpdateObject(Comanda entity)
        {
            entity.Finalizata = 1;
        }

        [TestMethod]
        public void WhenInsertingComandaWith2LiniiWeGet2Linii()
        {
            var expected = CreateObject();

            var target = CreateTarget();

            var countInitial = target.GetAll().Count;

            var id = target.Insert(expected);
            Assert.IsTrue(id > 0);

            var countFinal = target.GetAll().Count;

            var actual = target.GetById(id);

            Assert.AreEqual(countInitial + 1, countFinal);
            Assert.IsNotNull(actual);
            AssertSame(expected, actual);

            Assert.AreEqual(expected.Linii.Count, actual.Linii.Count);

            for (int i = 0; i < expected.Linii.Count; i++)
            {
                var expectedLinie = expected.Linii[i];
                var actualLinie = actual.Linii[i];

                expected.AssertAreSame(actual, true);
            }
        }
    }
}
