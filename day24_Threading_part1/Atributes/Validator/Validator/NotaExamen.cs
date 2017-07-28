using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    public class NotaExamen
    {
        [StringStartsWith(StartsWithAttribute = "Ma")]
        public string Name { get; set; }

        [Range(MinValue = 2, MaxValue = 4)]
        [StringStartsWith(StartsWithAttribute = "Ma")]
        public int Nota { get; set; }
    }
}
