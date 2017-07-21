using Countries.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contries.Hn.Mappings
{
    public class CountryMap : ClassMapping<Country>
    {
        public CountryMap()
        {
            this.Table("Country");
            Id(p => p.Code, a =>
            {
                a.Column("Cod");
                a.Generator(Generators.Assigned);
            });

            
            this.Property(p => p.Latitude
                    , p =>
                    {
                        p.Column(@"Latitudine");
                        p.Precision(20);
                        p.Scale(8);

                    }    
             );

            this.Property(p => p.Longitude
                , p =>
                {
                    p.Column(@"Longitudine");
                    p.Precision(20);
                    p.Scale(8);
                }
            );

            this.Property(p => p.Name, p => p.Column("Nume"));
        }
    }
}
