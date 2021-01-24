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

            Assert.Equals(hexColor, rgbColor);
        }

        [TestMethod]
        public void TestRGBColorCanBeConvertedToHSLColor()
        {
            var rgbColor = new RGBColor(0, 0, 0);
            var hslColor = rgbColor.ToHSL();

            Assert.Equals(hslColor, rgbColor);
        }
        [TestMethod]
        public void TestHexColorCanBeConvertedToRGBColor()
        {
            var hexColor = new HexColor("#000");
            var rgbColor = hexColor.ToRGB();

            Assert.AreEqual(hexColor, rgbColor);
        }
        [TestMethod]
        public void TestHexColorCanBeConvertedToHSLColor()
        {
            var hexColor = new HexColor("#000");
            var hslColor = hexColor.ToHSL();

            Assert.AreEqual(hexColor, hslColor);
        }

        [TestMethod]
        public void TestHSLColorCanBeConvertedToHexColor()
        {
            var hslColor = new HSLColor(0, 0, 0);
            var hexColor = hslColor.ToHex();

            Assert.AreEqual(hslColor, hexColor);
        }

        [TestMethod]
        public void TestHSLColorCanBeConvertedToRGBColor()
        {
            var hslColor = new HSLColor(0, 0, 0);
            var rgbColor = hslColor.ToRGB();

            Assert.AreEqual(hslColor, rgbColor);
        }
    }
}
