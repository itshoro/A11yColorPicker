﻿using ColorLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    [TestClass]
    public class RGBColorTest
    {
        [TestMethod]
        public void TestBlackCanBeRepresentedAsAnRGBColor()
        {
            var black = new RGBColor(0, 0, 0);
            CollectionAssert.AreEqual(new byte[] { 0, 0, 0 }, new[] { black.R, black.G, black.B });
        }

        [TestMethod]
        public void TestWhiteCanBeRepresentedAsAnRGBColor()
        {
            var black = new RGBColor(0xFF, 0xFF, 0xFF);
            CollectionAssert.AreEqual(new byte[] { 0xFF, 0xFF, 0xFF }, new[] { black.R, black.G, black.B });
        }
    }
}
