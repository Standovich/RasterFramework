using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Core
{
    internal interface IDrawLine
    {
        void Apply(Image image, Point p0, Point p1);
    }
}
