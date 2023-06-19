using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.LowLevel
{
    internal class DrawLineNaive : ILowLevelGraphic
    {
        public void Apply(Core.Image image, Point p1, Point p2)
        {
            Color[,] rawData = image.GetRawData();
        }
    }
}
