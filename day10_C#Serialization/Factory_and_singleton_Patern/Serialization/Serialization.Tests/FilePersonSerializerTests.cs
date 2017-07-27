using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Serialization.Tests
{
    [TestClass]
    public class FilePrsonSerializerTests
    {
        private IFilePersonSerializerFactory CreateFactory()
        {
            return new FilePersonSerializeFactory();
        }
        private IFilePersonSerializer CreateTarget(FormattingType type)
        {
            return CreateFactory().Create(type);
        }

        [TestMethod]
        public void CSVWhenSerializin2PersonsWeGetSamePersons()
        {
            //CSV Test:
            var expected = new Person[]
            {
                new Person { FirstName = "A", LastName = "B", Age = 12 },
                new Person { FirstName = "C", LastName = "D", Age = 22 }
            };

            var target = CreateTarget(FormattingType.Csv);
            string filepath = @"fileCSV.txt";

            target.Serialize(expected, filepath);

            var actual = target.DeSerialize(filepath);

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
        public void JSONWhenSerializin2PersonsWeGetSamePersons()
        {
            //JSON TEST:
            var expected2 = new Person[]
            {
                new Person { FirstName = "A", LastName = "B", Age = 12 },
                new Person { FirstName = "C", LastName = "D", Age = 22 }
            };

            var target2 = CreateTarget(FormattingType.Json);
            string filepath2 = @"fileJson.txt";

            target2.Serialize(expected2, filepath2);

            var actual2 = target2.DeSerialize(filepath2);

            Assert.AreEqual(expected2.Length, actual2.Length);

            for (int i = 0; i < expected2.Length; i++)
            {
                var actualElement = actual2[i];
                var expectedElement = expected2[i];

                Assert.AreEqual(expectedElement.FirstName, actualElement.FirstName);
                Assert.AreEqual(expectedElement.LastName, actualElement.LastName);
                Assert.AreEqual(expectedElement.Age, actualElement.Age);

            }
        }
    }
}
