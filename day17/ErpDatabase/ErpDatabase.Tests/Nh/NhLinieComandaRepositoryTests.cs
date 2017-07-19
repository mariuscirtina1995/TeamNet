using ErpDatabase.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpDatabase.Repositories;
using ErpDatabase.Nh.RepositoriesImpl;

namespace ErpDatabase.Tests
{
    [TestClass]
    public class NhLinieComandaRepositoryTests : NhAbstractTest<LinieComanda>
    {
        protected override void AssertSame(LinieComanda expected, LinieComanda actual, bool testId = false)
        {
            expected.AssertAreSame(actual, testId);
            
        }

        protected override LinieComanda CreateObject()
        {
            return new LinieComanda
            {
                Comanda = new Comanda {
                            Id = 1,
                            Client = new Client
                                {
                                    CNP = "1111181009922",
                                    Nume = "Mimescu",
                                    Prenume = "Georgica"
                                },
                            Finalizata = 1,
                        },
                
                Produs = new Produs { Id = 1 },
                Cantitate = 1000,
            };
        }

        protected override IRepository<LinieComanda> CreateTarget()
        {
            return new NhRepository<LinieComanda>(session);
        }

        protected override string GetCleanupSql()
        {
            return "delete LinieComanda where Cantitate = 1000";
        }

        protected override void UpdateObject(LinieComanda entity)
        {
            entity.Cantitate = 4;
        }
    }
}
