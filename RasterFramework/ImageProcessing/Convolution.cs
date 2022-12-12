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
        public static ImageBitmap ChooseConvolution(bool edge, int threshold, ConvMethod method, ImageBitmap sourceImage)
        {
            return ApplyConvolution(edge, method.Divide, threshold, method.Kernel, sourceImage.GetCopy());
        }

        private static ImageBitmap ApplyConvolution(bool edge, bool divide, int threshold, int[,] kernel, ImageBitmap sourceImage)
        {
            double[,] redData = new double[sourceImage.GetWidth(), sourceImage.GetHeight()];
            double[,] greenData = new double[sourceImage.GetWidth(), sourceImage.GetHeight()];
            double[,] blueData = new double[sourceImage.GetWidth(), sourceImage.GetHeight()];
            ImageBitmap newImage = new(sourceImage.GetWidth(), sourceImage.GetHeight());
            int distance = kernel.GetLength(0) / 2;

            if (divide)
            {
                //vnitřní pixely
                int divisor = 0;
                for (int y = distance; y < sourceImage.GetWidth() - distance; y++)
                {
                    for (int x = distance; x < sourceImage.GetHeight() - distance; x++)
                    {
                        for (int ky = 0; ky < kernel.GetLength(0); ky++)
                        {
                            for (int kx = 0; kx < kernel.GetLength(0); kx++)
                            {
                                redData[y, x] += sourceImage.GetPixel(y + ky - distance, x + kx - distance).R * kernel[ky,kx];
                                greenData[y, x] += sourceImage.GetPixel(y + ky - distance, x + kx - distance).G * kernel[ky, kx];
                                blueData[y, x] += sourceImage.GetPixel(y + ky - distance, x + kx - distance).B * kernel[ky, kx];
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
                for (int y = distance; y < sourceImage.GetWidth() - distance; y++)
                {
                    for (int x = distance; x < sourceImage.GetHeight() - distance; x++)
                    {
                        for (int ky = 0; ky < kernel.GetLength(0); ky++)
                        {
                            for (int kx = 0; kx < kernel.GetLength(0); kx++)
                            {
                                redData[y, x] += sourceImage.GetPixel(y + ky - distance, x + kx - distance).R * kernel[ky, kx];
                                greenData[y, x] += sourceImage.GetPixel(y + ky - distance, x + kx - distance).G * kernel[ky, kx];
                                blueData[y, x] += sourceImage.GetPixel(y + ky - distance, x + kx - distance).B * kernel[ky, kx];
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
