using ColorLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    [TestClass]
    class RGBColorTest
    {
        [TestMethod]
        public void TestBlackCanBeRepresentedAsAnRGBColor()
        {
            var black = new RGBColor(0, 0, 0);
            Assert.AreEqual(new[] { black.R, black.G, black.B }, new[] { 0, 0, 0 });
        }

        [TestMethod]
        public void TestWhiteCanBeRepresentedAsAnRGBColor()
        {
            var black = new RGBColor(0xFF, 0xFF, 0xFF);
            Assert.AreEqual(new[] { black.R, black.G, black.B }, new[] { 0xFF, 0xFF, 0xFF });
        }
    }
}
