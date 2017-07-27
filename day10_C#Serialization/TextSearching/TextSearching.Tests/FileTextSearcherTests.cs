using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextSearching.Tests
{
    [TestClass]
    public class FileTextSearcherTests
    {
        private IFileTextSearcher CreateTarget()
        {
            return new FileTextSearcher(new TextSearcher());
        }

        [TestMethod]
        [DeploymentItem("TextFile1.txt")]
        public void WhenSearchingSiWeGetOne()
        {
            string searchText = "si";

            var target = CreateTarget();

            var actual = target.Count("TextFile1.txt", searchText);

            Assert.AreEqual(3, actual);
        }
    }
}
