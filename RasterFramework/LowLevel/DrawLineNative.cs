using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.LowLevel
{
    internal class DrawLineNative : ILowLevelGraphic
    {
        public void Apply(Core.Image image, Point a, Point b)
        {
            Color[,] rawData = image.GetRawData();
        }
    }
}
