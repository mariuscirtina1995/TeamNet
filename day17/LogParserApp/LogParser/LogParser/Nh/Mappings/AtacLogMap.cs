using LogParser.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Nh.Mappings
{
    public class AtacLogMap : ClassMapping<AtacLog>
    {
        public AtacLogMap()
        {
            Id(p => p.Id, m =>
            {
                m.Generator(Generators.Identity);
            });
            this.Property(p => p.Ip);
            this.Property(p => p.Protocol);
            this.Property(p => p.RequestDate);
            this.Property(p => p.UserAgent);
        }
    }
}
