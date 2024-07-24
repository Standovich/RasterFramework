using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Core
{
    internal class Renderer
    {
        public Bitmap DrawImage(Color[,] rawData)
        {
            if (rawData != null)
            {
                int width = rawData.GetLength(1);
                int height = rawData.GetLength(0);

                Bitmap imageToDraw = new(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        imageToDraw.SetPixel(x, y, rawData[y, x]);
                    }
                }

                return imageToDraw;
            }
            else
            {
                MessageBox.Show("Obdržená matice pixelů je typu null!" +
                    "Algoritmus odpovědný za poskytnutou pole nepracuje správně",
                    "Nastala chyba!");
                return new Bitmap(0, 0);
            }
        }

        public Color[,] ResizeImage(Color[,] rawData, int imageHeight, int imageWidth, int imageScale)
        {
            //int height = imageHeight;
            //int width = imageWidth;

            int scale = imageScale;

            int newHeight = imageHeight * scale;
            int newWidht = imageWidth * scale;
            Color[,] newRawData = new Color[newHeight, newWidht];

            int startX = 0; int startY = 0;

            for (int y1 = 0; y1 < imageHeight; y1++)
            {
                for (int x1 = 0; x1 < imageWidth; x1++)
                {
                    Color colorToCopy = rawData[y1, x1];
                    for (int y2 = startY; y2 < (startY + imageScale); y2++)
                    {
                        for (int x2 = startX; x2 < (startX + imageScale); x2++)
                        {
                            newRawData[y2, x2] = colorToCopy;
                        }
                    }

                    startX += imageScale;
                }

                startX = 0;
                startY += imageScale;
            }

            return newRawData;
        }
    }
}
