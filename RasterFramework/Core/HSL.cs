using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Core
{
    internal class HSL
    {
        private double hue;
        private double saturation;
        private double lightness;

        private HSL(double hue, double saturation, double lightness)
        {
            this.hue = hue;
            this.saturation = saturation;
            this.lightness = lightness;
        }

        public HSL CreateHSL(int red, int green, int blue)
        {
            double r = red / 255;
            double g = green / 255;
            double b = blue / 255;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;

            double lightness = (max + min) / 2;

            double saturation = (lightness <= 0.5) ? (delta / (max + min)) : (delta / (2 - max + min));

            double hue;

            if(r == max) hue = ((g - b) % 6) / delta;
            else if(g == max) hue = ((b - r) + 2) / delta;
            else hue = ((r - g) + 4) / delta;

            if(hue < 0) hue += 1;
            if(hue > 1) hue -= 1;

            return new(hue, saturation, lightness);
        }
    }
}
