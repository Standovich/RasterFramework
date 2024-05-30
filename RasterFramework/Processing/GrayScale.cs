using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Processing
{
    internal class GrayScale : IFilter
    {
        public Core.Image Apply(Core.Image sourceImage)
        {
            Color[,] sourceRawData = sourceImage.GetRawData();

            int width = sourceRawData.GetLength(1);
            int height = sourceRawData.GetLength(0);

            Color[,] grayRawData = new Color[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int gray = (int)RGB.ToGray(sourceRawData[y, x]);

                    Color grayPixel = Color.FromArgb(255, gray, gray, gray);
                    grayRawData[y, x] = grayPixel;
                }
            }

            return new(grayRawData);
        }

        public string GetFilterDescription()
        {
            return "Vrací objekt třídy Image s polem pixelů převedených do šedé škály.";
        }
    }
}
