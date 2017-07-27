using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.CommandComposition
{
    public class MultiplyCommand : ICommand
    {
        Receiver receiver;
        decimal value;

        public MultiplyCommand(Receiver receiver, decimal value)
        {
            this.receiver = receiver;
            this.value = value;
        }

        public ICommand CreateUndoCommand()
        {
            return new MultiplyCommand(receiver, 1.0m / value);
        }

        public void Execute()
        {
            receiver.Multiply(value);
        }
    }
}
