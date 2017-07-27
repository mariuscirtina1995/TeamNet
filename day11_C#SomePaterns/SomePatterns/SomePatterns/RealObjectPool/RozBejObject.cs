using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.RealObjectPool
{
    public class RozBejObject : IObjectFactory<RozBejObject>
    {
        public int Id { get; set; }

        public string Name
        {
            get
            {
                return string.Format(@"RozBejObject {0}", Id);
            }
        }

        public RozBejObject Create(RozBejObject obj)
        {
            throw new NotImplementedException();
        }
    }
}
