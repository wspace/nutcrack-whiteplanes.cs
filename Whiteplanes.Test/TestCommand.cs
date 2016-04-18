using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Whiteplanes.Commands;

namespace Whiteplanes.Test
{
    [TestClass]
    public class TestCommand
    {
        [TestMethod]
        public void TestCommandAddition()
        {
            var addition = "S S T\tT\tT\tT\tT\tN\nS S T\tT\tT\tT\tN\nT\tS S S ";
            using (var commandAddition = new MemoryStream(Encoding.Unicode.GetBytes(addition)))
            {
                var interpreter = new Whiteplanes(commandAddition);
                var context = new Context();
                interpreter.Run(context);
                var spy = new PrivateObject(interpreter);
                var commands = (List<Command>)spy.GetField("_commands");
                Assert.AreEqual(3, commands.Count);
                Assert.IsTrue(commands[0] is Push);
                Assert.IsTrue(commands[1] is Push);
                Assert.IsTrue(commands[2] is Addition);

                Assert.AreEqual(46,context.Stack.Pop());
            }
        }

        [TestMethod]
        public void TestCommandSubtraction()
        {
            var subtraction = "S S T\tT\tT\tT\tN\nS S T\tT\tT\tT\tT\tN\nT\tS S T\t";
            using (var commandSubtraction = new MemoryStream(Encoding.Unicode.GetBytes(subtraction)))
            {
                var interpreter = new Whiteplanes(commandSubtraction);
                var context = new Context();
                interpreter.Run(context);
                var spy = new PrivateObject(interpreter);
                var commands = (List<Command>)spy.GetField("_commands");
                Assert.AreEqual(3, commands.Count);
                Assert.IsTrue(commands[0] is Push);
                Assert.IsTrue(commands[1] is Push);
                Assert.IsTrue(commands[2] is Subtraction);

                Assert.AreEqual(16, context.Stack.Pop());
            }
        }

        [TestMethod]
        public void TestCommandMultiplication()
        {

            var multiplication = "S S T\tT\tT\tT\tT\tN\nS S T\tT\tT\tT\tN\nT\tS S N\n";
            using (var commandMultiplication = new MemoryStream(Encoding.Unicode.GetBytes(multiplication)))
            {
                var interpreter = new Whiteplanes(commandMultiplication);
                var context = new Context();
                interpreter.Run(context);
                var spy = new PrivateObject(interpreter);
                var commands = (List<Command>)spy.GetField("_commands");
                Assert.AreEqual(3, commands.Count);
                Assert.IsTrue(commands[0] is Push);
                Assert.IsTrue(commands[1] is Push);
                Assert.IsTrue(commands[2] is Multiplication);

                Assert.AreEqual(465, context.Stack.Pop());
            }
        }

        [TestMethod]
        public void TestCommandDivision()
        {
            var division = "S S T\tS N\nS S T\tT\tT\tS N\nT\tS T\tS ";
            using (var commandDivision = new MemoryStream(Encoding.Unicode.GetBytes(division)))
            {
                var interpreter = new Whiteplanes(commandDivision);
                var context = new Context();
                interpreter.Run(context);
                var spy = new PrivateObject(interpreter);
                var commands = (List<Command>)spy.GetField("_commands");
                Assert.AreEqual(3, commands.Count);
                Assert.IsTrue(commands[0] is Push);
                Assert.IsTrue(commands[1] is Push);
                Assert.IsTrue(commands[2] is Division);

                Assert.AreEqual(7, context.Stack.Pop());
            }
        }
        [TestMethod]
        public void TestCommandModulo()
        {
            var modulo = "S S T\tT\tN\nS S T\tT\tT\tS N\nT\tS T\tT\t";
            using (var commandModulo = new MemoryStream(Encoding.Unicode.GetBytes(modulo)))
            {
                var interpreter = new Whiteplanes(commandModulo);
                var context = new Context();
                interpreter.Run(context);
                var spy = new PrivateObject(interpreter);
                var commands = (List<Command>)spy.GetField("_commands");
                Assert.AreEqual(3, commands.Count);
                Assert.IsTrue(commands[0] is Push);
                Assert.IsTrue(commands[1] is Push);
                Assert.IsTrue(commands[2] is Modulo);

                Assert.AreEqual(2, context.Stack.Pop());
            }
        }
    }
}
