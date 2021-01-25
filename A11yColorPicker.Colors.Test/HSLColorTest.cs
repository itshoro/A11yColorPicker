using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11yColorPicker.Colors.Test
{
    [TestClass]
    public class HSLColorTest
    {
        [TestMethod]
        public void TestBlackCanBeRepresentedAsAHSLColor()
        {
            var black = new HSLColor(0, 0, 0);

            new[] { black.H, black.S, black.L }.Should().BeEquivalentTo(new byte[] { 0, 0, 0 });
        }

        [TestMethod]
        public void TestWhiteCanBeRepresentedAsAnHSLColor()
        {
            var black = new HSLColor(0, 0, 1);

            new[] { black.H, black.S, black.L }.Should().BeEquivalentTo(new byte[] { 0, 0, 1 });
        }


        [TestMethod]
        public void TestHueIsDiscardedWhenLuminanceIs100Percent()
        {
            var black = new HSLColor(359, 0, 1);

            new[] { black.H, black.S, black.L }.Should().BeEquivalentTo(new byte[] { 0, 0, 1 });
        }

        [TestMethod]
        public void TestHueIsDiscardedWhenLuminanceIs0Percent()
        {
            var black = new HSLColor(359, 0, 0);

            new[] { black.H, black.S, black.L }.Should().BeEquivalentTo(new byte[] { 0, 0, 0 });
        }

        [TestMethod]
        public void TestHueCantBeBiggerThan360Degrees()
        {
            FluentActions.Invoking(() => new HSLColor(361,0,0)).Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void TestSaturationCantBeBiggerThan1()
        {
            FluentActions.Invoking(() => new HSLColor(0, 2, 0)).Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void TestLuminanceCantBeBiggerThan1()
        {
            FluentActions.Invoking(() => new HSLColor(0, 0, 2)).Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void TestSimpleHSLColorCanBeEqualToRGBColor()
        {
            var rgbColor = new RGBColor(0, 0, 0);
            var hslColor = new HSLColor(0, 0, 0);

            hslColor.Should().Be(rgbColor);
        }

        [TestMethod]
        public void TestComplexHSLColorCanBeEqualToRGBColor()
        {
            var hslColor = new HSLColor(348, 0.91, 0.5);
            var rgbColor = RGBColor.FromHexString("#F20C3A");

            hslColor.Should().Be(rgbColor);
        }

        [TestMethod]
        public void TestHSLColorCanProduceAProperStringRepresentation()
        {
            var hslColor = new HSLColor(348, 0.91, 0.5);

            hslColor.ToString().Should().BeEquivalentTo("hsl(348°, 91%, 50%)");
        }
    }
}
