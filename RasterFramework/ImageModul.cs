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
                    image = image.LoadFromFile("Images/1.png");
                    break;
                case 1:
                    image = image.LoadFromFile("Images/2.png");
                    break;
                case 2:
                    image = image.LoadFromFile("Images/3.png");
                    break;
                case 3:
                    break;
            }
        }

        private void checkGray_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void grayScaleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }
    }
}
