using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.CommandComposition
{
    public class MultiplyCommand : ICommand
    {
        public decimal value;
        public Receiver receiver;

        public MultiplyCommand(Receiver receive, decimal value)
        {
            this.receiver = receive;
            this.value = value;
        }

        public void Execute()
        {
            receiver.Multiply(value);
        }
    }
}
