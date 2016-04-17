using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Whiteplanes.Test
{
    
    [TestClass]
    public class TestWhiteplanes
    {
        /// <summary>
        /// 
        /// </summary>
        internal StringWriter Writer { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        internal Whiteplanes.OutputEventHandler output = (object sender, Whiteplanes.OutputEventArgs e) =>
        {
            Type[] genericArgs = sender.GetType().GetGenericArguments();
            if (genericArgs[0].Name.Equals("Char"))
            {
                Console.Write((char)e.Code);
            }
            else
            {
                Console.Write(e.Code);
            }
        };

        /// <summary>
        /// 
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Writer = new StringWriter();
            Console.SetOut(Writer);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [DeploymentItem("Resources/HelloWorld.ws")]
        public void TestHelloWorld()
        {
            using (FileStream fs = new FileStream("HelloWorld.ws", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                var interpreter = new Whiteplanes(fs);
                interpreter.OutputEvent += output;
                interpreter.Run(new Context());
                Assert.AreEqual("Hello World", Writer.GetStringBuilder().ToString().Trim());

            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [DeploymentItem("Resources/HeapControl.ws")]
        public void TestHeapControl()
        {
            using (FileStream fs = new FileStream("HeapControl.ws", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                var interpreter = new Whiteplanes(fs);
                interpreter.OutputEvent += output;
                interpreter.Run(new Context());
                Assert.AreEqual("Hello World", Writer.GetStringBuilder().ToString().Trim());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [DeploymentItem("Resources/FlowControl.ws")]
        public void TestFlowControl()
        {
            using (FileStream fs = new FileStream("FlowControl.ws", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                var interpreter = new Whiteplanes(fs);
                interpreter.OutputEvent += output;
                interpreter.Run(new Context());
                Assert.AreEqual("52", Writer.GetStringBuilder().ToString().Trim());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [DeploymentItem("Resources/Count.ws")]
        public void TestCount()
        {
            using (FileStream fs = new FileStream("Count.ws", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                var interpreter = new Whiteplanes(fs);
                interpreter.OutputEvent += output;
                interpreter.Run(new Context());
                Assert.AreEqual("1\n2\n3\n4\n5\n6\n7\n8\n9\n10", Writer.GetStringBuilder().ToString().Trim());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [DeploymentItem("Resources/Input.ws")]
        public void TestInput()
        {
            using (FileStream fs = new FileStream("Input.ws", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                var interpreter = new Whiteplanes(fs);
                interpreter.InputEvent = (object sender) => { return 72; };
                interpreter.OutputEvent += output;
                interpreter.Run(new Context());
                Assert.AreEqual("H72", Writer.GetStringBuilder().ToString().Trim());
            }
        }
    }
}
