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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
