using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParserTests
{
    public static class SomeExtensions
    {
        public static void AssertKeyWithValue(this Dictionary<string,string> dict, string key, string value)
        {
            Assert.IsTrue(dict.ContainsKey(key), string.Format(@"Cheia {0} nu exista", key));
            Assert.AreEqual(value, dict[key]);
        }
    }
}
