using ColorLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    [TestClass]
    class HexColorTest
    {
        [TestMethod]
        public void TestHexColorCanBeGeneratedWithoutPoundSign()
        {
            var color = new HexColor("000000");
            Assert.AreEqual(new[] { color.R, color.G, color.B }, new[] { 0xFF, 0xFF, 0xFF });
        }

        [TestMethod]
        public void TestHexColorCanBePrependedWithAPoundSign()
        {
            var color = new HexColor("#000000");
            Assert.AreEqual(new[] { color.R, color.G, color.B }, new[] { 0xFF, 0xFF, 0xFF });
        }

        [TestMethod]
        public void TestHexColorCanBeGeneratedWithShortHandNotation()
        {

            var color = new HexColor("#FC0");
            Assert.AreEqual(new[] { color.R, color.G, color.B }, new[] { 0xFF, 0xCC, 0x00 });
        }

        [TestMethod]
        public void TestHexColorCanOnlyUseHexadecimalValues()
        {
            Assert.ThrowsException<ArgumentException>(
            () => {
                var color = new HexColor("#ZZZZZZ");
            });
        }


        [TestMethod]
        public void TestHexColorNeedsAtleastThreeDigits()
        {
            Assert.ThrowsException<ArgumentException>(
            () => {
                var color = new HexColor("#FF");
            });
        }

        [TestMethod]
        public void TestHexColorCantHaveFourDigits()
        {
            Assert.ThrowsException<ArgumentException>(
            () => {
                var color = new HexColor("#0000");
            });
        }

        public void TestHexColorCantHaveFiveDigits()
        {
            Assert.ThrowsException<ArgumentException>(
            () => {
                var color = new HexColor("#00000");
            });
        }

        [TestMethod]
        public void TestHexColorCantHaveMoreThanSixDigits()
        {
            Assert.ThrowsException<ArgumentException>(
            () => {
                var color = new HexColor("#0000000");
            });
        }
    }

}
