using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace A11yColorPicker.Colors
{
    public class HSLColor : IConvertibleColor, IEquatable<HSLColor>, IEquatable<RGBColor>
    {
        public short H { get; }
        public float S { get; }
        public float L { get; }

        public HSLColor(short h, float s, float l)
        {
            H = h;
            S = s;
            L = l;
        }

        public HSLColor ToHSL()
        {
            return this;
        }

        public RGBColor ToRGB()
        {
            var c = (1 - MathF.Abs(2 * L - 1)) * S;
            var x = c * (1 - MathF.Abs(H / 60f % 2 - 1));
            var m = L - c / 2;

            (float, float, float) _ = H switch
            { 
                < 60  => (c, x, 0),
                < 120 => (x, c, 0),
                < 180 => (0, c, x),
                < 240 => (0, x, c),
                < 300 => (x, 0, c),
                < 360 => (c, 0, x),
                _ => throw new ArgumentOutOfRangeException()
            };

            byte r = Convert.ToByte((_.Item1 + m) * 255);
            byte g = Convert.ToByte((_.Item2 + m) * 255);
            byte b = Convert.ToByte((_.Item3 + m) * 255);

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
