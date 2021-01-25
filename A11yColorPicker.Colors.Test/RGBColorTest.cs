using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var white = new RGBColor(0xFF, 0xFF, 0xFF);

            new[] { white.R, white.G, white.B }.Should().BeEquivalentTo(new byte[] { 0xFF, 0xFF, 0xFF });
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
        public void TestSimpleRGBColorCanBeEqualToHSLColor()
        {
            var rgbColor = new RGBColor(0, 0, 0);
            var hslColor = new HSLColor(0, 0, 0);

            rgbColor.Should().Be(hslColor);
        }

        [TestMethod]
        public void TestComplexRGBColorCanBeEqualToHSLColor()
        {
            var rgbColor = RGBColor.FromHexString("#F20C3A");
            var hslColor = new HSLColor(348, 0.91, 0.5);

            rgbColor.Should().Be(hslColor);
        }

        [TestMethod]
        public void TestRGBColorCanProduceAProperStringRepresentation()
        {
            var rgbColor = RGBColor.FromHexString("F20C3A");

            rgbColor.ToString().Should().BeEquivalentTo("rgb(242, 12, 58)");
        }

        [TestMethod]
        public void TestHSLColorCanProduceAProperHexStringRepresentation()
        {
            var rgbColor = RGBColor.FromHexString("F20C3A");

            rgbColor.ToHexString().Should().BeEquivalentTo("#F20C3A");
        }
    }
}
