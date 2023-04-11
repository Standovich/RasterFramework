using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.ImageProcessing
{
    internal class ColorController
    {
        public static Color[,] ChangeRGB(double r, double g, double b, Color[,] sourceImage)
        {
            Color[,] newImage = new Color[sourceImage.GetLength(0), sourceImage.GetLength(1)];

            for (int y = 0; y < newImage.GetLength(0); y++)
            {
                for (int x = 0; x < newImage.GetLength(1); x++)
                {
                    double newR = (r / 100) * sourceImage[y, x].R > 255 
                        ? 255 : (r / 100) * sourceImage[y, x].R;
                    double newG = (g / 100) * sourceImage[y, x].G > 255 
                        ? 255 : (g / 100) * sourceImage[y, x].G;
                    double newB = (b / 100) * sourceImage[y, x].B > 255 
                        ? 255 : (b / 100) * sourceImage[y, x].B;

                    Color newPixel =
                        Color.FromArgb(255,
                        (int)newR,
                        (int)newG,
                        (int)newB);
                    newImage[y,x] = newPixel;
                }
            }

            return newImage;
        }

        public static Color[,] ChangeHSL(int h, float s, float l, Color[,] sourceImage)
        {
            Color[,] newImage = new Color[sourceImage.GetLength(0), sourceImage.GetLength(1)];

            for (int y = 0; y < sourceImage.GetLength(0); y++)
            {
                for (int x = 0; x < sourceImage.GetLength(1); x++)
                {
                    HSL hsl = new(sourceImage[y, x]);

                    int newHue = hsl.Hue + h;
                    float newSat = hsl.Saturation + s;
                    float newLig = hsl.Lightness + l;

                    if(newHue < 0) hsl.Hue = newHue + 360;
                    else if(newHue > 360) hsl.Hue = newHue - 360;
                    else hsl.Hue = newHue;

                    if (newSat < 0) hsl.Saturation = 0;
                    else if (newSat > 1) hsl.Saturation = 1;
                    else hsl.Saturation = newSat;

                    if (newLig < 0) hsl.Lightness = 0;
                    else if(newLig > 1) hsl.Lightness = 1;
                    else hsl.Lightness = newLig;

                    newImage[y, x] = hsl.ToRGB();
                }
            }

            return newImage;
        }
    }
}
