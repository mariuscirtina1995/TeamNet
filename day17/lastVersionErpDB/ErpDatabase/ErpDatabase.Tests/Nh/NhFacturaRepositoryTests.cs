using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Nh.RepositoriesImpl;
using System.Collections.Generic;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class NhFacturaRepositoryTests : NhAbstractTest<Factura>
    {
        protected override void AssertSame(Factura expected, Factura actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);
        }

        protected override Factura CreateObject()
        {
            var factura = new Factura
            {
                Client = new Client { Id = 1 },
                Comanda = new Comanda { Id = 1 },
                Linii = new List<LinieFactura>()
            };

            factura.Linii.Add(new LinieFactura
            {
                Cantitate = 1000,
                Factura = factura,
                Produs = new Produs { Id = 1 },
                LinieComanda = new LinieComanda { Id = 1 },
                Pret = 2200,

            });

            factura.Linii.Add(new LinieFactura
            {
                Cantitate = 1000,
                Factura = factura,
                Produs = new Produs { Id = 1 },
                LinieComanda = new LinieComanda { Id = 1 },
                Pret = 2200,

            });

            return factura;
        }

        protected override IRepository<Factura> CreateTarget()
        {
            return new NhRepository<Factura>(session);
        }

        protected override string GetCleanupSql()
        {
            return "select 1";
            //return "delete Factura where FacturaID = 1";
        }

        protected override void UpdateObject(Factura entity)
        {
            entity.Client = new Client { Id = 2 };
        }

        [TestMethod]
        public void WhenInsertingFacturaWith2LiniiWeGet2Linii()
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
