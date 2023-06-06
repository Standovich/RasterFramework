using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Processing
{
    internal class Saturation : IFilter
    {
        private float coeficient = 0;

        public Core.Image Apply(Core.Image sourceImage)
        {
            int width = sourceImage.GetWidth();
            int height = sourceImage.GetHeight();

            Core.Image newImage = new(width, height);
            Color[,] newRawData = newImage.GetRawData();
            Color[,] sourceRawData = sourceImage.GetRawData();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    HSL hsl = HSL.CreateHSL(sourceRawData[x, y]);

                    float newSat = hsl.Saturation + coeficient;

                    if (newSat < 0) hsl.Saturation = 0;
                    else if (newSat > 1) hsl.Saturation = 1;
                    else hsl.Saturation = newSat;

                    newRawData[x, y] = hsl.GetRGB();
                }
            }

            newImage.SetRawData(newRawData);
            return newImage;
        }

        public string GetFilterDescription()
        {
            return "Umožňuje úpravu barev obrazu pomocí HSL modelu.";
        }
    }
}
