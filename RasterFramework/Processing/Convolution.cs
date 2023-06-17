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
        public Convolution() { }
        public static Convolution Create(ConvolutionType type, ConvolutionSize size)
        {
            Convolution ret = new();
            switch (type)
            {
                case ConvolutionType.GaussBlur:
                    switch (size)
                    {
                        case ConvolutionSize.S_3:
                            ret = new Blur(new double[,] { {1, 2, 1}, {2, 4, 2}, {1, 2, 1} });
                            break;
                        case ConvolutionSize.S_5:
                            ret = new Blur(new double[,] { {1, 4, 6, 4, 1}, {4, 16, 24, 16, 4}, 
                                {6, 24, 36, 24, 6}, {4, 16, 24, 16, 4}, {1, 4, 6, 4, 1} });
                            break;
                        case ConvolutionSize.S_7:
                            ret = new Blur(new double[,] { {1, 4, 6, 8, 6, 4, 1},
                                {4, 16, 24, 32, 24, 16, 4}, {6, 24, 36, 48, 36, 24, 6},
                                {8, 32, 48, 64, 48, 32, 8}, {6, 24, 36, 48, 36, 24, 6},
                                {4, 16, 24, 32, 24, 16, 4}, {1, 4, 6, 8, 6, 4, 1} });
                            break;
                        case ConvolutionSize.S_9:
                            ret = new Blur(new double[,] { {1, 4, 6, 8, 10, 8, 6, 4, 1},
                            {4, 16, 24, 32, 40, 32, 24, 16, 4}, {6, 24, 36, 48, 60, 48, 36, 24, 6},
                            {8, 32, 48, 64, 80, 64, 48, 32, 8}, {10, 40, 60, 80, 100, 80, 60, 40, 10},
                            {8, 32, 48, 64, 80, 64, 48, 32, 8}, {6, 24, 36, 48, 60, 48, 36, 24, 6},
                            {4, 16, 24, 32, 40, 32, 24, 16, 4}, {1, 4, 6, 8, 10, 8, 6, 4, 1} });
                            break;
                    }
                    break;
                case ConvolutionType.BoxBlur:
                    switch (size)
                    {
                        case ConvolutionSize.S_3:
                            ret = new Blur(new double[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } });
                            break;
                        case ConvolutionSize.S_5:
                            ret = new Blur(new double[,] { { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 },
                                { 1, 1, 1, 1, 1 }, {1, 1, 1, 1, 1}, {1, 1, 1, 1, 1} });
                            break;
                        case ConvolutionSize.S_7:
                            ret = new Blur(new double[,] { {1, 1, 1, 1, 1, 1, 1},
                                { 1, 1, 1, 1, 1, 1, 1 }, {1, 1, 1, 1, 1, 1, 1},
                                { 1, 1, 1, 1, 1, 1, 1 }, {1, 1, 1, 1, 1, 1, 1},
                                {1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1} });
                            break;
                        case ConvolutionSize.S_9:
                            ret = new Blur(new double[,] { {1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1, 1} });
                            break;
                    }
                    break;
                case ConvolutionType.Sharpen:
                    switch (size)
                    {
                        case ConvolutionSize.S_3:
                            ret = new Sharpen(new double[,] { {0, -1, 0}, {-1, 5, -1}, {0, -1, 0} });
                            break;
                        case ConvolutionSize.S_5:
                            ret = new Sharpen(new double[,] { {0, 0, -1, 0, 0}, {0, -1, -1, -1, 0},
                                {-1, -1, 13, -1, -1}, {0, -1, -1, -1, 0}, {0, 0, -1, 0, 0} });
                            break;
                        case ConvolutionSize.S_7:
                            ret = new Sharpen(new double[,] { {0, 0, 0, -1, 0, 0, 0},
                                {0, 0, -1, -1, -1, 0, 0}, {0, -1, -1, -1, -1, -1, 0}, 
                                {-1, -1, -1, 25, -1, -1, -1}, {0, -1, -1, -1, -1, -1, 0}, 
                                {0, 0, -1, -1, -1, 0, 0}, {0, 0, 0, -1, 0, 0, 0} });
                            break;
                        case ConvolutionSize.S_9:
                            ret = new Sharpen(new double[,] { {0, 0, 0, 0, -1, 0, 0, 0, 0},
                            {0, 0, 0, -1, -1, -1, 0, 0, 0}, {0, 0, -1, -1, -1, -1, -1, 0, 0},
                            {0, -1, -1, -1, -1, -1, -1, -1, 0}, {-1, -1, -1, -1, 41, -1, -1, -1, -1}, 
                            {0, -1, -1, -1, -1, -1, -1, -1, 0}, {0, 0, -1, -1, -1, -1, -1, 0, 0},
                            {0, 0, 0, -1, -1, -1, 0, 0, 0}, {0, 0, 0, 0, -1, 0, 0, 0, 0} });
                            break;
                    }
                    break;
            }

            return ret;
        }

        public virtual Core.Image Apply(Core.Image sourceImage)
        {
            throw new NotImplementedException();
        }

        public string GetFilterDescription()
        {
            throw new NotImplementedException();
        }
    }
}
