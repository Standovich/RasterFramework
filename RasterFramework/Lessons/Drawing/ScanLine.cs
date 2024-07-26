using RasterFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Lessons.Drawing
{
    internal class ScanLine : IDrawFill
    {
        IDrawLine line = new DrawLineNaive();
        public void Apply(Core.Image image)
        {
            Color[,] rawData = image.RawData;
            int widht = image.Width;
            int height = image.Height;

            bool fill = false;
            Point p0 = new(); Point p1 = new();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < widht; x++)
                {
                    if (rawData[y, x] != Color.FromArgb(0, 0, 0))
                    {
                        if (!fill)
                        {
                            p0 = new Point(x, y);
                            fill = true;
                        }
                        else
                        {
                            p1 = new Point(x, y);
                            line.Apply(image, p0, p1);
                            break;
                        }
                    }
                }
                fill = false;
            }
        }

        public string GetName()
        {
            return "Scan-Line";
        }
    }
}
