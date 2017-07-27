using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.CommandComposition
{
    public class CompositeCommand : ICompositeCommand
    {
        public List<ICommand> commands = new List<ICommand>();

        public CompositeCommand(ICommand[] commands)
        {
            //this.commands = commands.ToList<ICommand>();

            foreach(var command in commands)
            {
                this.commands.Add(command);
            }
        }

        public void Add(ICommand command)
        {
            commands.Add(command);
        }

        public void Execute()
        {
            foreach(var command in commands)
            {
                command.Execute();
                //Remove(command);
            }

        }

        public void Remove(ICommand command)
        {
            commands.Remove(command);
        }
    }
}
