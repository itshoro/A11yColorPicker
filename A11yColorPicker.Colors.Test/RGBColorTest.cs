﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;

namespace A11yColorPicker.Colors.Test
{
    [TestClass]
    public class RGBColorTest
    {
        [TestMethod]
        public void TestBlackCanBeRepresentedAsAnRGBColor()
        {
            var black = new RGBColor(0, 0, 0);

            new[] { black.R, black.G, black.B }.Should().BeEquivalentTo(new byte[] { 0, 0, 0 });
        }

        [TestMethod]
        public void TestWhiteCanBeRepresentedAsAnRGBColor()
        {
            var black = new RGBColor(0xFF, 0xFF, 0xFF);

            new[] { black.R, black.G, black.B }.Should().BeEquivalentTo(new byte[] { 0xFF, 0xFF, 0xFF });
        }

        [TestMethod]
        public void TestRGBColorCanBeGeneratedFromHexStringWithoutHashSign()
        {
            var color = RGBColor.FromHexString("000000");
            CollectionAssert.Equals(new byte[] { 0xFF, 0xFF, 0xFF }, new[] { color.R, color.G, color.B });
        }

        [TestMethod]
        public void TestRGBColorCanBeGeneratedFromHexStringWithPoundSign()
        {
            var color = RGBColor.FromHexString("#000000");
            CollectionAssert.Equals(new byte[] { 0xFF, 0xFF, 0xFF }, new[] { color.R, color.G, color.B });
        }

        [TestMethod]
        public void TestHexColorCanBeGeneratedWithShortHandNotation()
        {

            var color = RGBColor.FromHexString("#FC0");
            CollectionAssert.Equals(new byte[] { 0xFF, 0xCC, 0x00 }, new[] { color.R, color.G, color.B });
        }

        [TestMethod]
        public void TestHexColorCanOnlyUseHexadecimalValues()
        {
            Assert.ThrowsException<FormatException>(
            () => {
                var color = RGBColor.FromHexString("#ZZZZZZ");
            });
        }

        [TestMethod]
        public void TestHexColorNeedsAtleastThreeDigits()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
            () => {
                var color = RGBColor.FromHexString("#FF");
            });
        }

        [TestMethod]
        public void TestHexColorCantHaveFourDigits()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
            () => {
                var color = RGBColor.FromHexString("#0000");
            });
        }

        public void TestHexColorCantHaveFiveDigits()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
            () => {
                var color = RGBColor.FromHexString("#00000");
            });
        }

        [TestMethod]
        public void TestHexColorCantHaveMoreThanSixDigits()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
            () => {
                var color = RGBColor.FromHexString("#0000000");
            });
        }

        [TestMethod]
        public void TestRGBColorCanBeEqualToHSLColor()
        {
            var rgbColor = new RGBColor(0, 0, 0);
            var hslColor = new HSLColor(0, 0, 0);

            rgbColor.Should().Be(hslColor);
        }
    }
}
