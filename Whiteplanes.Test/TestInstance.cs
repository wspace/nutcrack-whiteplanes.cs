using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace Whiteplanes.Test
{
    [TestClass]
    public class TestInstance
    {
        [TestMethod]
        public void TestEqual()
        {
            var addition = "  \t\t\t\t\t\n  \t\t\t\t\n\t   ";
            var subtraction = "  \t\t\t\t\n  \t\t\t\t\t\n\t  \t";
            using (MemoryStream c1 = new MemoryStream(Encoding.Unicode.GetBytes(addition)),
                                c2 = new MemoryStream(Encoding.Unicode.GetBytes("S S S N\n")),
                                c3 = new MemoryStream(Encoding.Unicode.GetBytes(subtraction)))
            {
                var instance1 = new Whiteplanes(c1);
                var instance2 = new Whiteplanes(c2);
                var instance3 = new Whiteplanes(c3);
                Assert.IsFalse(instance1.Equals(new object()));
                Assert.IsFalse(instance1.Equals(instance2));
                Assert.IsFalse(instance1.Equals(instance3));
                Assert.IsFalse(instance1.GetHashCode() == instance2.GetHashCode());
                Assert.IsFalse(instance1.GetHashCode() == instance3.GetHashCode());
                Assert.IsFalse(instance2.GetHashCode() == instance3.GetHashCode());
            }

        }
    }
}
