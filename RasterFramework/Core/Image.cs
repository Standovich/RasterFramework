using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Core
{
    internal class Image
    {
        private int width;
        private int height;
        private Color[,] rawData;

        public Image(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.rawData = GetEmptyData(width, height);
        }

        public void SetRawData(Color[,] rawData)
        {
            this.rawData = rawData;
        }

        public Color[,] GetRawData()
        {
            return this.rawData;
        }

        public int GetWidth()
        {
            return this.width;
        }

        public int GetHeight()
        {
            return this.height;
        }

        public static Color[,] GetEmptyData(int width, int height)
        {
            Color[,] retRawData = new Color[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    retRawData[y, x] = Color.FromArgb(0, 0, 0);
                }
            }
            return retRawData;
        } 

        public static Image LoadFromFile(string fileName)
        {
            Bitmap imageToLoad = new Bitmap(fileName);

            Image newImage = new(imageToLoad.Width, imageToLoad.Height);
            Color[,] rawData = new Color[imageToLoad.Height, imageToLoad.Width];

            for (int y = 0; y < imageToLoad.Height; y++)
            {
                for (int x = 0; x < imageToLoad.Width; x++)
                {
                    rawData[y, x] = imageToLoad.GetPixel(x, y);
                }
            }

            newImage.SetRawData(rawData);

            return newImage;
        }

        public void SaveToFile(string fileName)
        {
            Bitmap imageToSave = new(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    imageToSave.SetPixel(y, x, rawData[y, x]);
                }
            }

            imageToSave.Save(fileName, ImageFormat.Png);
        }
    }
}
