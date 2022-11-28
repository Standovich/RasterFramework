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
        public static ImageBitmap ChangeRGB(double r, double g, double b, ImageBitmap sourceImage)
        {
            ImageBitmap newImage = new ImageBitmap(sourceImage.GetWidth(), sourceImage.GetHeight());

            for (int y = 0; y < newImage.GetWidth(); y++)
            {
                for (int x = 0; x < newImage.GetHeight(); x++)
                {
                    double newR = (r / 100) * sourceImage.GetPixel(y, x).R > 255 
                        ? 255 : (r / 100) * sourceImage.GetPixel(y, x).R;
                    double newG = (g / 100) * sourceImage.GetPixel(y, x).G > 255 
                        ? 255 : (g / 100) * sourceImage.GetPixel(y, x).G;
                    double newB = (b / 100) * sourceImage.GetPixel(y, x).B > 255 
                        ? 255 : (b / 100) * sourceImage.GetPixel(y, x).B;

                    Color newPixel =
                        Color.FromArgb(255,
                        (int)newR,
                        (int)newG,
                        (int)newB);
                    newImage.SetPixel(y, x, newPixel);
                }
            }

            return newImage;
        }

        public static ImageBitmap ChangeHSL(int h, float s, float l, ImageBitmap sourceImage)
        {
            ImageBitmap newImage = new ImageBitmap(sourceImage.GetWidth(), sourceImage.GetHeight());

            for (int y = 0; y < sourceImage.GetWidth(); y++)
            {
                for (int x = 0; x < sourceImage.GetHeight(); x++)
                {
                    HSL hsl = new(sourceImage.GetPixel(y, x));

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

                    newImage.SetPixel(y, x, hsl.ToRGB());
                }
            }

            return newImage;
        }
    }
}
