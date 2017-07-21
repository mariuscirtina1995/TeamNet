﻿using Contries.Hn.RepositoriesImpl;
using Countries.Entities;
using Countries.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Tests.Nh
{
    [TestClass]
    public class NhCountryRepositoryTests : NhAbstractTest<Country>
    {
        protected override void AssertSame(Country expected, Country actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);
        }

        protected override Country CreateObject()
        {
            return new Country
            {
                Code = "XX",
                Longitude = 12.3m,
                Latitude = 22.3m,
                Name = "Danemarca",

            };
        }

        protected override IRepository<Country> CreateTarget()
        {
            return new NhRepository<Country>(session);
        }

        protected override string GetCleanupSql()
        {
            return "delete from Country where Cod = 'XX'";
        }

        protected override void UpdateObject(Country entity)
        {
            entity.Longitude = 55.9m;
        }
    }
}
