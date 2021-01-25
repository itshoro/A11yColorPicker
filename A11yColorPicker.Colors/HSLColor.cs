using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace A11yColorPicker.Colors
{
    public class HSLColor : IConvertibleColor, IEquatable<HSLColor>, IEquatable<RGBColor>
    {
        public short H { get; }
        public double S { get; }
        public double L { get; }

        public HSLColor(short h, double s, double l)
        {
            if (h > 360) throw new ArgumentOutOfRangeException("Hue has to be a value between 0 and 360");
            if (s > 1) throw new ArgumentOutOfRangeException("Saturation has to be a value between 0 and 1");
            if (l > 1) throw new ArgumentOutOfRangeException("Luminance has to be a value between 0 and 1");

            L = l;

            if (L == 0.0 || L == 1.0)
            {
                H = 0;
                S = 0.0;
            }
            else
            {
                H = (short)(h % 360);
                S = s;
            }
        }

        public HSLColor ToHSL()
        {
            return this;
        }

        public RGBColor ToRGB()
        {
            var c = (1 - Math.Abs(2 * L - 1)) * S;
            var _H = H / 60.0;

            var x = c * (1 - Math.Abs((_H % 2.0) - 1));
            var m = L - c * 0.5;

            (double, double, double) _ = H switch
            { 
                <= 60  => (c, x, 0),
                <= 120 => (x, c, 0),
                <= 180 => (0, c, x),
                <= 240 => (0, x, c),
                <= 300 => (x, 0, c),
                <= 360 => (c, 0, x),
                _ => (0,0,0)
            };

            byte r = Convert.ToByte(Math.Round(255 * (_.Item1 + m)));
            byte g = Convert.ToByte(Math.Round(255 * (_.Item2 + m)));
            byte b = Convert.ToByte(Math.Round(255 * (_.Item3 + m)));

            return new RGBColor(r, g, b);
        }

        public override string ToString()
        {
            return $"hsl({H}°, {S * 100}%, {L * 100}%)";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(obj, this))
                return true;

            return obj switch
            {
                HSLColor hsl => Equals(hsl),
                RGBColor rgb => Equals(rgb),
                _ => false
            };
        }

        public bool Equals([AllowNull] RGBColor other)
        {
            return this == other;
        }

        public bool Equals([AllowNull] HSLColor other)
        {
            return this == other;
        }

        public static bool operator ==(HSLColor hslColor1, HSLColor hslColor2)
        {
            return hslColor1.H == hslColor2.H && hslColor1.S == hslColor2.S && hslColor1.L == hslColor2.L;
        }
        public static bool operator !=(HSLColor hslColor1, HSLColor hslColor2)
        {
            return !(hslColor1 == hslColor2);
        }

        public static bool operator ==(HSLColor hslColor1, RGBColor rgbColor)
        {
            var hslColor2 = rgbColor.ToHSL();
            return hslColor1 == hslColor2;
        }
        public static bool operator !=(HSLColor hslColor1, RGBColor rgbColor)
        {
            return !(hslColor1 == rgbColor);
        }

        public override int GetHashCode()
        {
            return H * 100 * 100 + (int)(S * 100) * 100 + (int)(L * 100);
        }
    }
}
