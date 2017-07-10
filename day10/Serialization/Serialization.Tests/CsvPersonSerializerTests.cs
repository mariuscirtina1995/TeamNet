using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Serialization.Tests
{
    [TestClass]
    public class CsvPersonSerializerTests
    {
        private IPersonSerializer CreateTarget()
        {
            return new CsvPersonSerializer();
        }

        [TestMethod]
        public void WhenSerializin2PersonsWeGetSamePersons()
        {

            var expected = new Person[]
            {
                new Person { FirstName = "A", LastName = "B", Age = 12 },
                new Person { FirstName = "C", LastName = "D", Age = 22 }
            };

            var target = CreateTarget();

            var serialized = target.Serialize(expected);

            var actual = target.Deserialize(serialized);

            Assert.AreEqual(expected.Length, actual.Length);

            for(int i = 0; i < expected.Length; i++)
            {
                var actualElement = actual[i];
                var expectedElement = expected[i];

                Assert.AreEqual(expectedElement.FirstName, actualElement.FirstName);
                Assert.AreEqual(expectedElement.LastName, actualElement.LastName);
                Assert.AreEqual(expectedElement.Age, actualElement.Age);

            }
        }
    }
}
