using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    public class NotaExamenValidator
    {
        public bool IsValid(NotaExamen nota, out List<string> erori)
        {
            erori = new List<string>();

            foreach(var property in nota.GetType().GetProperties())
            {
                var attrs = property.GetCustomAttributes(true)
                                .Where(a => 
                                    typeof(RangeAttribute)
                                    .IsAssignableFrom(a.GetType()))
                                    .ToArray();

                if (0 == attrs.Length)
                    continue;

                var attr = (RangeAttribute)attrs[0];

                //var actualValue = property.GetValue(nota);
                
                if(nota.Nota > attr.MaxValue)
                {
                    erori.Add(string.Format(@"Nota e mai mare decat {0}", attr.MaxValue));
                    return false;
                }
                if (nota.Nota < attr.MinValue)
                {
                    erori.Add(string.Format(@"Nota e mai mica decat {0}", attr.MinValue));
                    return false;
                }
            }

            return true;
        }
    }
}
