using System;
using System.Collections.Generic;
using System.Text;

namespace ColorLib
{
    public class RGBColor : IConvertibleColor
    {
        public byte R { get; }
        public byte G { get; }
        public byte B { get; }

        public RGBColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public HexColor ToHex()
        {
            return new HexColor(string.Join("", new[] { R,G,B }));
        }

        public HSLColor ToHSL()
        {
            var r = R / 255f;
            var g = G / 255f;
            var b = B / 255f;

            var mightBeMax = MathF.Max(r, g);
            var max = MathF.Max(mightBeMax, b);

            var mightBeMin = MathF.Min(r, g);
            var min = MathF.Min(mightBeMin, b);

            var luminance = (min + max) / 2f;

            var saturation = 0f;
            if (min != max)
            {
                if (luminance <= 0.5f)
                {
                    saturation = (max - min) / (max + min);
                }
                else
                {
                    saturation = (max - min) / (2f - max - min);
                }
            }

            var hue = 0f;
            if (max == r)
            {
                hue = (g - b) / (max - min);
            }
            else if (max == g)
            {
                hue = 2f + (b - r) / (max - min);
            }
            else
            {
                hue = 4f + (r - g) / (max - min);
            }

            hue *= 60;

            while (hue < 0)
            {
                hue += 360f;
            }

            return new HSLColor(Convert.ToInt16(MathF.Round(hue * 100f) * 0.01f), MathF.Round(saturation * 100f) * 0.01f, MathF.Round(luminance * 100f) * 0.01f);
        }

        public RGBColor ToRGB()
        {
            return this;
        }
    }
}
