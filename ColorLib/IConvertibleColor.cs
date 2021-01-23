using System;
using System.Collections.Generic;
using System.Text;

namespace ColorLib
{
    public interface IConvertibleColor
    {
        public HexColor ToHex();
        public HSLColor ToHSL();
        public RGBColor ToRGB();
    }
}
