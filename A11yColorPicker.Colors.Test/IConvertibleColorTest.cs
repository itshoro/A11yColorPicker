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
        public void TestRGBColorCanBeConvertedToHSLColor()
        {
            var rgbColor = new RGBColor(0, 0, 0);
            var hslColor = rgbColor.ToHSL();

            hslColor.Should().Be(rgbColor);
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
