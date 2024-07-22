namespace RasterFramework.Core
{
    internal class HSL
    {
        public int Hue { get; set; }
        public float Saturation { get; set; }
        public float Lightness { get; set; }

        private HSL(float hue, float saturation, float lightness)
        {
            Hue = (int)hue;
            Saturation = saturation;
            Lightness = lightness;
        }

        public static HSL CreateHSL(Color color)
        {
            float r = color.R / 255.0f;
            float g = color.G / 255.0f;
            float b = color.B / 255.0f;

            float min = Math.Min(Math.Min(r, g), b);
            float max = Math.Max(Math.Max(r, g), b);
            float delta = max - min;

            float lightness = (max + min) / 2;

            float hue;
            float saturation;

            if (delta == 0)
            {
                hue = 0;
                saturation = 0.0f;
            }
            else
            {
                saturation = (lightness <= 0.5) ? 
                    (delta / (max + min)) : (delta / (2 - max - min));

                if (max == r) hue = ((g - b) / 6) / delta;
                else if (max == g) hue = (1.0f / 3) + ((b - r) / 6) / delta;
                else hue = (2.0f / 3) + ((r - g) / 6) / delta;

                if (hue < 0) hue += 1;
                if (hue > 1) hue -= 1;

                hue = (int)(hue * 360);
            }

            return new(hue, saturation, lightness);
        }

        public Color GetRGB()
        {
            byte r = 0;
            byte g = 0;
            byte b = 0;

            if (Saturation == 0)
            {
                r = g = b = (byte)(Lightness * 255);
            }
            else
            {
                float v1, v2;
                float hue = (float)Hue / 360;

                v2 = (Lightness < 0.5) ?
                    (Lightness * (1 + Saturation)) :
                    (Lightness + Saturation) - (Lightness * Saturation);

                v1 = 2 * Lightness - v2;

                r = (byte)(255 * HueValue(v1, v2, hue + (1.0f / 3)));
                g = (byte)(255 * HueValue(v1, v2, hue));
                b = (byte)(255 * HueValue(v1, v2, hue - (1.0f / 3)));
            }

            return Color.FromArgb(r, g, b);
        }

        private double HueValue(float v1, float v2, float h)
        {
            if (h < 0) h += 1;
            if (h > 1) h -= 1;

            if ((6 * h) < 1)
                return (v1 + (v2 - v1) * 6 * h);
            if ((2 * h) < 1)
                return v2;
            if ((3 * h) < 2)
                return (v1 + (v2 - v1) * ((2.0f / 3) - h) * 6);
            return v1;
        }
    }
}
