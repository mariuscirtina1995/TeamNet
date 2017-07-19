using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Entities
{
    public class AtacLog
    {
        public virtual int Id { get; set; }
        public virtual DateTime RequestDate { get; set; }
        public virtual string Ip { get; set; }
        public virtual string Protocol { get; set; }
        public virtual string UserAgent { get; set; }
    }
}
