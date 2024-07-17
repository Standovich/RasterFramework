using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Core
{
    internal interface IDrawCurve
    {
        void Apply(Image image, Point[] points);
    }
}
