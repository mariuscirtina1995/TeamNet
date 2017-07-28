using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RangeAttribute : Attribute
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class StringStartsWithAttribute : Attribute
    {
        public string StartsWithAttribute { get; set; }
    }

}
