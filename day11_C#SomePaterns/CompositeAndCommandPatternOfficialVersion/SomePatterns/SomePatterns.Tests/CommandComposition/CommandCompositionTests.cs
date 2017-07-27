using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomePatterns.CommandComposition;

namespace SomePatterns.Tests
{
    [TestClass]
    public class CommandCompositionTests
    {
        private ICommand CreateAddCommand(Receiver receiver, decimal value)
        {
            return new AddCommand(receiver, value);
        }

        private ICommand CreateMultiplyCommand(Receiver receiver, decimal value)
        {
            return new MultiplyCommand(receiver, value);
        }

        private ICommand CreateCompositeCommand(params ICommand[] commands)
        {
            return new CompositeCommand(commands);
        }

        [TestMethod]
        public void WhenAdding500To12WeGet512()
        {
            var receiver = new Receiver(12);

            var addCommand = CreateAddCommand(receiver, 500);

            addCommand.Execute();

            Assert.AreEqual(512, receiver.Value);
        }

        [TestMethod]
        public void WhenMultiplying3With13WeGet39()
        {
            var receiver = new Receiver(3);

            var multiplyCommand = CreateMultiplyCommand(receiver, 13);

            multiplyCommand.Execute();

            Assert.AreEqual(39, receiver.Value);
        }

        [TestMethod]
        public void WhenAdding100To50AndMultiplyingWith3WeGet450()
        {
            var receiver = new Receiver(50);

            var addCommand = CreateAddCommand(receiver, 100);
            var multiplyCommand = CreateMultiplyCommand(receiver, 3);
            var compositeCommand = CreateCompositeCommand(addCommand, multiplyCommand);

            compositeCommand.Execute();

            Assert.AreEqual(450, receiver.Value);
        }

        [TestMethod]
        public void WhenMultplying50With100AndAdding13WeGet5013()
        {
            var receiver = new Receiver(50);

            var addCommand = CreateAddCommand(receiver, 13);
            var multiplyCommand = CreateMultiplyCommand(receiver, 100);
            var compositeCommand = CreateCompositeCommand(multiplyCommand, addCommand);

            compositeCommand.Execute();

            Assert.AreEqual(5013, receiver.Value);
        }

        [TestMethod]
        public void WhenAdding10To50AndThenUndoingWeGet50()
        {
            var receiver = new Receiver(50);

            var addCommand = CreateAddCommand(receiver, 10);
            var multiplyCommand = CreateMultiplyCommand(receiver, 2);

            var doCommmands = CreateCompositeCommand(addCommand, multiplyCommand);

            var undoMultiplyCommand = CreateMultiplyCommand(receiver, 0.5m);
            var undoAddCommand = CreateAddCommand(receiver, -10);

            var undoCommands = CreateCompositeCommand(undoMultiplyCommand, undoAddCommand);

            var hugeCommand = CreateCompositeCommand(doCommmands, undoCommands);

            hugeCommand.Execute();

            Assert.AreEqual(50, receiver.Value);
        }

        [TestMethod]
        public void WhenAdding10To50AndMultiplyingBy10ThenUndoingWeGet50()
        {
            var receiver = new Receiver(50);

            var addCommand = CreateAddCommand(receiver, 10);
            var multiplyCommand = CreateMultiplyCommand(receiver, 2);

            var doCommmands = CreateCompositeCommand(addCommand, multiplyCommand);

            doCommmands.Execute();

            var undoDoCommands = doCommmands.CreateUndoCommand();

            undoDoCommands.Execute();

            Assert.AreEqual(50, receiver.Value);
        }
    }
}
