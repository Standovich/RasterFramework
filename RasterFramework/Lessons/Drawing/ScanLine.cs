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

            bool start = false;
            bool end = false;
            Point p0 = new(); Point p1 = new();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < widht; x++)
                {
                    if (rawData[y, x] != Color.FromArgb(0, 0, 0))
                    {
                        if (!start)
                        {
                            p0 = new(x, y);
                            start = true;
                        }
                        else
                        {
                            p1 = new(x, y);
                            start = false;
                            end = true;
                        }
                    }
                }
                if(end) line.Apply(image, p0, p1);
                start = false; end = false;
            }
        }

        public string GetName()
        {
            return "Scan-Line";
        }
    }
}
