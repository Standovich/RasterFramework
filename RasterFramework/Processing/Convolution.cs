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
        public double[,] kernel;

        private Convolution() { }
        public Convolution Create(ConvolutionType type, ConvolutionSize size)
        {
            Convolution ret = new();
            return ret;
        }

        public Core.Image Apply(Core.Image sourceImage)
        {
            throw new NotImplementedException();
        }

        public string GetFilterDescription()
        {
            throw new NotImplementedException();
        }
    }
}
