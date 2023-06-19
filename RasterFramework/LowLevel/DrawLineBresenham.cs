using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.LowLevel
{
    internal class DrawLineBresenham : ILowLevelGraphic
    {
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
            Color colorToDraw = Color.FromArgb(255, 0, 0);
            int d = 1;

            if(p1.X < p0.X)
            {
                int temp = p0.X;
                p0.X = p1.X;
                p1.X = temp;

                temp = p0.Y;
                p0.Y = p1.Y;
                p1.Y = temp;

                int h1 = 2 * (p1.Y - p0.Y);
                int y = p0.Y;

                if(y > p1.Y)
                {
                    d = -1;
                    h1 = -h1;
                }

                int h2 = h1 - 2 * (p1.X - p0.X);
                int h = h1 - (p1.X - p0.X);

                for(int i = p0.X; i < p1.X; i++)
                {
                    if (h > 0)
                    {
                        h += h2;
                        y += d;
                    }
                    else h += h1;
                    rawData[i, y] = colorToDraw;
                }
            }
            else
            {
                int h1 = 2 * (p1.Y - p0.Y);
                int y = p0.Y;

                if(p1.Y < p0.Y)
                {
                    d = -1;
                    h1 = -h1;
                }

                int h2 = h1 - 2 * (p1.X - p0.X);
                int h = h1 - (p1.X - p0.X);

                for (int i = p0.X; i < p1.X; i++)
                {
                    if(h > 0)
                    {
                        h += h2;
                        y += d;
                    }
                    else h += h1;
                    rawData[i, y] = colorToDraw;
                }
            }
        }

        private void DrawXLine(Color[,] rawData, Point p0, Point p1)
        {
            Color colorToDraw = Color.FromArgb(255, 0, 0);
            int d = 1;

            if (p1.Y < p0.Y)
            {
                int temp = p0.Y;
                p0.Y = p1.Y;
                p1.Y = temp;

                temp = p0.X;
                p0.X = p1.X;
                p1.X = temp;

                int h1 = 2 * (p1.X - p0.X);
                int x = p0.X;

                if (x > p1.X)
                {
                    d = -1;
                    h1 = -h1;
                }

                int h2 = h1 - 2 * (p1.Y - p0.Y);
                int h = h1 - (p1.Y - p0.Y);

                for (int i = p0.Y; i < p1.Y; i++)
                {
                    if (h > 0)
                    {
                        h += h2;
                        x += d;
                    }
                    else h += h1;
                    rawData[x, i] = colorToDraw;
                }
            }
            else
            {
                int h1 = 2 * (p1.X - p0.X);
                int x = p0.X;

                if (p1.Y < p0.Y)
                {
                    d = -1;
                    h1 = -h1;
                }

                int h2 = h1 - 2 * (p1.Y - p0.Y);
                int h = h1 - (p1.Y - p0.Y);

                for (int i = p0.Y; i < p1.Y; i++)
                {
                    if (h > 0)
                    {
                        h += h2;
                        x += d;
                    }
                    else h += h1;
                    rawData[x, i] = colorToDraw;
                }
            }
        }
    }
}
