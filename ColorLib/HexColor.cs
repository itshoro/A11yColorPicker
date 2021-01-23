﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorLib
{
    public class HexColor : IConvertibleColor
    {
        public byte R { get; }
        public byte G { get; }
        public byte B { get; }

        public HexColor(string hexRepresentation)
        {
            hexRepresentation = hexRepresentation.Trim();
            if (hexRepresentation[0] == '#')
                hexRepresentation = hexRepresentation.Substring(1);

            if (hexRepresentation.Length == 3)
            {
                hexRepresentation = new string(
                    new []
                    { 
                        hexRepresentation[0],
                        hexRepresentation[0],
                        hexRepresentation[1],
                        hexRepresentation[1],
                        hexRepresentation[2],
                        hexRepresentation[2] 
                    }
                );
            }

            if (hexRepresentation.Length == 6)
            {
                R = Convert.ToByte(hexRepresentation.Substring(0, 2));
                G = Convert.ToByte(hexRepresentation.Substring(2, 2));
                B = Convert.ToByte(hexRepresentation.Substring(4, 2));
            }
            else
            {
                 throw new ArgumentOutOfRangeException();
            }
        }


        public HexColor ToHex()
        {
            return this;
        }

        public HSLColor ToHSL()
        {
            var r = R / 255;
            var g = G / 255;
            var b = B / 255;

            var mightBeMax = MathF.Max(r, g);
            var max = MathF.Max(mightBeMax, b);

            var mightBeMin = MathF.Min(r, g);
            var min = MathF.Min(mightBeMax, b);

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


            return new HSLColor(Convert.ToInt16(Math.Round(hue)), saturation, luminance);
        }

        public RGBColor ToRGB()
        {
            return new RGBColor(R, G, B);
        }
    }
}
