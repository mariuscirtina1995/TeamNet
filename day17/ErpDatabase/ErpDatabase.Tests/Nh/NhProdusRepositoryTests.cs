﻿using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Nh.RepositoriesImpl;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class NhProdusRepositoryTests : NhAbstractTest<Produs>
    {
        protected override void AssertSame(Produs expected, Produs actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);
        }

        protected override Produs CreateObject()
        {
            return new Produs
            {
                Nume = "Mimescu",
                Categorie = new Categorie { Id = 1 },
                Pret = 2200,
            };
        }

        protected override IRepository<Produs> CreateTarget()
        {
            return new NhRepository<Produs>(session);
        }

        protected override string GetCleanupSql()
        {
            return "delete Produs where Nume = 'Mimescu'";
        }

        protected override void UpdateObject(Produs entity)
        {
            entity.Nume = "Irina";
        }
    }
}
