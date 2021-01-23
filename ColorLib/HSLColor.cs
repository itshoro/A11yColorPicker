using System;
using System.Collections.Generic;
using System.Text;

namespace ColorLib
{
    public class HSLColor : IConvertibleColor
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
        public HexColor ToHex()
        {
            throw new NotImplementedException();
        }

        public HSLColor ToHSL()
        {
            return this;
        }

        public RGBColor ToRGB()
        {
            throw new NotImplementedException();
        }
    }
}
