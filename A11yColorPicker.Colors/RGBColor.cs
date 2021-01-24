using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace A11yColorPicker.Colors
{
    public class RGBColor : IConvertibleColor, IEquatable<HSLColor>
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

        public static RGBColor FromHexString(string hex)
        {
            hex = hex.Trim();
            if (hex[0] == '#')
                hex = hex.Substring(1);

            hex = hex.ToLower();

            if (hex.Length == 3)
            {
                hex = new string(
                    new[]
                    {
                        hex[0],
                        hex[0],
                        hex[1],
                        hex[1],
                        hex[2],
                        hex[2]
                    }
                );
            }

            if (hex.Length == 6)
            {
                return new RGBColor(
                    Convert.ToByte(hex.Substring(0, 2), 16),
                    Convert.ToByte(hex.Substring(2, 2), 16),
                    Convert.ToByte(hex.Substring(4, 2), 16)
                );
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            return $"rgb({R}, {G}, {B})";
        }

        public string ToHexString(bool prependHashSign = true)
        {
            var hex = R.ToString("16") + G.ToString("16") + B.ToString("16");
            if (prependHashSign)
            {
                hex += "#";
            }

            return hex;
        }

        public HSLColor ToHSL()
        {
            var r = R / 255.0;
            var g = G / 255.0;
            var b = B / 255.0;

            var mightBeMax = Math.Max(r, g);
            var max = Math.Max(mightBeMax, b);

            var mightBeMin = Math.Min(r, g);
            var min = Math.Min(mightBeMin, b);

            var luminance = (min + max) / 2.0;

            var saturation = 0.0;
            if (min != max)
            {
                if (luminance <= 0.5)
                {
                    saturation = (max - min) / (max + min);
                }
                else
                {
                    saturation = (max - min) / (2.0 - max - min);
                }
            }

            var hue = 0.0;
            if(max == min)
            {
                hue = 0.0;
            }
            else
            {
                if (max == r)
                {
                    hue = (g - b) / (max - min);
                }
                else if (max == g)
                {
                    hue = 2.0 + (b - r) / (max - min);
                }
                else
                {
                    hue = 4.0 + (r - g) / (max - min);
                }
            }


            hue *= 60;

            while (hue < 0)
            {
                hue += 360;
            }

            return new HSLColor(Convert.ToInt16(Math.Round(hue)), Math.Round(saturation, 2), Math.Round(luminance, 2));
        }

        public RGBColor ToRGB()
        {
            return this;
        }

        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return obj switch
            {
                RGBColor rgb => Equals(rgb),
                HSLColor hsl => Equals(hsl),
                _ => false,
            };
        }

        public static bool operator ==(RGBColor rgbColor, RGBColor rgbColor2)
        {
            return rgbColor.R == rgbColor2.R && rgbColor.G == rgbColor2.G && rgbColor.B == rgbColor2.B;
        }

        public static bool operator !=(RGBColor rgbColor, RGBColor rgbColor2)
        {
            return !(rgbColor == rgbColor2);
        }

        public static bool operator ==(RGBColor rgbColor, HSLColor hslColor)
        {
            // While working on HSLColor.ToRGB() I noticed that there are colors that can't be properly be converted between color formats.
            // E.g. #F20C3A => (348°, 0.91, 0.5) => #F40B3A
            // Therefore I needed to favor one equality over the other.
            var hslColor2 = rgbColor.ToHSL();
            return hslColor == hslColor2;
        }

        public static bool operator !=(RGBColor rgbColor, HSLColor hslColor)
        {
            throw new NotImplementedException();
        }

        public bool Equals([AllowNull] RGBColor other)
        {
            return this == other;
        }

        public bool Equals([AllowNull] HSLColor other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return R << 16 & G << 8 & B;
        }
    }
}
