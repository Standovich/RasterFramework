using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.ImageProcessing
{
    internal class GrayscaleConvertor
    {
        public static ImageBitmap ApplyGrayScale(int i, ImageBitmap coloredImage)
        {
            switch (i)
            {
                case 0:
                    return ToAverageGrayscale(coloredImage);
                case 1:
                    return ToWeightedGrayscale(coloredImage);
                default: return coloredImage;
            }
        }
        public static ImageBitmap ToWeightedGrayscale(ImageBitmap coloredImage)
        {
            ImageBitmap grayImage = new ImageBitmap(coloredImage.GetWidth(), coloredImage.GetHeight());

            for (int y = 0; y < grayImage.GetWidth(); y++)
            {
                for (int x = 0; x < grayImage.GetHeight(); x++)
                {
                    int r = coloredImage.GetPixel(y, x).R;
                    int g = coloredImage.GetPixel(y, x).G;
                    int b = coloredImage.GetPixel(y, x).B;
                    int gray = (int)((r * 0.299) + (g * 0.587) + (b * 0.114));

                    Color grayPixel = Color.FromArgb(255, gray, gray, gray);
                    grayImage.SetPixel(y,x,grayPixel);
                }
            }

            return grayImage;
        }

        public static ImageBitmap ToAverageGrayscale(ImageBitmap coloredImage)
        {
            ImageBitmap grayImage = new ImageBitmap(coloredImage.GetWidth(), coloredImage.GetHeight());

            for (int y = 0; y < grayImage.GetWidth(); y++)
            {
                for (int x = 0; x < grayImage.GetHeight(); x++)
                {
                    int r = coloredImage.GetPixel(y, x).R;
                    int g = coloredImage.GetPixel(y, x).G;
                    int b = coloredImage.GetPixel(y, x).B;
                    int gray = (r / 3) + (g / 3) + (b / 3);

                    Color grayPixel = Color.FromArgb(0, gray, gray, gray);
                    grayImage.SetPixel(y, x, grayPixel);
                }
            }

            return grayImage;
        }

        public static int RGBtoGray(Color color)
        {
            int r = color.R;
            int g = color.G;
            int b = color.B;
            return (int)((r * 0.299) + (g * 0.587) + (b * 0.114));
        }
    }
}
