using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace A11yColorPicker.Colors.Test
{
    [TestClass]
    public class IConvertibleColorTest
    {
        [TestMethod]
        public void TestRGBColorCanBeConvertedToHexColor()
        {
            var rgbColor = new RGBColor(0, 0, 0);
            var hexColor = rgbColor.ToHex();

            hexColor.Should().Be(rgbColor);
        }

        [TestMethod]
        public void TestRGBColorCanBeConvertedToHSLColor()
        {
            var rgbColor = new RGBColor(0, 0, 0);
            var hslColor = rgbColor.ToHSL();

            hslColor.Should().Be(rgbColor);
        }
        [TestMethod]
        public void TestHexColorCanBeConvertedToRGBColor()
        {
            var hexColor = new HexColor("#000");
            var rgbColor = hexColor.ToRGB();

            rgbColor.Should().Be(hexColor);

        }
        [TestMethod]
        public void TestHexColorCanBeConvertedToHSLColor()
        {
            var hexColor = new HexColor("#000");
            var hslColor = hexColor.ToHSL();

            hslColor.Should().Be(hexColor);
        }

        [TestMethod]
        public void TestHSLColorCanBeConvertedToHexColor()
        {
            var hslColor = new HSLColor(0, 0, 0);
            var hexColor = hslColor.ToHex();

            hexColor.Should().Be(hslColor);
        }

        [TestMethod]
        public void TestHSLColorCanBeConvertedToRGBColor()
        {
            var hslColor = new HSLColor(0, 0, 0);
            var rgbColor = hslColor.ToRGB();

            rgbColor.Should().Be(hslColor);
        }
    }
}
