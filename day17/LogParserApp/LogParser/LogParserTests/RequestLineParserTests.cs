using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogParser.Parsing;
using System.Collections.Generic;

namespace LogParserTests
{
    [TestClass]
    public class RequestLineParserTests
    {
        private ILineParser CreateTarget()
        {
            return new RequestLineParser();
        }

        [TestMethod]
        public void WhenValidLineParserReturnsTrueAndWeGetAllValues()
        {
            var target = CreateTarget();

            string inputString = @"2017-07-12 02:11:25,642 HTTP/1.1 HEAD request from ('130.204.27.14', 46368): ('http://198.211.98.122:80/mysql/admin/', ['Connection: Keep-Alive\r\n', 'Keep-Alive: 300\r\n', 'User-Agent: Mozilla/5.0 Jorgee\r\n', 'Host: 198.211.98.122\r\n'], None). c77efb97-ebd1-450e-b014-a52291bf4bbf";

            Dictionary<string, string> actual;

            var parsed = target.CanParse(inputString, out actual);

            Assert.IsTrue(parsed);

            actual.AssertKeyWithValue("RequestDate", "2017-07-12 02:11:25,642");
            actual.AssertKeyWithValue("Protocol", "HTTP/1.1");
            actual.AssertKeyWithValue("Ip", "130.204.27.14");
            actual.AssertKeyWithValue("UserAgent", "Mozilla/5.0 Jorgee");

        }
    }
}
