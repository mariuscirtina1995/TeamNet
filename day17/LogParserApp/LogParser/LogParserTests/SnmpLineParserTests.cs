using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogParser.Parsing;
using System.Collections.Generic;

namespace LogParserTests
{
    [TestClass]
    public class SnmpLineParserTests
    {
        private ILineParser CreateTarget()
        {
            return new SnmpLineParser();
        }

        [TestMethod]
        public void WhenValidLineParserReturnsTrueAndWeGetAllValues()
        {
            var target = CreateTarget();

            string inputString = @"2017-07-12 03:53:14,790 SNMPv2 Get request from ('184.105.139.67', 64798): 1.3.6.1.2.1.1.1.0";

            Dictionary<string, string> actual;

            var parsed = target.CanParse(inputString, out actual);

            Assert.IsTrue(parsed);

            actual.AssertKeyWithValue("RequestDate", "2017-07-12 03:53:14,790");
            actual.AssertKeyWithValue("Protocol", "SNMPv2");
            actual.AssertKeyWithValue("Ip", "184.105.139.67");
            actual.AssertKeyWithValue("UserAgent", null);

        }
    }
}
