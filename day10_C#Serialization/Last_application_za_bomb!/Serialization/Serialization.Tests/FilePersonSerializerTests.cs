using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Serialization.Tests
{
    [TestClass]
    public class FilePersonSerializerTests
    {

        private IFilePersonSerializer CreateTarget(FormattingType type)
        {
            return FilePersonSerializerFactory.Instance.Create(type);
        }

        [TestMethod]
        public void WhenSerializin2PersonsWeGetSamePersonsWithCsv()
        {
            var expected = new Person[]
            {
                new Person { FirstName = "A", LastName = "B", Age = 12 },
                new Person { FirstName = "C", LastName = "D", Age = 22 }
            };

            var target = CreateTarget(FormattingType.Csv);

            target.Serialize(expected, "myFile.txt");

            var actual = target.Deserialize("myFile.txt");

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

        [TestMethod]
        public void WhenSerializin2PersonsWeGetSamePersonsWithJson()
        {
            var expected = new Person[]
            {
                new Person { FirstName = "A", LastName = "B", Age = 12 },
                new Person { FirstName = "C", LastName = "D", Age = 22 }
            };

            var target = CreateTarget(FormattingType.Json);

            target.Serialize(expected, "myFile.txt");

            var actual = target.Deserialize("myFile.txt");

            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
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
