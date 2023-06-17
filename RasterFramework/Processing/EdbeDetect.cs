using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Processing
{
    internal class EdbeDetect : Convolution
    {
        public double[,] kernel;
        public EdbeDetect(double[,] kernel)
        {
            this.kernel = kernel;
        }

        public override Core.Image Apply(Core.Image sourceImage)
        {
            return null;
        }
    }
}
