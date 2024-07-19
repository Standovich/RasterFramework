using RasterFramework.Core;
using RasterFramework.Forms;
using RasterFramework.LowLevel;
using RasterFramework.Processing;
using System.Collections.Generic;
using System.Reflection;

namespace RasterFramework
{
    public partial class RasterFramework : Form
    {
        private Core.Image image;
        private Core.Image filledImage;

        private bool fillActive;
        private bool imageLoaded = false;

        private IDrawLine line;
        private IDrawCurve curve;
        private IDrawFill fill;
        private IFilter filter;
        private IConvolution convolution;

        private IEnumerable<Type> drawLineClasses;
        private IEnumerable<Type> drawCurveClasses;
        private IEnumerable<Type> drawFillClasses;
        private IEnumerable<Type> filterClasses;
        private IEnumerable<Type> convolutionClasses;

        private List<string> listOfFillAlgorithms;
        private Type SelectedFillAlgorithm;
        private List<string> listOfFilterAlgorithms;
        private Type SelectedFilterAlgorithm;

        private int imageScale = 1;

        public RasterFramework()
        {
            InitializeComponent();
        }

        //Inicializaèní metody
        private void Form1_Load(object sender, EventArgs e)
        {
            image = new(imageBox.Width, imageBox.Height);
            fillActive = false;
            canvasSelectBox.SelectedIndex = 0;
            LoadClassLists();
            InitUI();
            DrawImage(image.GetRawData());
        }

        private void LoadClassLists()
        {
            drawLineClasses = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IDrawLine).IsAssignableFrom(p) && p.IsClass);

            drawCurveClasses = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IDrawCurve).IsAssignableFrom(p) && p.IsClass);

            drawFillClasses = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IDrawFill).IsAssignableFrom(p) && p.IsClass);

            filterClasses = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IFilter).IsAssignableFrom(p) && p.IsClass);

            convolutionClasses = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IConvolution).IsAssignableFrom(p) && p.IsClass);
        }

        private void InitUI()
        {
            InitFillUI();
            InitFilterUI();
        }

        private void InitFillUI()
        {
            if (drawFillClasses.Count() > 0)
            {
                listOfFillAlgorithms = new List<string>();

                foreach (Type type in drawFillClasses)
                {
                    object lineClass = Activator.CreateInstance(type);
                    MethodInfo methodInfo = type.GetMethod("GetName");
                    var result = methodInfo.Invoke(lineClass, null);

                    listOfFillAlgorithms.Add((string)result);
                }

                foreach (string name in listOfFillAlgorithms)
                {
                    fillSelectBox.Items.Add(name);
                }

                SelectedFillAlgorithm = drawFillClasses.First();
                fillSelectBox.SelectedIndex = 0;
            }
        }

        private void InitFilterUI()
        {
            if (filterClasses.Count() > 0)
            {
                listOfFilterAlgorithms = new List<string>();

                foreach (Type type in filterClasses)
                {
                    object lineClass = Activator.CreateInstance(type);
                    MethodInfo methodInfo = type.GetMethod("GetName");
                    var result = methodInfo.Invoke(lineClass, null);

                    listOfFilterAlgorithms.Add((string)result);
                }

                foreach (string name in listOfFilterAlgorithms)
                {
                    filterSelectBox.Items.Add(name);
                }

                SelectedFilterAlgorithm = filterClasses.First();
                filterSelectBox.SelectedIndex = 0;
            }
            else btnApplyFilter.Enabled = false;
        }

        //Volání vybraných metod ze studentské èásti
        private void DrawLine(Type type, Point p0, Point p1)
        {
            Assembly assem = typeof(IDrawLine).Assembly;
            line = (IDrawLine)assem.CreateInstance(type.FullName.ToString());

            line.Apply(image, p0, p1);
        }

        private void DrawCurve(Type type, Point[] points)
        {
            Assembly assem = typeof(IDrawCurve).Assembly;
            curve = (IDrawCurve)assem.CreateInstance(type.FullName.ToString());

            curve.Apply(image, points);
        }

        private void DrawFill(Type type)
        {
            filledImage = new(image.GetRawData());

            Assembly assem = typeof(IDrawFill).Assembly;
            fill = (IDrawFill)assem.CreateInstance(type.FullName.ToString());

            fill.Apply(filledImage);
        }

        private void ApplyFilter(Type type)
        {
            Assembly assem = typeof(IFilter).Assembly;
            filter = (IFilter)assem.CreateInstance(type.FullName.ToString());

            image = filter.Apply(image);
        }

        //Škálování a vykreslování obrazu
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
                    Color colorToCopy = rawData[y1, x1];
                    for (int y2 = startY; y2 < (startY + imageScale); y2++)
                    {
                        for (int x2 = startX; x2 < (startX + imageScale); x2++)
                        {
                            newRawData[y2, x2] = colorToCopy;
                        }
                    }

                    startX += imageScale;
                }

                startX = 0;
                startY += imageScale;
            }

            return newRawData;
        }

        private void RedrawCanvas(Size newSize)
        {
            if (newSize.Width > image.GetWidth())
            {
                Color[,] newRawData = ScaleUp(newSize);
                image = new(newRawData);
                DrawImage(newRawData);
            }
            if (newSize.Width < image.GetWidth())
            {
                Color[,] newRawData = ScaleDown(newSize);
                image = new(newRawData);
                DrawImage(newRawData);
            }
        }

        private Color[,] ScaleUp(Size newSize)
        {
            Color[,] currentRawData = image.GetRawData();
            Color[,] newRawData = new Color[newSize.Height, newSize.Width];

            int currentWidth = image.GetWidth();
            int currentHeight = image.GetHeight();

            for (int y = 0; y < currentHeight; y++)
            {
                for (int x = 0; x < currentWidth; x++)
                {
                    newRawData[y, x] = currentRawData[y, x];
                }
            }

            for (int y = 0; y < currentHeight; y++)
            {
                for (int x = currentWidth; x < newSize.Width; x++)
                {
                    newRawData[y, x] = Color.FromArgb(0, 0, 0);
                }
            }

            for (int y = currentHeight; y < newSize.Height; y++)
            {
                for (int x = 0; x < newSize.Width; x++)
                {
                    newRawData[y, x] = Color.FromArgb(0, 0, 0);
                }
            }

            return newRawData;
        }

        private Color[,] ScaleDown(Size newSize)
        {
            Color[,] currentRawData = image.GetRawData();
            Color[,] newRawData = new Color[newSize.Height, newSize.Width];

            for (int y = 0; y < newSize.Height; y++)
            {
                for (int x = 0; x < newSize.Width; x++)
                {
                    newRawData[y, x] = currentRawData[y, x];
                }
            }

            return newRawData;
        }

        //Metody uživatelského rozhraní
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

            imageLoaded = true;
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

        private void numZoom_ValueChanged(object sender, EventArgs e)
        {
            imageScale = (int)numZoom.Value;
            DrawImage(ResizeImage());
        }

        private void btnNewInstance_Click(object sender, EventArgs e)
        {
            RasterFramework newInstance = new();
            newInstance.Show();
        }

        private void canvasSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Size newSize = new();

            switch (canvasSelectBox.SelectedIndex)
            {
                case 0:
                    newSize = new Size(400, 400);
                    imageBox.Size = new(400, 400);
                    imagePanel.Size = new(403, 403);
                    this.MinimumSize = new(580, 565);

                    lblCanvasSize.Location = new(12, 475);
                    canvasSelectBox.Location = new(9, 493);

                    btnNewInstance.Location = new(159, 493);
                    break;
                case 1:
                    newSize = new Size(1280, 720);
                    if (this.Width < 1460 || this.Height < 880) this.Size = new(1460, 885);
                    this.MinimumSize = new(1460, 885);
                    imageBox.Size = new(1280, 720);
                    imagePanel.Size = new(1283, 723);

                    lblCanvasSize.Location = new(12, 795);
                    canvasSelectBox.Location = new(9, 813);
                    btnNewInstance.Location = new(159, 813);
                    break;
            }

            if (!imageLoaded) RedrawCanvas(newSize);
        }

        private void btnAddLIne_Click(object sender, EventArgs e)
        {
            AddLineForm addLineForm = new(drawLineClasses,
                new(image.GetWidth(), image.GetHeight()));
            var addLine = addLineForm.ShowDialog();

            if (addLine == DialogResult.OK)
            {
                DrawLine(
                    addLineForm.SelectedAlgorithm,
                    addLineForm.PointA,
                    addLineForm.PointB);
                DrawImage(image.GetRawData());
            }
        }

        private void btnAddCurve_Click(object sender, EventArgs e)
        {
            AddCurveForm addCurveForm = new(drawCurveClasses,
                new(image.GetWidth(), image.GetHeight()));
            var addCurve = addCurveForm.ShowDialog();

            if (addCurve == DialogResult.OK)
            {
                DrawCurve(
                    addCurveForm.SelectedAlgorithm,
                    addCurveForm.Points.ToArray());
                DrawImage(image.GetRawData());
            }
        }

        private void fillCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (drawFillClasses.Count() > 0)
            {
                fillActive = fillCheckBox.Checked;
                if (fillActive)
                {
                    DrawFill(SelectedFillAlgorithm);
                    DrawImage(filledImage.GetRawData());
                }
                else DrawImage(image.GetRawData());
            }
            else fillCheckBox.CheckState = CheckState.Unchecked;
        }

        private void fillSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Type type in drawFillClasses)
            {
                object lineClass = Activator.CreateInstance(type);
                MethodInfo methodInfo = type.GetMethod("GetName");
                var result = methodInfo.Invoke(lineClass, null);

                if ((string)result == fillSelectBox.SelectedItem.ToString())
                {
                    SelectedFillAlgorithm = type;
                    break;
                }
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter(SelectedFilterAlgorithm);
            DrawImage(image.GetRawData());
        }

        private void filterSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Type type in filterClasses)
            {
                object lineClass = Activator.CreateInstance(type);
                MethodInfo methodInfo = type.GetMethod("GetName");
                var result = methodInfo.Invoke(lineClass, null);

                if ((string)result == filterSelectBox.SelectedItem.ToString())
                {
                    SelectedFilterAlgorithm = type;
                    break;
                }
            }
        }

        private void btnAddConvolution_Click(object sender, EventArgs e)
        {
            ApplyConvolutionForm applyConvolutionForm = new(convolutionClasses);
            var applyConvolution = applyConvolutionForm.ShowDialog();

            if (applyConvolution == DialogResult.OK)
            {

            }
        }
    }
}