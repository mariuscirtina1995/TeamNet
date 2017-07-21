using Countries.Ef;
using Countries.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Tests.Ef
{
    public abstract class EfAbstractTest<T> : AbstractTest<T>
                    where T : IEntity, new()
    {
        protected ContryContext session;

        [TestInitialize]
        public void Initialize()
        {
            /* Create a session and execute a query: */
            session = new ContryContext("Data Source=INTERN2017-12;Initial Catalog=Countries;Integrated Security=true");

            session.Database.ExecuteSqlCommand(GetCleanupSql());
        }

        [TestCleanup]
        public void Cleanup()
        {
            session.Dispose();
        }
    }
}
