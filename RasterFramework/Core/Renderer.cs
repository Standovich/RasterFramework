using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Core
{
    internal class Renderer
    {
        public void DrawImage(Color[,] rawData, PictureBox pictureBox)
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

                pictureBox.Image = imageToDraw;
            }
            else
            {
                MessageBox.Show("Obdržená matice pixelů je typu null!\n" +
                    "Algoritmus odpovědný za poskytnuté pole nepracuje správně!",
                    "Nastala chyba!");
                pictureBox.Image = new Bitmap(10, 10);
            }
        }

        public Color[,] ResizeImage(Color[,] rawData, int scale)
        {
            int height = rawData.GetLength(0);
            int width = rawData.GetLength(1);

            int newHeight = height * scale;
            int newWidht = width * scale;
            Color[,] newRawData = new Color[newHeight, newWidht];

            int startX = 0; int startY = 0;

            for (int y1 = 0; y1 < height; y1++)
            {
                for (int x1 = 0; x1 < width; x1++)
                {
                    Color colorToCopy = rawData[y1, x1];
                    for (int y2 = startY; y2 < (startY + scale); y2++)
                    {
                        for (int x2 = startX; x2 < (startX + scale); x2++)
                        {
                            newRawData[y2, x2] = colorToCopy;
                        }
                    }

                    startX += scale;
                }

                startX = 0;
                startY += scale;
            }

            return newRawData;
        }

        public Color[,] RedrawCanvas(Image image, Size newSize)
        {
            if (newSize.Width > image.Width)
            {
                return ScaleUp(image, newSize);
            }
            else if (newSize.Width < image.Width)
            {
                return ScaleDown(image, newSize);
            }
            else return null;
        }

        private Color[,] ScaleUp(Image image,Size newSize)
        {
            Color[,] currentRawData = image.RawData;
            Color[,] newRawData = new Color[newSize.Height, newSize.Width];

            int currentWidth = image.Width;
            int currentHeight = image.Height;

            for (int y = 0; y < currentHeight; y++)
            {
                for (int x = 0; x < currentWidth; x++)
                {
                    newRawData[y, x] = currentRawData[y, x];
                }
            }

            for (int y = 0; y < currentHeight; y++)
            {
                for (int x = currentWidth; x < newSize.Width; x++)
                {
                    newRawData[y, x] = Color.FromArgb(0, 0, 0);
                }
            }

            for (int y = currentHeight; y < newSize.Height; y++)
            {
                for (int x = 0; x < newSize.Width; x++)
                {
                    newRawData[y, x] = Color.FromArgb(0, 0, 0);
                }
            }

            return newRawData;
        }

        private Color[,] ScaleDown(Image image, Size newSize)
        {
            Color[,] currentRawData = image.RawData;
            Color[,] newRawData = new Color[newSize.Height, newSize.Width];

            for (int y = 0; y < newSize.Height; y++)
            {
                for (int x = 0; x < newSize.Width; x++)
                {
                    newRawData[y, x] = currentRawData[y, x];
                }
            }

            return newRawData;
        }
    }
}
