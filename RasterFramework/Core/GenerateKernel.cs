using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Core
{
    internal class GenerateKernel
    {
        public static double[,] GetKernel(ConvolutionType type)
        {
            double[,] ret = null;
            switch (type)
            {
                case ConvolutionType.BoxBlur3x3:
                    ret = new double[,] {
                    {1, 1, 1},
                    {1, 1, 1},
                    {1, 1, 1} };
                    break;
                case ConvolutionType.BoxBlur5x5:
                    ret = new double[,] {
                    {1, 1, 1, 1, 1},
                    {1, 1, 1, 1, 1},
                    {1, 1, 1, 1, 1},
                    {1, 1, 1, 1, 1},
                    {1, 1, 1, 1, 1} };
                    break;
                case ConvolutionType.GaussBlur3x3:
                    ret = new double[,] {
                    {1, 2, 1},
                    {2, 4, 2},
                    {1, 2, 1} };
                    break;
                case ConvolutionType.GaussBlur5x5:
                    ret = new double[,] {
                    {1, 4, 6, 4, 1},
                    {4, 16, 24, 16, 4},
                    {6, 24, 36, 24, 6},
                    {4, 16, 24, 16, 4},
                    {1, 4, 6, 4, 1} };
                    break;
                case ConvolutionType.EdgeDetection:
                    ret = new double[,] {
                    {-1, -1, -1},
                    {0, 0, 0},
                    {1, 1, 1} };
                    break;
                case ConvolutionType.Sharpen:
                    ret = new double[,] {
                    { 0, -1,  0},
                    {-1,  5, -1},
                    { 0, -1,  0} };
                    break;
            }
            return ret;
        }
    }
}
