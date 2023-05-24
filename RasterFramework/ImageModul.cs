using RasterFramework.Core;
using RasterFramework.Processing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RasterFramework
{
    public partial class ImageModul : UserControl
    {
        private Core.Image image;
        IFilter filter;

        private double imageScale = 1.0;
        private bool grayScale = false;

        public ImageModul()
        {
            InitializeComponent();
        }

        private void ImageModul_Load(object sender, EventArgs e)
        {
            image = new(imageBox.Width, imageBox.Height);
        }

        private void imgSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (imgSelectBox.SelectedIndex)
            {
                case 0:
                    image = Core.Image.LoadFromFile(@"../../../Images/1.png");
                    break;
                case 1:
                    image = Core.Image.LoadFromFile(@"../../../Images/2.png");
                    break;
                case 2:
                    image = Core.Image.LoadFromFile(@"../../../Images/3.png");
                    break;
                case 3:
                    OpenFileDialog frmOpenImg = new OpenFileDialog()
                    {
                        Title = "Open image"
                    };
                    var open = frmOpenImg.ShowDialog();
                    if (open == DialogResult.OK)
                    {
                        image = Core.Image.LoadFromFile(frmOpenImg.FileName);
                    }
                    break;
            }

            DrawImage(image.GetRawData());
            Processing();
        }

        private void DrawImage(Color[,] rawData)
        {
            int width = rawData.GetLength(0);
            int height = rawData.GetLength(1);

            Bitmap imageToDraw = new(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    imageToDraw.SetPixel(x, y, rawData[x, y]);
                }
            }

            imageBox.Image = ResizeImg(imageToDraw);
        }

        private Bitmap ResizeImg(Bitmap imageToResize)
        {
            double ratioX = ImagePanel.Width / imageToResize.Width;
            double ratioY = ImagePanel.Height / imageToResize.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newX = (int)(imageToResize.Width * ratio);
            int newY = (int)(imageToResize.Height * ratio);

            if (imageScale != 1.0)
            {
                newX = (int)(newX * imageScale);
                newY = (int)(newY * imageScale);
            }

            return new(imageToResize, new(newX, newY));
        }

        private void Processing()
        {
            filter = Convolution.Create(ConvolutionType.GaussBlur, ConvolutionSize.S_3);

            image = filter.Apply(image);

            DrawImage(image.GetRawData());
        }

        private void checkGray_CheckedChanged(object sender, EventArgs e)
        {
            grayScale = checkGray.Checked;
            Processing();
        }

        private void convolutionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void numThreshold_ValueChanged(object sender, EventArgs e)
        {
        }

        private void checkNegative_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
        }

        private void numZoom_ValueChanged(object sender, EventArgs e)
        {
            imageScale = (double)numZoom.Value / 100;
            DrawImage(image.GetRawData());
        }
    }
}
