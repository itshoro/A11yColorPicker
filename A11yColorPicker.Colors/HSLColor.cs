using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace A11yColorPicker.Colors
{
    public class HSLColor : IConvertibleColor, IEquatable<RGBColor>
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

        public bool Equals([AllowNull] RGBColor other)
        {
            throw new NotImplementedException();
        }
    }
}
