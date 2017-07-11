using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.ObjectPool
{
    public class Farfurie
    {
        public int Id { get; set; }

        public string Name
        {
            get
            {
                return string.Format(@"Farfurie {0}", Id);
            }
        }
    }
}
