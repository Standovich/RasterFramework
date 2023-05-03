using RasterFramework.Core;

namespace RasterFramework.ImageProcessing
{
    internal class GrayscaleConvertor
    {
        public static Color[,] ToWeightedGrayscale(Color[,] coloredImage)
        {
            Color[,] grayImage = new Color[coloredImage.GetLength(0), coloredImage.GetLength(1)];

            for (int y = 0; y < grayImage.GetLength(0); y++)
            {
                for (int x = 0; x < grayImage.GetLength(1); x++)
                {
                    int r = coloredImage[y, x].R;
                    int g = coloredImage[y, x].G;
                    int b = coloredImage[y, x].B;
                    int gray = (int)((r * 0.299) + (g * 0.587) + (b * 0.114));

                    Color grayPixel = Color.FromArgb(255, gray, gray, gray);
                    grayImage[y,x] = grayPixel;
                }
            }

            return grayImage;
        }

        public static Color[,] ToAverageGrayscale(Color[,] coloredImage)
        {
            Color[,] grayImage = new Color[coloredImage.GetLength(0), coloredImage.GetLength(1)];

            for (int y = 0; y < grayImage.GetLength(0); y++)
            {
                for (int x = 0; x < grayImage.GetLength(1); x++)
                {
                    int r = coloredImage[y, x].R;
                    int g = coloredImage[y, x].G;
                    int b = coloredImage[y, x].B;
                    int gray = (r / 3) + (g / 3) + (b / 3);

                    Color grayPixel = Color.FromArgb(0, gray, gray, gray);
                    grayImage[y, x] = grayPixel;
                }
            }

            return grayImage;
        }

        public static double RGBtoGray(Color color)
        {
            int r = color.R;
            int g = color.G;
            int b = color.B;
            return (r * 0.299) + (g * 0.587) + (b * 0.114);
        }
    }
}
