using System.Drawing.Imaging;

namespace RasterFramework.Core
{
    internal class Image
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Color[,] RawData { get; set; }

        public Image(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.RawData = GetEmptyData(width, height);
        }

        public Image(Color[,] newRawData)
        {
            this.Width = newRawData.GetLength(1);
            this.Height = newRawData.GetLength(0);
            this.RawData = new Color[Height, Width];
            Array.Copy(newRawData, this.RawData, newRawData.Length);
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

        public Color[,] GetRawDataCopy()
        {
            Color[,] retRawData = new Color[Height, Width];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    retRawData[y, x] = RawData[y,x];
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

            newImage.RawData = rawData;

            return newImage;
        }

        public void SaveToFile(string fileName)
        {
            Bitmap imageToSave = new(Width, Height);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    imageToSave.SetPixel(x, y, RawData[y, x]);
                }
            }

            imageToSave.Save(fileName, ImageFormat.Png);
        }
    }
}
