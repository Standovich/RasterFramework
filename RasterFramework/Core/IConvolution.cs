using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Core
{
    internal interface IConvolution
    {
        Image Apply(Image sourceImage, double[,] kernel);
        string GetName();
    }
}
