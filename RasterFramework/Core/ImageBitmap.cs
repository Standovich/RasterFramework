using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFramework.Core
{
    internal class ImageBitmap
    {
        private readonly int Width;
        private readonly int Height;
        private readonly Bitmap ?SourceImage;
        private Color[,] ?RawData;

        public ImageBitmap(ImageBitmap imageBitmap)
        {
            Width = imageBitmap.GetWidth();
            Height = imageBitmap.GetHeight();
            RawData = imageBitmap.GetRawData();
        }
        public ImageBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            SetRawData(null);
        }

        public ImageBitmap(Bitmap sourceImage)
        {
            Width = sourceImage.Width;
            Height = sourceImage.Height;
            SourceImage = sourceImage;
            SetRawData(sourceImage);
        }

        public int GetWidth() { return Width; }
        public int GetHeight() { return Height; }
        public ImageBitmap GetCopy()
        {
            return new ImageBitmap(this);
        }
        public Color[,] GetRawData()
        {
            return RawData;
        }
        public Color GetPixel(int y, int x)
        {
            return RawData[y,x];
        }
        public Bitmap GetImage()
        {
            Bitmap ret = new(Width, Height, PixelFormat.Format32bppRgb);

            for (int y = 0; y < Width; y++)
            {
                for (int x = 0; x < Height; x++)
                {
                    ret.SetPixel(y, x, RawData[y, x]);
                }
            }

            return ret;
        }

        private void SetRawData(Bitmap ?sourceImage)
        {
            if(sourceImage != null)
            {
                Color[,] data = new Color[Width, Height];
                for (int y = 0; y < Width; y++)
                {
                    for (int x = 0; x < Height; x++)
                    {
                        data[y, x] = sourceImage.GetPixel(y, x);
                    }
                }
                RawData = new Color[Width, Height];
                Array.Copy(data, RawData, Width * Height);
            }
            else
            {
                Color[,] data = new Color[Width, Height];
                for (int y = 0; y < Width; y++)
                {
                    for (int x = 0; x < Height; x++)
                    {
                        data[y, x] = Color.FromArgb(255,0,0,0);
                    }
                }
                RawData = new Color[Width, Height];
                Array.Copy(data, RawData, Width * Height);
            }
        }

        public void SetPixel(int y, int x, Color color)
        {
            RawData[y,x] = color;
        }
    }
}
