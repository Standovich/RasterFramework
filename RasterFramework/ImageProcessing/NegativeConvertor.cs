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
        public static Color[,] ConvertToNegative(Color[,] sourceImage)
        {
            //ImageBitmap negativeImage = new ImageBitmap(sourceImage.GetWidth(), sourceImage.GetHeight());
            Color[,] negativeImage = new Color[sourceImage.GetLength(0), sourceImage.GetLength(1)];

            for (int y = 0; y < negativeImage.GetLength(0); y++)
            {
                for (int x = 0; x < negativeImage.GetLength(1); x++)
                {
                    Color negativePixel = 
                        Color.FromArgb(255,
                        255 - sourceImage[y,x].R,
                        255 - sourceImage[y, x].G,
                        255 - sourceImage[y, x].B);
                    negativeImage[y,x] = negativePixel;
                }
            }

            return negativeImage;
        }
    }
}
