using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using System.Collections.Generic;
using ErpDatabase.Ef.RepositoriesImpl;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class EfProdusRepositoryTests : EfAbstractTest<Produs>
    {
        protected override void AssertSame(Produs expected, Produs actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);
        }

        protected override Produs CreateObject()
        {
            return new Produs
            {
                Categorie = new Categorie { Id = 1 },
                Nume = "Electrocasnice",
                Pret = 700
            };
        }

        protected override IRepository<Produs> CreateTarget()
        {
            return new EfRepository<Produs>(session);
        }

        protected override string GetCleanupSql()
        {
            return "delete from Produs where Nume = 'Electrocasnice'";
        }

        protected override void UpdateObject(Produs entity)
        {
            entity.Pret = 50000;
        }
    }
}
