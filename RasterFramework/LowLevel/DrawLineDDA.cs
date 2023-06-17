using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.LowLevel
{
    internal class DrawLineDDA : ILowLevelGraphic
    {
        public void Apply(Core.Image image, Point a, Point b)
        {
            Color[,] rawData = image.GetRawData();
            rawData[0,0] = Color.FromArgb(255,0,0);
        }
    }
}
