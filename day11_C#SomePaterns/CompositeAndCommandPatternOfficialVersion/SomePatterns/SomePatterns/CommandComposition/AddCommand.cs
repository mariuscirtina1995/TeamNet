using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.CommandComposition
{
    public class AddCommand : ICommand
    {
        Receiver receiver;
        decimal value;

        public AddCommand(Receiver receiver, decimal value)
        {
            this.receiver = receiver;
            this.value = value;
        }

        public ICommand CreateUndoCommand()
        {
            return new AddCommand(receiver, -value);
        }

        public void Execute()
        {
            receiver.Add(value);
        }
    }
}
