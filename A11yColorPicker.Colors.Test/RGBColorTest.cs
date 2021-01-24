using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

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
        public void TestRGBColorCanBeEqualToHexColor()
        {
            var rgbColor = new RGBColor(0, 0, 0);
            var hexColor = new HexColor("#000");

            rgbColor.Should().Be(hexColor);
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
