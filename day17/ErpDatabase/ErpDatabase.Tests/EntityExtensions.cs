﻿using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpDatabase.Tests
{
    public static class EntityExtensions
    {
        public static void AssertAreSame(this Client expected, Client actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.CNP.Trim(), actual.CNP.Trim());
            Assert.AreEqual(expected.Nume, actual.Nume);
            Assert.AreEqual(expected.Prenume, actual.Prenume);
        }

        public static void AssertAreSame(this LinieComanda expected, LinieComanda actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);

            expected.Produs.AssertAreSame(actual.Produs);
            expected.Comanda.AssertAreSame(actual.Comanda);

            //Assert.AreEqual(expected.Comanda, actual.Comanda);
            //Assert.AreEqual(expected.Produs, actual.Produs);

            Assert.AreEqual(expected.Cantitate, actual.Cantitate);
        }

        public static void AssertAreSame(this Produs expected, Produs actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.CategorieId, actual.CategorieId);
            Assert.AreEqual(expected.Nume, actual.Nume);
            Assert.AreEqual(expected.Pret, actual.Pret);
        }

        public static void AssertAreSame(this Comanda expected, Comanda actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);

            expected.Client.AssertAreSame(actual.Client);
            //Assert.AreEqual(expected.ClientId, actual.ClientId);
            Assert.AreEqual(expected.Finalizata, actual.Finalizata);
        }

        public static void AssertAreSame(this Categorie expected, Categorie actual, bool testId = false)
        {
            if (testId)
                Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Nume, actual.Nume);
        }
    }
}
