using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.CommandComposition
{
    public class AddCommand : ICommand
    {
        public decimal value;
        public Receiver receiver;

        public AddCommand(Receiver receive, decimal value)
        {
            this.receiver = receive;
            this.value = value;
        }

        public void Execute()
        {
            receiver.Add(value);
        }
    }
}
