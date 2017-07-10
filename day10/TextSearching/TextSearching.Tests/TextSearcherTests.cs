using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextSearching.Tests
{
    [TestClass]
    public class TextSearcherTests
    {
        private ITextSearcher CreateTarget()
        {
            return new TextSearcher();
        }

        [TestMethod]
        public void WhenSearchingSiWeGetOne()
        {
            string input = @"Moldova nu e a mea si nici a voastra nu e, 
ci a urmasilor urmasilor vostri";
            string searchText = "si";

            var target = CreateTarget();

            var actual = target.Count(input, searchText);

            Assert.AreEqual(3, actual);
        }
    }
}
