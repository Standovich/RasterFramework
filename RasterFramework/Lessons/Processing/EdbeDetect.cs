using RasterFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Lessons.Processing
{
    internal class EdbeDetect : IConvolution
    {
        public Core.Image Apply(Core.Image sourceImage, double[,] kernel)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            Color[,] sourceRawData = sourceImage.RawData;
            Color[,] newRawData = new Color[height, width];

            double[,] redData = new double[height, width];
            double[,] greenData = new double[height, width];
            double[,] blueData = new double[height, width];
            int distance = kernel.GetLength(0) / 2;

            //vnitřní pixely
            for (int y = distance; y < height - distance; y++)
            {
                for (int x = distance; x < width - distance; x++)
                {
                    for (int ky = 0; ky < kernel.GetLength(0); ky++)
                    {
                        int indexY = y + ky - distance;
                        for (int kx = 0; kx < kernel.GetLength(1); kx++)
                        {
                            int indexX = x + kx - distance;
                            redData[y, x] += sourceRawData[indexY, indexX].R * kernel[ky, kx];
                            greenData[y, x] += sourceRawData[indexY, indexX].G * kernel[ky, kx];
                            blueData[y, x] += sourceRawData[indexY, indexX].B * kernel[ky, kx];
                        }
                    }
                }
            }

            //naplnit novou bitmapu
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (redData[y, x] > 255 || redData[y, x] < 0) redData[y, x] = sourceRawData[y, x].R;
                    if (greenData[y, x] > 255 || greenData[y, x] < 0) greenData[y, x] = sourceRawData[y, x].G;
                    if (blueData[y, x] > 255 || blueData[y, x] < 0) blueData[y, x] = sourceRawData[y, x].B;

                    newRawData[y, x] = Color.FromArgb(
                        (int)redData[y, x],
                        (int)greenData[y, x],
                        (int)blueData[y, x]);
                }
            }

            Core.Image newImage = new(width, height);
            newImage.RawData = newRawData;

            return newImage;
        }

        public string GetName()
        {
            return "Detekce hran";
        }
    }
}
