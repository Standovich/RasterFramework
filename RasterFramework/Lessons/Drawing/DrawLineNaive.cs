using RasterFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Lessons.Drawing
{
    internal class DrawLineNaive : IDrawLine
    {
        public void Apply(Core.Image image, Point p0, Point p1)
        {
            Color[,] rawData = image.RawData;
            Color colorToDraw = Color.FromArgb(255, 0, 0);

            if (p1.X < p0.X)
            {
                (p1.X, p0.X) = (p0.X, p1.X);
                (p1.Y, p0.Y) = (p0.Y, p1.Y);
            }

            int dx = p1.X - p0.X;
            int dy = p1.Y - p0.Y;

            for (int x = p0.X; x < p1.X; x++)
            {
                int y = p0.Y + dy * (x - p0.X) / dx;
                rawData[y, x] = colorToDraw;
            }
        }

        public string GetName()
        {
            return "Naive";
        }
    }
}
