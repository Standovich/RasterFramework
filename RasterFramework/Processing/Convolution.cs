using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Processing
{
    internal class Convolution : IFilter
    {
        public ConvolutionType convType;
        public ConvolutionSize convSize;
        public int[,] kernel;

        public Convolution() { }
        public static Convolution Create(ConvolutionType type, ConvolutionSize size)
        {
            Convolution ret = new();
            ret.convType = type;
            ret.convSize = size;

            int[,] kernel = { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };
            ret.kernel = kernel;

            return ret;
        }

        public Core.Image Apply(Core.Image sourceImage)
        {
            int width = sourceImage.GetWidth();
            int height = sourceImage.GetHeight();
            Color[,] sourceRawData = sourceImage.GetRawData();
            Color[,] newRawData = new Color[width, height];

            double[,] redData = new double[width, height];
            double[,] greenData = new double[width, height];
            double[,] blueData = new double[width, height];
            int distance = kernel.GetLength(0) / 2;

            int threshold = 10;

            //vnitřní pixely
            int divisor = 0;
            for (int x = distance; x < width - distance; x++)
            {
                for (int y = distance; y < height - distance; y++)
                {
                    for (int kx = 0; kx < kernel.GetLength(0); kx++)
                    {
                        for (int ky = 0; ky < kernel.GetLength(0); ky++)
                        {
                            redData[x, y] += sourceRawData[x + kx - distance, y + ky - distance].R * kernel[kx, ky];
                            greenData[x, y] += sourceRawData[x + kx - distance, y + ky - distance].G * kernel[kx, ky];
                            blueData[x, y] += sourceRawData[x + kx - distance, y + ky - distance].B * kernel[kx, ky];
                            divisor += kernel[kx, ky];
                        }
                    }

                    redData[x, y] /= divisor;
                    greenData[x, y] /= divisor;
                    blueData[x, y] /= divisor;
                    divisor = 0;
                }
            }

            //naplnit novou bitmapu
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    newRawData[x, y] = Color.FromArgb(
                        (int)redData[x, y],
                        (int)greenData[x, y],
                        (int)blueData[x, y]);
                }
            }

            //kontrola prahu
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double difference = Math.Abs(
                        ToGray(newRawData[x, y]) -
                        ToGray(sourceRawData[x, y]));
                    if (difference >= threshold)
                        newRawData[x, y] = sourceRawData[x, y];
                }
            }

            Core.Image newImage = new(width, height);
            newImage.SetRawData(newRawData);

            return newImage;
        }

        private double ToGray(Color color)
        {
            int r = color.R;
            int g = color.G;
            int b = color.B;
            return (r * 0.299) + (g * 0.587) + (b * 0.114);
        }

        public string GetFilterDescription()
        {
            throw new NotImplementedException();
        }
    }
}
