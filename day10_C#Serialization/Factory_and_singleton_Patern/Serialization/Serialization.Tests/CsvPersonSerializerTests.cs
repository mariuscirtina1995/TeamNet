using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Serialization.Tests
{
    [TestClass]
    public class CsvPersonSerializerTests
    {
        private IPersonSerializerFactory CreateFactory()
        {
            return new PersonSerializerFactory();
        }
        private IPersonSerializer CreateTarget()
        {
            return CreateFactory().Create(FormattingType.Csv);
        }

        [TestMethod]
        public void WhenSerializin2PersonsWeGetSamePersons()
        {
            var expected = new Person[]
            {
                new PersonBuilder()
                    .WithFirstName("A")
                    .WithLastName("B")
                    .WithAge(12)
                    .Get(),
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
