using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomePatterns.RealObjectPool;
using SomePatterns.ObjectPool;

namespace SomePatterns.Tests.RealObjectPool
{
    [TestClass]
    public class RealObjectPoolTest
    {
        private IObjectPool<T> CreateTarget<T>(int maxSize, IObjectFactory<T> objectFactory)
            where T : new()
        {
            return new ObjectPool<T>(maxSize, objectFactory);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WhenObjectPoolOfSize10ThenCanOnlyGet10()
        {
            //
            // TODO: Add test logic here
            //
            var maxSize = 20;
            var target = CreateTarget(maxSize, new ObjectFactory<Farfurie>());

            for (int i = 0; i < maxSize; i++)
            {
                target.Create();
            }

            target.Create();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WhenReleasingNonPooledFarfurieThenException()
        {
            var maxSize = 20;
            var target = CreateTarget(maxSize, new ObjectFactory<RozBejObject>());

            target.Release(new RozBejObject());
        }
    }
}
