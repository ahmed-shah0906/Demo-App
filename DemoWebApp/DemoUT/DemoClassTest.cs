using DemoWebApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoUT
{
    [TestClass]
    public class DemoClassTest
    {
        [TestMethod]
        public void TestMethodWeb()
        {
            DemoClass demoClass = new DemoClass();
            Assert.AreEqual(11, demoClass.Add(5, 6));
        }
    }
}
