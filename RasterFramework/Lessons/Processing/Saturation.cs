using RasterFramework.Core;
using RasterFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Lessons.Processing
{
    internal class Saturation : IFilter
    {
        public Core.Image Apply(Core.Image sourceImage)
        {
            float coeficient = 0.3f;

            int width = sourceImage.Width;
            int height = sourceImage.Height;

            Core.Image newImage = new(width, height);
            Color[,] newRawData = newImage.RawData;
            Color[,] sourceRawData = sourceImage.RawData;

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

            newImage.RawData = newRawData;
            return newImage;
        }

        public string GetName()
        {
            return "Saturace";
        }
    }
}
