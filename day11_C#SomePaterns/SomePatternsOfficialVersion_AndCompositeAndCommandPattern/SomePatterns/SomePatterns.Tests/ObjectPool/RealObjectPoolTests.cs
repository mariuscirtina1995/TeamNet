using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomePatterns.ObjectPool;
using SomePatterns.RealObjectPool;

namespace SomePatterns.Tests.ObjectPool
{
    /// <summary>
    /// Summary description for FarfuriiObjectPoolTests
    /// </summary>
    [TestClass]
    public class RealObjectPoolTests
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
            var target = CreateTarget<Farfurie>(maxSize, new FarfuririiRozBejFactory());

            for(int i = 0; i < maxSize; i++)
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
            var target = CreateTarget<Farfurie>(maxSize, new FarfuririiRozBejFactory());

            target.Release(new Farfurie());
        }
    }
}
