using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Core
{
    internal enum ConvolutionType
    {
        BoxBlur3x3,
        GaussBlur3x3,
        GaussBlur5x5,
        EdgeDetection,
        Sharpen
    }
}
