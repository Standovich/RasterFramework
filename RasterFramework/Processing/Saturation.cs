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
        public Core.Image Apply(Core.Image sourceImage)
        {
            float coeficient = 0f;

            int width = sourceImage.GetWidth();
            int height = sourceImage.GetHeight();

            Core.Image newImage = new(width, height);
            Color[,] newRawData = newImage.GetRawData();
            Color[,] sourceRawData = sourceImage.GetRawData();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    HSL hsl = HSL.CreateHSL(sourceRawData[y, x]);

                    float newSat = hsl.Saturation + coeficient;

                    if (newSat < 0) hsl.Saturation = 0;
                    else if (newSat > 1) hsl.Saturation = 1;
                    else hsl.Saturation = newSat;

                    newRawData[y, x] = hsl.GetRGB();
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
