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
            this.rawData = new Color[width, height];
        }

        public void SetRawData(Color[,] rawData)
        {
            this.rawData = rawData;
        }

        public Color[,] GetRawData()
        {
            return this.rawData;
        }

        public Image LoadFromFile(string fileName)
        {
            Bitmap imageToLoad = new Bitmap(fileName);

            Image newImage = new(imageToLoad.Width, imageToLoad.Height);
            Color[,] rawData = new Color[imageToLoad.Width, imageToLoad.Height];

            for (int x = 0; x < imageToLoad.Width; x++)
            {
                for (int y = 0; y < imageToLoad.Height; y++)
                {
                    rawData[x,y] = imageToLoad.GetPixel(x, y);
                }
            }

            newImage.SetRawData(rawData);

            return newImage;
        }

        public void SaveToFile(string fileName)
        {
            Bitmap imageToSave = new(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    imageToSave.SetPixel(x, y, rawData[x, y]);
                }
            }

            imageToSave.Save(fileName, ImageFormat.Png);
        }
    }
}
