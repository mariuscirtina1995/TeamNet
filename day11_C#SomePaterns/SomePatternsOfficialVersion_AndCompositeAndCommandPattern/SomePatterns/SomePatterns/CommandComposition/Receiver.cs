using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.CommandComposition
{
    public class Receiver
    {
        private decimal value;

        public Receiver(decimal value)
        {
            this.value = value;
        }

        public decimal Value
        {
            get
            {
                return value;
            }
        }

        public void Add(decimal value)
        {
            this.value += value;
        }

        public void Multiply(decimal value)
        {
            this.value *= value;
        }
    }
}
