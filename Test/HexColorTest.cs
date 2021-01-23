using ColorLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    [TestClass]
    public class HexColorTest
    {
        [TestMethod]
        public void TestHexColorCanBeGeneratedWithoutPoundSign()
        {
            var color = new HexColor("000000");
            CollectionAssert.Equals(new byte[] { 0xFF, 0xFF, 0xFF }, new[] { color.R, color.G, color.B });
        }

        [TestMethod]
        public void TestHexColorCanBePrependedWithAPoundSign()
        {
            var color = new HexColor("#000000");
            CollectionAssert.Equals(new byte[] { 0xFF, 0xFF, 0xFF }, new[] { color.R, color.G, color.B });
        }

        [TestMethod]
        public void TestHexColorCanBeGeneratedWithShortHandNotation()
        {

            var color = new HexColor("#FC0");
            CollectionAssert.Equals(new byte[] { 0xFF, 0xCC, 0x00 }, new[] { color.R, color.G, color.B });
        }

        [TestMethod]
        public void TestHexColorCanOnlyUseHexadecimalValues()
        {
            Assert.ThrowsException<FormatException>(
            () => {
                var color = new HexColor("#ZZZZZZ");
            });
        }


        [TestMethod]
        public void TestHexColorNeedsAtleastThreeDigits()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
            () => {
                var color = new HexColor("#FF");
            });
        }

        [TestMethod]
        public void TestHexColorCantHaveFourDigits()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
            () => {
                var color = new HexColor("#0000");
            });
        }

        public void TestHexColorCantHaveFiveDigits()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
            () => {
                var color = new HexColor("#00000");
            });
        }

        [TestMethod]
        public void TestHexColorCantHaveMoreThanSixDigits()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
            () => {
                var color = new HexColor("#0000000");
            });
        }
    }

}
