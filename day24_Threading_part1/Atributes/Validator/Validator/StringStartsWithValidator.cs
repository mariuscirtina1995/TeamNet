using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    public class StringStartsWithValidator
    {
        public bool StrtsWithAttribute(object obj, out List<string> erori)
        {
            erori = new List<string>();

            foreach (var property in obj.GetType().GetProperties())
            {
                var attrs = property.GetCustomAttributes(true)
                                .Where(a =>
                                    typeof(StringStartsWithAttribute)
                                    .IsAssignableFrom(a.GetType()))
                                    .ToArray();

                if (0 == attrs.Length)
                    continue;

                var attr = (StringStartsWithAttribute)attrs[0];

                var actualValue = property.GetValue(obj);

                if(!(actualValue is string))
                {
                    erori.Add(string.Format(@"Proprietatea {0} nu incepe cu '{1}' pentru ca nu este un string!"
                            , property.Name        
                            , attr.StartsWithAttribute));

                    continue;
                }

                var str = (string)actualValue;

                if (!str.StartsWith(attr.StartsWithAttribute))
                {
                    erori.Add(string.Format(@"Stringul nu incepe cu '{0}'", attr.StartsWithAttribute));
                    return false;
                }
            }

            return true;
        }
    }
}
