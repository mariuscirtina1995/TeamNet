using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomePatterns.ObjectPool;

namespace SomePatterns.Tests.ObjectPool
{
    /// <summary>
    /// Summary description for FarfuriiObjectPoolTests
    /// </summary>
    [TestClass]
    public class FarfuriiObjectPoolTests
    {
        private IFarfuriiObjectPool CreateTarget(int maxSize)
        {
            return new FarfuriiObjectPool(maxSize, new FarfuririiRozBejFactory());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WhenObjectPoolOfSize10ThenCanOnlyGet10()
        {
            //
            // TODO: Add test logic here
            //
            var maxSize = 20;
            var target = CreateTarget(maxSize);

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
            var target = CreateTarget(maxSize);

            target.Release(new Farfurie());
        }
    }
}
