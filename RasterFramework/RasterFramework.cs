using RasterFramework.Core;
using RasterFramework.LowLevel;
using RasterFramework.Processing;

namespace RasterFramework
{
    public partial class RasterFramework : Form
    {
        private Core.Image image;
        private IDrawLine line;
        private IDrawCurve curve;
        private IDrawFill fill;
        private IFilter filter;
        private IConvolution convolution;

        private int imageScale = 1;
        private int prevImageScale = 1;

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

            //double[,] kernel = GenerateKernel.GetKernel(ConvolutionType.GaussBlur3x3);

            //convolution = new Blur();
            //image = convolution.Apply(image, kernel);
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
                        imageScale = 1;
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

            imageBox.Image = imageToDraw;
        }

        private Color[,] ResizeImage()
        {
            Color[,] rawData = image.GetRawData();
            int height = image.GetHeight();
            int width = image.GetWidth();

            int scale = imageScale;

            int newHeight = height * scale;
            int newWidht = width * scale;
            Color[,] newRawData = new Color[newHeight, newWidht];

            int startX = 0; int startY = 0;

            for (int y1 = 0; y1 < height; y1++)
            {
                for (int x1 = 0; x1 < width; x1++)
                {
                    for (int y2 = startY; y2 < (startY + imageScale); y2++)
                    {
                        for (int x2 = startX; x2 < (startX + imageScale); x2++)
                        {
                            newRawData[y2, x2] = rawData[y1, x1];
                        }
                    }

                    startX += imageScale;
                }

                startX = 0;
                startY += imageScale;
            }

            return newRawData;
        }

        private void numZoom_ValueChanged(object sender, EventArgs e)
        {
            imageScale = (int)numZoom.Value;

            DrawImage(ResizeImage());
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