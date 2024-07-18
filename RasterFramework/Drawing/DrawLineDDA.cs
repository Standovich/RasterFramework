using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.LowLevel
{
    internal class DrawLineDDA : IDrawLine
    {
        public void Apply(Core.Image image, Point p0, Point p1)
        {
            Color[,] rawData = image.GetRawData();
            Color colorToDraw = Color.FromArgb(255, 255, 0);

            int dx = p1.X - p0.X;
            int dy = p1.Y - p0.Y;

            int step;
            if (Math.Abs(dx) > Math.Abs(dy)) step = Math.Abs(dx);
            else step = Math.Abs(dy);

            double incrementX = (double)dx / (double)step, incrementY = (double)dy / (double)step;
            double x = p0.X, y = p0.Y;

            for (int i = 0; i < step; i++)
            {
                rawData[(int)y, (int)x] = colorToDraw;
                x += incrementX;
                y += incrementY;
            }
        }

        public string GetName()
        {
            return "DDA";
        }
    }
}
