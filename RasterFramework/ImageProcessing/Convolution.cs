using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.ImageProcessing
{
    internal class Convolution
    {
        public static List<ConvMethod> InitializeMethods()
        {
            List<ConvMethod> methods = new List<ConvMethod>();

            methods.Add(new("Box blur (3x3)", new int[,] {
                { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 }
            }, true));
            methods.Add(new("Box blur (5x5)", new int[,] {
                { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }
            }, true));
            methods.Add(new("Gaussian blur (3x3)", new int[,] {
                { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 }
            }, true));
            methods.Add(new("Gaussian blur (5x5)", new int[,] {
                { 1, 4, 6, 4, 1 }, { 4, 16, 24, 16, 4 }, { 6, 24, 36, 24, 6 },
                { 4, 16, 24, 16, 4 }, { 1, 4, 6, 4, 1 }
            }, true));
            methods.Add(new("Sharpen (3x3)", new int[,] {
                { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 }
            }, false));

            return methods;
        }

        public static Color[,] ApplyConvolution(bool divide, int threshold, int[,] kernel, Color[,] sourceImage)
        {
            double[,] redData = new double[sourceImage.GetLength(0), sourceImage.GetLength(1)];
            double[,] greenData = new double[sourceImage.GetLength(0), sourceImage.GetLength(1)];
            double[,] blueData = new double[sourceImage.GetLength(0), sourceImage.GetLength(1)];
            Color[,] newImage = new Color[sourceImage.GetLength(0), sourceImage.GetLength(1)];
            int distance = kernel.GetLength(0) / 2;

            if (divide)
            {
                //vnitřní pixely
                int divisor = 0;
                for (int y = distance; y < sourceImage.GetLength(0) - distance; y++)
                {
                    for (int x = distance; x < sourceImage.GetLength(1) - distance; x++)
                    {
                        for (int ky = 0; ky < kernel.GetLength(0); ky++)
                        {
                            for (int kx = 0; kx < kernel.GetLength(0); kx++)
                            {
                                redData[y, x] += sourceImage[y + ky - distance, x + kx - distance].R * kernel[ky,kx];
                                greenData[y, x] += sourceImage[y + ky - distance, x + kx - distance].G * kernel[ky, kx];
                                blueData[y, x] += sourceImage[y + ky - distance, x + kx - distance].B * kernel[ky, kx];
                                divisor += kernel[ky,kx];
                            }
                        }

                        redData[y, x] /= divisor;
                        greenData[y, x] /= divisor;
                        blueData[y, x] /= divisor;
                        divisor = 0;
                    }
                }

                //naplnit novou bitmapu
                for (int y = 0; y < newImage.GetLength(0); y++)
                {
                    for (int x = 0; x < newImage.GetLength(1); x++)
                    {
                        newImage[y, x] = Color.FromArgb(
                            (int)redData[y,x], 
                            (int)greenData[y,x], 
                            (int)blueData[y,x]);
                    }
                }

                //kontrola prahu
                for (int y = 0; y < sourceImage.GetLength(0); y++)
                {
                    for (int x = 0; x < sourceImage.GetLength(1); x++)
                    {
                        double difference = Math.Abs(
                            GrayscaleConvertor.RGBtoGray(newImage[y, x]) - 
                            GrayscaleConvertor.RGBtoGray(sourceImage[y, x]));
                        if (difference >= threshold)
                            newImage[y, x] = sourceImage[y, x];
                    }
                }

                return newImage;
            }
            else
            {
                //vnitřní pixely
                for (int y = distance; y < sourceImage.GetLength(0) - distance; y++)
                {
                    for (int x = distance; x < sourceImage.GetLength(1) - distance; x++)
                    {
                        for (int ky = 0; ky < kernel.GetLength(0); ky++)
                        {
                            for (int kx = 0; kx < kernel.GetLength(0); kx++)
                            {
                                redData[y, x] += sourceImage[y + ky - distance, x + kx - distance].R * kernel[ky, kx];
                                greenData[y, x] += sourceImage[y + ky - distance, x + kx - distance].G * kernel[ky, kx];
                                blueData[y, x] += sourceImage[y + ky - distance, x + kx - distance].B * kernel[ky, kx];
                            }
                        }
                    }
                }

                //naplnit novou bitmapu
                for (int y = 0; y < newImage.GetLength(0); y++)
                {
                    for (int x = 0; x < newImage.GetLength(1); x++)
                    {
                        if ((redData[y,x] > 255) || (redData[y,x] < 0)) 
                            redData[y,x] = sourceImage[y, x].R;
                        if ((greenData[y, x] > 255) || (greenData[y, x] < 0))
                            greenData[y, x] = sourceImage[y, x].G;
                        if ((blueData[y,x] > 255) || (blueData[y,x] < 0))
                            blueData[y,x] = sourceImage[y, x].B;

                        newImage[y, x] = Color.FromArgb(
                            (int)redData[y, x],
                            (int)greenData[y, x],
                            (int)blueData[y, x]);
                    }
                }

                //kontrola prahu
                for (int y = 0; y < sourceImage.GetLength(0); y++)
                {
                    for (int x = 0; x < sourceImage.GetLength(1); x++)
                    {
                        double difference = Math.Abs(
                            GrayscaleConvertor.RGBtoGray(newImage[y, x]) -
                            GrayscaleConvertor.RGBtoGray(sourceImage[y, x]));
                        if (difference > threshold)
                            newImage[y, x] = sourceImage[y, x];
                    }
                }

                return newImage;
            }
        }
    }
}
