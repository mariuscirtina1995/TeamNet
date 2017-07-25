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
                Comanda = new Comanda { Id = 1 },
                Client = new Client { Id = 1 },
                Linii = new List<LinieFactura>()
            };

            factura.Linii.Add(new LinieFactura
            {
                Cantitate = 999,
                Pret = 2232,
                Factura = factura,
                LinieComanda = new LinieComanda { Id = 1 },
                Produs = new Produs { Id = 1 }
            });


            factura.Linii.Add(new LinieFactura
            {
                Cantitate = 7777,
                Pret = 10000,
                Factura = factura,
                LinieComanda = new LinieComanda { Id = 1 },
                Produs = new Produs { Id = 1 }
            });

            return factura;
        }

        protected override IRepository<Factura> CreateTarget()
        {
            return new NhRepository<Factura>(session);
        }

        protected override string GetCleanupSql()
        {
            return "select 1";// delete LinieFactura where ProdusId = 1";
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

            for(int i = 0; i < expected.Linii.Count; i++)
            {
                var expectedLinie = expected.Linii[i];
                var actualLinie = actual.Linii[i];

                expected.AssertAreSame(actual, true);
            }
        }

    }
}
