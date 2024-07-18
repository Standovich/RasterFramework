using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.LowLevel
{
    internal class DrawLineBresenham : IDrawLine
    {
        Color colorToDraw = Color.FromArgb(0, 0, 255);
        public void Apply(Core.Image image, Point p0, Point p1)
        {
            Color[,] rawData = image.GetRawData();

            if (Math.Abs(p1.X - p0.X) > Math.Abs(p1.Y - p0.Y))
                DrawYLine(rawData, p0, p1);
            else if(Math.Abs(p1.X - p0.X) < Math.Abs(p1.Y - p0.Y))
                DrawXLine(rawData, p0, p1);
        }

        private void DrawYLine(Color[,] rawData, Point p0, Point p1)
        {
            int d = 1;

            if(p1.X < p0.X)
            {
                (p1.X, p0.X) = (p0.X, p1.X);
                (p1.Y, p0.Y) = (p0.Y, p1.Y);
            }

            int h1 = 2 * (p1.Y - p0.Y);
            int y = p0.Y;

            if (y > p1.Y)
            {
                d = -1;
                h1 = -h1;
            }

            int h2 = h1 - 2 * (p1.X - p0.X);
            int h = h1 - (p1.X - p0.X);

            for (int x = p0.X; x < p1.X; x++)
            {
                if (h > 0)
                {
                    h += h2;
                    y += d;
                }
                else h += h1;
                rawData[y, x] = colorToDraw;
            }
        }

        private void DrawXLine(Color[,] rawData, Point p0, Point p1)
        {
            int d = 1;

            if (p1.Y < p0.Y)
            {
                (p1.X, p0.X) = (p0.X, p1.X);
                (p1.Y, p0.Y) = (p0.Y, p1.Y);
            }

            int h1 = 2 * (p1.X - p0.X);
            int x = p0.X;

            if (x > p1.X)
            {
                d = -1;
                h1 = -h1;
            }

            int h2 = h1 - 2 * (p1.Y - p0.Y);
            int h = h1 - (p1.Y - p0.Y);

            for (int y = p0.Y; y < p1.Y; y++)
            {
                if (h > 0)
                {
                    h += h2;
                    x += d;
                }
                else h += h1;
                rawData[y, x] = colorToDraw;
            }
        }

        public string GetName()
        {
            return "Bresenham";
        }
    }
}
