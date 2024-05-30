using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Processing
{
    internal class Blur : Convolution
    {
        public double[,] kernel;
        public Blur(double[,] kernel)
        {
            this.kernel = kernel;
        }

        public new Core.Image Apply(Core.Image sourceImage)
        {
            int width = sourceImage.GetWidth();
            int height = sourceImage.GetHeight();
            Color[,] sourceRawData = sourceImage.GetRawData();
            Color[,] newRawData = new Color[height, width];

            double[,] redData = new double[height, width];
            double[,] greenData = new double[height, width];
            double[,] blueData = new double[height, width];
            int distance = kernel.GetLength(0) / 2;

            //vnitřní pixely
            double divisor = 0;
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
                            divisor += kernel[ky, kx];
                        }
                    }

                    redData[y, x] /= divisor;
                    greenData[y, x] /= divisor;
                    blueData[y, x] /= divisor;
                    divisor = 0;
                }
            }

            //naplnit novou bitmapu
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    newRawData[y, x] = Color.FromArgb(
                        (int)redData[y, x],
                        (int)greenData[y, x],
                        (int)blueData[y, x]);
                }
            }

            Core.Image newImage = new(width, height);
            newImage.SetRawData(newRawData);

            return newImage;
        }
    }
}
