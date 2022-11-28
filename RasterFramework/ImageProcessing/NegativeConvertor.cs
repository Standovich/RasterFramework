using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.ImageProcessing
{
    internal class NegativeConvertor
    {
        public static ImageBitmap ConvertToNegative(ImageBitmap sourceImage)
        {
            ImageBitmap negativeImage = new ImageBitmap(sourceImage.GetWidth(), sourceImage.GetHeight());

            for (int y = 0; y < negativeImage.GetWidth(); y++)
            {
                for (int x = 0; x < negativeImage.GetHeight(); x++)
                {
                    Color negativePixel = 
                        Color.FromArgb(255,
                        255 - sourceImage.GetPixel(y,x).R,
                        255 - sourceImage.GetPixel(y, x).G,
                        255 - sourceImage.GetPixel(y, x).B);
                    negativeImage.SetPixel(y, x, negativePixel);
                }
            }

            return negativeImage;
        }
    }
}
