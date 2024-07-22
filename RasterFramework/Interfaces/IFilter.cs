using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RasterFramework.Core;
using Image = RasterFramework.Core.Image;

namespace RasterFramework.Interfaces
{
    internal interface IFilter
    {
        Image Apply(Image sourceImage);
        string GetName();
    }
}
