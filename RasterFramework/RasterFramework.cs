using RasterFramework.Core;
using RasterFramework.LowLevel;
using RasterFramework.Processing;

namespace RasterFramework
{
    public partial class RasterFramework : Form
    {
        private Core.Image image;
        private IFilter filter;
        private IConvolution convolution;
        private ILowLevelLine line;
        private ILowLevelCurve curve;

        private double imageScale = 1.0;

        public RasterFramework()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image = new(imageBox.Width, imageBox.Height);
            Processing();
            DrawImage(image.GetRawData());
        }

        private void Processing()
        {
            //line = new DrawLineNaive();
            //line.Apply(image, new Point(50, 75), new Point(250, 300));

            //Point[] points = { new(50, 300), new(75, 150), new(250, 300), new(350, 100) };
            //curve = new DrawCubic();
            //curve.Apply(image, points);

            //filter = new GrayScale();
            //image = filter.Apply(image);

            double[,] kernel = GenerateKernel.GetKernel(ConvolutionType.Sharpen);

            convolution = new Sharpen();
            image = convolution.Apply(image, kernel);
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
                        Title = "Otevøít obrázek"
                    };
                    var open = frmOpenImg.ShowDialog();
                    if (open == DialogResult.OK)
                    {
                        image = Core.Image.LoadFromFile(frmOpenImg.FileName);
                        imageScale = 1.0;
                    }
                    break;
            }

            Processing();
            DrawImage(image.GetRawData());
        }

        private void DrawImage(Color[,] rawData)
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

            imageBox.Image = ResizeImg(imageToDraw);
        }

        private Bitmap ResizeImg(Bitmap imageToResize)
        {
            double ratioX = imagePanel.Width / imageToResize.Width;
            double ratioY = imagePanel.Height / imageToResize.Height;
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

        private void numZoom_ValueChanged(object sender, EventArgs e)
        {
            imageScale = (double)numZoom.Value / 100;
            DrawImage(image.GetRawData());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Title = "Uložit obrázek",
                DefaultExt = "png",
                Filter = "Image files (*.png)|*.png|All files (*.*)|*.*"
            };
            var save = saveFileDialog.ShowDialog();
            if (save == DialogResult.OK)
            {
                image.SaveToFile(saveFileDialog.FileName);
            }
        }

        private void btnNewInstance_Click(object sender, EventArgs e)
        {
            RasterFramework newInstance = new();
            newInstance.Show();
        }
    }
}