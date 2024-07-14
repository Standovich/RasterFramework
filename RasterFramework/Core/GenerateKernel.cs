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
                case ConvolutionType.GaussBlur3x3:
                    ret = new double[,] {
                    {1, 2, 1},
                    {2, 4, 2},
                    {1, 2, 1} };
                    break;
                case ConvolutionType.EdgeDetection:
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
