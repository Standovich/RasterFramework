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

            int width = sourceRawData.GetLength(0);
            int height = sourceRawData.GetLength(1);

            Color[,] grayRawData = new Color[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int r = sourceRawData[y, x].R;
                    int g = sourceRawData[y, x].G;
                    int b = sourceRawData[y, x].B;
                    int gray = (int)((r * 0.299) + (g * 0.587) + (b * 0.114));

                    Color grayPixel = Color.FromArgb(255, gray, gray, gray);
                    grayRawData[y, x] = grayPixel;
                }
            }

            Core.Image grayImage = new(width, height);
            grayImage.SetRawData(grayRawData);

            return grayImage;
        }

        public string GetFilterDescription()
        {
            return "Vrací objekt třídy Image s polem pixelů převedených do šedé škály.";
        }
    }
}
