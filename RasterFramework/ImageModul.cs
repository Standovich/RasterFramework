using RasterFramework.Core;
using RasterFramework.ImageProcessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RasterFramework
{
    public partial class ImageModul : UserControl
    {
        private ImageBitmap? SourceImage;
        private ImageBitmap? GrayImage;

        private bool GrayEnabled = false;
        private bool ConvEnabled = false;
        private bool NegaEnabled = false;

        public ImageModul()
        {
            InitializeComponent();
        }

        private void ImageModul_Load(object sender, EventArgs e)
        {
            grayScaleBox.SelectedIndex = 0;
            convolutionBox.SelectedIndex = 0;
            numThreshold.Value = 10;
        }

        private void imgSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (imgSelectBox.SelectedIndex)
            {
                case 0:
                    SourceImage = ResizeImg(new Bitmap(@"..\..\..\Images\1.png"));
                    break;
                case 1:
                    SourceImage = ResizeImg(new Bitmap(@"..\..\..\Images\2.png"));
                    break;
                case 2:
                    SourceImage = ResizeImg(new Bitmap(@"..\..\..\Images\3.png"));
                    break;
                case 3:
                    OpenFileDialog frmOpenImg = new OpenFileDialog()
                    {
                        Title = "Open image"
                    };
                    var open = frmOpenImg.ShowDialog();
                    if (open == DialogResult.OK)
                    {
                        SourceImage = ResizeImg(new Bitmap(Image.FromFile(frmOpenImg.FileName)));
                    }
                    break;
            }
            ResetModul();
            imageBox.Image = SourceImage.GetImage();
        }

        private ImageBitmap ResizeImg(Bitmap img)
        {
            double ratioX = imageBox.Width / img.Width;
            double ratioY = imageBox.Height / img.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);

            Bitmap resizedImg = new Bitmap(img, newWidth, newHeight);
            return new ImageBitmap(resizedImg);
        }

        private void ResetModul()
        {
            GrayEnabled = false;
            ConvEnabled = false;
            NegaEnabled = false;
            GrayImage = null;
            checkGray.Checked = false;
            checkConv.Checked = false;
            checkNegative.Checked = false;
        }

        private void ProcessingCheck()
        {
            if(SourceImage != null)
            {
                if (GrayEnabled)
                {
                    if (NegaEnabled)
                    {
                        if (GrayImage == null)
                            GrayImage = GrayscaleConvertor.ApplyGrayScale(
                            grayScaleBox.SelectedIndex, SourceImage);

                        if (ConvEnabled)
                        {
                            ImageBitmap newImage = Convolution.ChooseConvolution(
                                false, Convert.ToInt32(numThreshold.Value),
                                convolutionBox.SelectedIndex, GrayImage);
                            imageBox.Image = NegativeConvertor.ConvertToNegative(newImage).GetImage();
                        }
                        else
                        {
                            imageBox.Image = NegativeConvertor.ConvertToNegative(GrayImage).GetImage();
                        }

                    }
                    else
                    {
                        if (GrayImage == null)
                            GrayImage = GrayscaleConvertor.ApplyGrayScale(
                            grayScaleBox.SelectedIndex, SourceImage);

                        if (ConvEnabled)
                        {
                            ImageBitmap newImage = Convolution.ChooseConvolution(
                                false, Convert.ToInt32(numThreshold.Value),
                                convolutionBox.SelectedIndex, GrayImage);
                            imageBox.Image = newImage.GetImage();
                        }
                        else
                        {
                            imageBox.Image = GrayImage.GetImage();
                        }
                    }
                }
                else
                {
                    if (NegaEnabled)
                    {
                        if (ConvEnabled)
                        {
                            ImageBitmap newImage = Convolution.ChooseConvolution(
                                false, Convert.ToInt32(numThreshold.Value),
                                convolutionBox.SelectedIndex, SourceImage);
                            //newImage = NegativeConvertor.ConvertToNegative(new(newImage.GetCopy()));
                            imageBox.Image = NegativeConvertor.ConvertToNegative(newImage).GetImage();
                        }
                        else
                        {
                            imageBox.Image = NegativeConvertor.ConvertToNegative(SourceImage).GetImage();
                        }

                    }
                    else
                    {
                        if (ConvEnabled)
                        {
                            imageBox.Image = Convolution.ChooseConvolution(
                                false, Convert.ToInt32(numThreshold.Value),
                                convolutionBox.SelectedIndex, SourceImage).GetImage();
                        }
                        else
                        {
                            imageBox.Image = SourceImage.GetImage();
                        }
                    }
                }
            }
        }

        public void ChangeRGB(int r, int g, int b)
        {
            if(SourceImage != null)
                imageBox.Image = ColorController.ChangeRGB(r, g, b, SourceImage).GetImage();
        }
        public void ChangeHSL(int h, float s, float l)
        {
            if (SourceImage != null) 
                imageBox.Image = ColorController.ChangeHSL(h, s, l, SourceImage).GetImage();
        }

        private void checkGray_CheckedChanged(object sender, EventArgs e)
        {
            if(GrayEnabled) GrayEnabled = false;
            else GrayEnabled = true;
            ProcessingCheck();
        }

        private void grayScaleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessingCheck();
        }

        private void checkConv_CheckedChanged(object sender, EventArgs e)
        {
            if(ConvEnabled) ConvEnabled = false;
            else ConvEnabled = true;
            ProcessingCheck();
        }

        private void convolutionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessingCheck();
        }

        private void numThreshold_ValueChanged(object sender, EventArgs e)
        {
            ProcessingCheck();
        }

        private void checkNegative_CheckedChanged(object sender, EventArgs e)
        {
            if (NegaEnabled) NegaEnabled = false;
            else NegaEnabled = true;
            ProcessingCheck();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Form1 form1 = this.ParentForm as Form1;
            if(form1 != null)
            {
                form1.removeModul(this);
            }
        }
    }
}
