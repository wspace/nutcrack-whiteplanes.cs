using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Whiteplanes.Test
{
    [TestClass]
    public class TestException
    {
        [TestMethod]
        [ExpectedException(typeof(SyntaxException))]
        public void TestExceptionImpOnly()
        {
            using (var invalid = new MemoryStream(Encoding.Unicode.GetBytes("S ")))
                new Whiteplanes(invalid);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxException))]
        public void TestExceptionInvalidImp()
        {
            using (var invalid = new MemoryStream(Encoding.Unicode.GetBytes("T\t")))
                new Whiteplanes(invalid);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxException))]
        public void TestExceptionInvalidLiteral()
        {
            using (var invalid = new MemoryStream(Encoding.Unicode.GetBytes("S S T\tT\t")))
                new Whiteplanes(invalid);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxException))]
        public void TestExceptionInvalidStackTabTab()
        {
            using (var invalid = new MemoryStream(Encoding.Unicode.GetBytes("S T\tT\t")))
                new Whiteplanes(invalid);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxException))]
        public void TestExceptionInvalidArithmeticTabNewline()
        {
            using (var invalid = new MemoryStream(Encoding.Unicode.GetBytes("T\tS T\tN\n")))
                new Whiteplanes(invalid);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxException))]
        public void TestExceptionInvalidArithmeticNewline()
        {
            using (var invalid = new MemoryStream(Encoding.Unicode.GetBytes("T\tS N\n")))
                new Whiteplanes(invalid);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxException))]
        public void TesExceptiontInvalidHeapNewline()
        {
            using (var invalid = new MemoryStream(Encoding.Unicode.GetBytes("T\tT\tN\n")))
                new Whiteplanes(invalid);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxException))]
        public void TestExceptionInvalidFlowNewlineSpace()
        {
            using (var invalid = new MemoryStream(Encoding.Unicode.GetBytes("N\nN\nS ")))
                new Whiteplanes(invalid);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxException))]
        public void TestExceptionInvalidFlowNewlineTab()
        {
            using (var invalid = new MemoryStream(Encoding.Unicode.GetBytes("N\nN\nT\t")))
                new Whiteplanes(invalid);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxException))]
        public void TestExceptionInvalidIoStackNewline()
        {
            using (var invalid = new MemoryStream(Encoding.Unicode.GetBytes("T\tN\nS N\n")))
                new Whiteplanes(invalid);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxException))]
        public void TestExceptionInvalidIoTabNewline()
        {
            using (var invalid = new MemoryStream(Encoding.Unicode.GetBytes("T\tN\nT\tN\n")))
                new Whiteplanes(invalid);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxException))]
        public void TestExceptionInvalidIoNewline()
        {
            using (var invalid = new MemoryStream(Encoding.Unicode.GetBytes("T\tN\nN\n")))
                new Whiteplanes(invalid);
        }
    }
}
