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
        public static ImageBitmap ChooseConvolution(bool edge, int threshold, int methodIndex, ImageBitmap sourceImage)
        {
            switch (methodIndex)
            {
                case 0:
                    int[,] kernelGau = new int[,] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };
                    return ApplyConvolution(edge, true, threshold, kernelGau, sourceImage.GetCopy());
                case 1:
                    int[,] kernelBox = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
                    return ApplyConvolution(edge, true, threshold, kernelBox, sourceImage.GetCopy());
                case 2:
                    int[,] kernelSharp = new int[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
                    return ApplyConvolution(edge, false, threshold, kernelSharp, sourceImage.GetCopy());
                default:
                    return sourceImage;
            }
        }

        private static ImageBitmap ApplyConvolution(bool edge, bool divide, int threshold, int[,] kernel, ImageBitmap sourceImage)
        {
            double[,] redData = new double[sourceImage.GetWidth(), sourceImage.GetHeight()];
            double[,] greenData = new double[sourceImage.GetWidth(), sourceImage.GetHeight()];
            double[,] blueData = new double[sourceImage.GetWidth(), sourceImage.GetHeight()];
            ImageBitmap newImage = new(sourceImage.GetWidth(), sourceImage.GetHeight());

            if (divide)
            {
                //vnitřní pixely
                int divisor = 0;
                for (int y = 1; y < sourceImage.GetWidth() - 1; y++)
                {
                    for (int x = 1; x < sourceImage.GetHeight() - 1; x++)
                    {
                        for (int ky = 0; ky < 3; ky++)
                        {
                            for (int kx = 0; kx < 3; kx++)
                            {
                                redData[y, x] += sourceImage.GetPixel(y + ky - 1, x + kx - 1).R * kernel[ky,kx];
                                greenData[y, x] += sourceImage.GetPixel(y + ky - 1, x + kx - 1).G * kernel[ky, kx];
                                blueData[y, x] += sourceImage.GetPixel(y + ky - 1, x + kx - 1).B * kernel[ky, kx];
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
                for (int y = 0; y < newImage.GetWidth(); y++)
                {
                    for (int x = 0; x < newImage.GetHeight(); x++)
                    {
                        newImage.SetPixel(y, x, Color.FromArgb((int)redData[y,x], 
                            (int)greenData[y,x], 
                            (int)blueData[y,x]));
                    }
                }

                //kontrola prahu
                for (int y = 0; y < sourceImage.GetWidth(); y++)
                {
                    for (int x = 0; x < sourceImage.GetHeight(); x++)
                    {
                        double difference = Math.Abs(
                            GrayscaleConvertor.RGBtoGray(newImage.GetPixel(y, x)) - 
                            GrayscaleConvertor.RGBtoGray(sourceImage.GetPixel(y, x)));
                        if (difference >= threshold) 
                            newImage.SetPixel(y, x, sourceImage.GetPixel(y, x));
                    }
                }

                return newImage;
            }
            else
            {
                //vnitřní pixely
                for (int y = 1; y < sourceImage.GetWidth() - 1; y++)
                {
                    for (int x = 1; x < sourceImage.GetHeight() - 1; x++)
                    {
                        for (int ky = 0; ky < 3; ky++)
                        {
                            for (int kx = 0; kx < 3; kx++)
                            {
                                redData[y, x] += sourceImage.GetPixel(y + ky - 1, x + kx - 1).R * kernel[ky, kx];
                                greenData[y, x] += sourceImage.GetPixel(y + ky - 1, x + kx - 1).G * kernel[ky, kx];
                                blueData[y, x] += sourceImage.GetPixel(y + ky - 1, x + kx - 1).B * kernel[ky, kx];
                            }
                        }
                    }
                }

                //naplnit novou bitmapu
                for (int y = 0; y < newImage.GetWidth(); y++)
                {
                    for (int x = 0; x < newImage.GetHeight(); x++)
                    {
                        if ((redData[y,x] > 255) || (redData[y,x] < 0)) 
                            redData[y,x] = sourceImage.GetPixel(y,x).R;
                        if ((greenData[y, x] > 255) || (greenData[y, x] < 0))
                            greenData[y, x] = sourceImage.GetPixel(y, x).G;
                        if ((blueData[y,x] > 255) || (blueData[y,x] < 0))
                            blueData[y,x] = sourceImage.GetPixel(y, x).B;

                        newImage.SetPixel(y, x, Color.FromArgb((int)redData[y, x],
                            (int)greenData[y, x],
                            (int)blueData[y, x]));
                    }
                }

                //kontrola prahu
                for (int y = 0; y < sourceImage.GetWidth(); y++)
                {
                    for (int x = 0; x < sourceImage.GetHeight(); x++)
                    {
                        double difference = Math.Abs(
                            GrayscaleConvertor.RGBtoGray(newImage.GetPixel(y, x)) -
                            GrayscaleConvertor.RGBtoGray(sourceImage.GetPixel(y, x)));
                        if (difference > threshold)
                            newImage.SetPixel(y, x, sourceImage.GetPixel(y, x));
                    }
                }

                return newImage;
            }
        }
    }
}
