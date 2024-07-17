using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.LowLevel
{
    internal class DrawCubic : IDrawCurve
    {
        private IDrawLine drawLine = new DrawLineDDA();
        public void Apply(Core.Image image, Point[] points)
        {
            double d = 0.01;
            int x1 = points[0].X, y1 = points[0].Y;
            int qx1 = points[0].X, qx2 = 3 * (points[1].X - points[0].X), 
                qx3 = 3 * (points[2].X - 2 * points[1].X + points[0].X), 
                qx4 = points[3].X - 3 * points[2].X + 3 * points[1].X - points[0].X;
            int qy1 = points[0].Y, qy2 = 3 * (points[1].Y - points[0].Y), 
                qy3 = 3 * (points[2].Y - 2 * points[1].Y + points[0].Y), 
                qy4 = points[3].Y - 3 * points[2].Y + 3 * points[1].Y - points[0].Y;
            for (double i = 0; i <= 1; i += d)
            {
                double i2 = i * i;
                double i3 = i2 * i;
                double x2 = qx1 + qx2 * i + qx3 * i2 + qx4 * i3;
                double y2 = qy1 + qy2 * i + qy3 * i2 + qy4 * i3;
                drawLine.Apply(image, new(x1, y1), new((int)x2, (int)y2));
                x1 = (int)x2;
                y1 = (int)y2;
            }
        }
    }
}
