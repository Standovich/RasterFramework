using RasterFramework.Core;
using RasterFramework.ImageProcessing;
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
        private ImageBitmap? SourceImage;
        private Color[,]? GrayImage;
        private Color[,]? EditedImage;
        private List<ConvMethod> ConvMethods;
        private List<string> ConvMethodNames;

        private bool GrayEnabled = false;
        private bool ConvEnabled = false;
        private bool NegaEnabled = false;
        private bool Zoomed = false;

        private double scale;
        private double width;
        private double height;

        private int r = 100;
        private int g = 100;
        private int b = 100;

        private int h = 0;
        private float s = 0;
        private float l = 0;

        public ImageModul()
        {
            InitializeComponent();
        }

        private void ImageModul_Load(object sender, EventArgs e)
        {
            grayScaleBox.SelectedIndex = 0;
            numThreshold.Value = 10;
            ConvMethods = Convolution.InitializeMethods();
            ConvMethodNames = new List<string>();

            //ConvMethods.Add(new("Box blur (3x3)", new int[,] {
            //    { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 }
            //}, true));
            //ConvMethods.Add(new("Box blur (5x5)", new int[,] {
            //    { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 },
            //    { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }
            //}, true));
            //ConvMethods.Add(new("Gaussian blur (3x3)", new int[,] {
            //    { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 }
            //}, true));
            //ConvMethods.Add(new("Gaussian blur (5x5)", new int[,] {
            //    { 1, 4, 6, 4, 1 }, { 4, 16, 24, 16, 4 }, { 6, 24, 36, 24, 6 },
            //    { 4, 16, 24, 16, 4 }, { 1, 4, 6, 4, 1 }
            //}, true));
            //ConvMethods.Add(new("Sharpen (3x3)", new int[,] {
            //    { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 }
            //}, false));

            UpdateConvMethods();
        }

        private void imgSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap newImage = new(1, 1);
            switch (imgSelectBox.SelectedIndex)
            {
                case 0:
                    newImage = new Bitmap(@"..\..\..\Images\1.png");
                    break;
                case 1:
                    newImage = new Bitmap(@"..\..\..\Images\2.png");
                    break;
                case 2:
                    newImage = new Bitmap(@"..\..\..\Images\3.png");
                    break;
                case 3:
                    OpenFileDialog frmOpenImg = new OpenFileDialog()
                    {
                        Title = "Open image"
                    };
                    var open = frmOpenImg.ShowDialog();
                    if (open == DialogResult.OK)
                    {
                        newImage = new Bitmap(Image.FromFile(frmOpenImg.FileName));
                    }
                    break;
            }
            SourceImage = ResizeImg(newImage);

            width = SourceImage.GetWidth();
            height = SourceImage.GetHeight();
            scale = 1;

            EditedImage = SourceImage.GetRawData();

            ResetModul();
            SetImageBox(EditedImage);
        }

        private ImageBitmap ResizeImg(Bitmap img)
        {
            double ratioX = (double)ImagePanel.Width / (double)img.Width;
            double ratioY = (double)ImagePanel.Height / (double)img.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);

            Bitmap resizedImg = new Bitmap(img, newWidth, newHeight);
            return new ImageBitmap(resizedImg);
        }

        private void UpdateConvMethods()
        {
            convolutionBox.DataSource = null;
            ConvMethodNames.Clear();
            ConvMethodNames.Add("Žádné");
            foreach (ConvMethod item in ConvMethods)
            {
                ConvMethodNames.Add(item.Name);
            }
            //ConvMethodNames.Add("Upravit metody");
            convolutionBox.DataSource = ConvMethodNames;
            convolutionBox.SelectedIndex = 0;
        }

        private void ResetModul()
        {
            GrayEnabled = false;
            ConvEnabled = false;
            NegaEnabled = false;
            GrayImage = null;
            checkGray.Checked = false;
            checkNegative.Checked = false;
            numZoom.Value = 100;
            hsLcontroller1.ResetValues();
            rgBcontroller1.ResetValues();
        }

        private void ProcessingCheck()
        {
            if (SourceImage != null)
            {
                if(!Zoomed) EditedImage = SourceImage.GetRawData();
                else ZoomImg();

                EditedImage = ColorController.ChangeRGB(r, g, b, EditedImage);
                EditedImage = ColorController.ChangeHSL(h, s, l, EditedImage);

                if (GrayEnabled)
                {
                    GrayImage = ApplyGrayScale(grayScaleBox.SelectedIndex, EditedImage);

                    if (NegaEnabled)
                    {
                        if (ConvEnabled)
                        {
                            Color[,] newImage = Convolution.ApplyConvolution(
                                ConvMethods[convolutionBox.SelectedIndex - 1].Divide,
                                Convert.ToInt32(numThreshold.Value),
                                ConvMethods[convolutionBox.SelectedIndex - 1].Kernel,
                                GrayImage);
                            SetImageBox(NegativeConvertor.ConvertToNegative(newImage));
                        }
                        else
                        {
                            SetImageBox(NegativeConvertor.ConvertToNegative(GrayImage));
                        }

                    }
                    else
                    {
                        if (ConvEnabled)
                        {
                            Color[,] newImage = Convolution.ApplyConvolution(
                                ConvMethods[convolutionBox.SelectedIndex - 1].Divide,
                                Convert.ToInt32(numThreshold.Value),
                                ConvMethods[convolutionBox.SelectedIndex - 1].Kernel,
                                GrayImage);
                            SetImageBox(newImage);
                        }
                        else
                        {
                            SetImageBox(GrayImage);
                        }
                    }
                }
                else
                {
                    if (NegaEnabled)
                    {
                        if (ConvEnabled)
                        {
                            Color[,] newImage = Convolution.ApplyConvolution(
                                ConvMethods[convolutionBox.SelectedIndex - 1].Divide,
                                Convert.ToInt32(numThreshold.Value),
                                ConvMethods[convolutionBox.SelectedIndex - 1].Kernel,
                                EditedImage);
                            SetImageBox(NegativeConvertor.ConvertToNegative(newImage));
                        }
                        else
                        {
                            SetImageBox(NegativeConvertor.ConvertToNegative(EditedImage));
                        }

                    }
                    else
                    {
                        if (ConvEnabled)
                        {
                            SetImageBox(Convolution.ApplyConvolution(
                                ConvMethods[convolutionBox.SelectedIndex - 1].Divide,
                                Convert.ToInt32(numThreshold.Value),
                                ConvMethods[convolutionBox.SelectedIndex - 1].Kernel,
                                EditedImage));
                        }
                        else
                        {
                            SetImageBox(EditedImage);
                        }
                    }
                }
            }
        }
        private Color[,] ApplyGrayScale(int i, Color[,] coloredImage)
        {
            switch (i)
            {
                case 0:
                    return GrayscaleConvertor.ToAverageGrayscale(coloredImage);
                case 1:
                    return GrayscaleConvertor.ToWeightedGrayscale(coloredImage);
                default: return coloredImage;
            }
        }

        private void SetImageBox(Color[,] newImageData)
        {
            Bitmap newImageBitmap = new((int)width, (int)height, PixelFormat.Format32bppRgb);

            for (int y = 0; y < newImageData.GetLength(0); y++)
            {
                for (int x = 0; x < newImageData.GetLength(1); x++)
                {
                    newImageBitmap.SetPixel(y, x, newImageData[y, x]);
                }
            }
            imageBox.Image = newImageBitmap;
        }

        private void ZoomImg()
        {
            ImageBitmap zoomedImage = new(new Bitmap(SourceImage.GetImage(), (int)width, (int)height));
            EditedImage = zoomedImage.GetRawData();
        }

        public void ChangeRGB(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;

            ProcessingCheck();
        }
        public void ChangeHSL(int h, float s, float l)
        {
            this.h = h;
            this.s = s;
            this.l = l;

            ProcessingCheck();
        }

        private void checkGray_CheckedChanged(object sender, EventArgs e)
        {
            if (GrayEnabled) GrayEnabled = false;
            else GrayEnabled = true;
            ProcessingCheck();
        }

        private void grayScaleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessingCheck();
        }

        private void convolutionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (convolutionBox.SelectedIndex == convolutionBox.Items.Count - 1)
            //{
            //    ConvEditor convEditor = new ConvEditor(ConvMethods);
            //    var editor = convEditor.ShowDialog();
            //    if (editor == DialogResult.OK)
            //    {
            //        ConvMethods = new(convEditor.ConvMethods);
            //        UpdateConvMethods();
            //    }
            //    convolutionBox.SelectedIndex = 0;
            //}
            //else
            //{
            //    if (convolutionBox.SelectedIndex == 0) ConvEnabled = false;
            //    else ConvEnabled = true;
            //    ProcessingCheck();
            //}
            if (convolutionBox.SelectedIndex == 0) ConvEnabled = false;
            else ConvEnabled = true;
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
            if (form1 != null)
            {
                form1.removeModul(this);
            }
        }

        private void numZoom_ValueChanged(object sender, EventArgs e)
        {
            scale = (double)Convert.ToInt32(numZoom.Value) / 100;
            width = SourceImage.GetWidth() * scale;
            height = SourceImage.GetHeight() * scale;

            if (scale == 1) Zoomed = false;
            else Zoomed = true;

            ProcessingCheck();
        }
    }
}
