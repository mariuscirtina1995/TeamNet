using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.CommandComposition
{
    public class CompositeCommand : ICompositeCommand
    {
        List<ICommand> commands = new List<ICommand>();

        public CompositeCommand(ICommand[] commands)
        {
            foreach(var command in commands)
            {
                this.commands.Add(command);
            }
        }

        public void Add(ICommand command)
        {
            commands.Add(command);
        }

        public ICommand CreateUndoCommand()
        {
            List<ICommand> undoCommands = new List<ICommand>();

            //do not modify the commands list;
            for(int i = commands.Count-1; i >= 0; i--)
            {
                var command = commands[i];
                undoCommands.Add(command.CreateUndoCommand());
            }

            return new CompositeCommand(undoCommands.ToArray());
        }

        public void Execute()
        {
            foreach(var command in commands)
            {
                command.Execute();
            }
        }

        public void Remove(ICommand command)
        {
            commands.Remove(command);
        }
    }
}
