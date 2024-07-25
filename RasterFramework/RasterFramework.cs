using RasterFramework.Core;
using RasterFramework.Forms;
using RasterFramework.Interfaces;
using System.Reflection;

namespace RasterFramework
{
    public partial class RasterFramework : Form
    {
        private Core.Image image;
        private Core.Image filledImage;
        private AlgorithmCall algorithmCall;
        private Renderer renderer;

        private bool fillActive;
        private bool imageLoaded = false;
        private bool EventsOff = false;

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
        private bool isScaled  = false;

        public RasterFramework()
        {
            InitializeComponent();
        }

        //Inicializaèní metody
        private void Form1_Load(object sender, EventArgs e)
        {
            EventsOff = true;

            algorithmCall = new();
            renderer = new();
            image = new(imageBox.Width, imageBox.Height);
            canvasSelectBox.SelectedIndex = 0;
            fillActive = false;
            LoadClassLists();
            InitUI();
            renderer.DrawImage(image.RawData, imageBox);

            EventsOff = false;
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
            InitFormButtons();
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

        private void InitFormButtons()
        {
            if (drawLineClasses.Count() > 0) btnAddLIne.Enabled = true;
            if (drawCurveClasses.Count() > 0) btnAddCurve.Enabled = true;
            if (convolutionClasses.Count() > 0) btnAddConvolution.Enabled = true;
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
                        Title = "Otevøít obrázek",
                        Filter = "Image Files|*.jpg;*.jpeg;*.png"
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
            renderer.DrawImage(image.RawData, imageBox);
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
            isScaled = imageScale != 1 ? true : false;

            Color[,] newRawData = renderer.ResizeImage(image.RawData, imageScale);
            renderer.DrawImage(newRawData, imageBox);
        }

        private void btnNewInstance_Click(object sender, EventArgs e)
        {
            RasterFramework newInstance = new();
            newInstance.Show();
        }

        private void canvasSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!EventsOff)
            {
                Size newSize = new();

                switch (canvasSelectBox.SelectedIndex)
                {
                    case 0:
                        newSize = new Size(400, 400);
                        imageBox.Size = new(400, 400);
                        imagePanel.Size = new(403, 403);
                        this.MinimumSize = new(580, 525);
                        break;
                    case 1:
                        newSize = new Size(1280, 720);
                        if (this.Width < 1460 || this.Height < 830) this.Size = new(1460, 845);
                        this.MinimumSize = new(1460, 845);
                        imageBox.Size = new(1280, 720);
                        imagePanel.Size = new(1283, 723);
                        break;
                }

                if (!imageLoaded)
                {
                    image = new(renderer.RedrawCanvas(image, newSize));
                    renderer.DrawImage(image.RawData, imageBox);
                    numZoom.Value = 1; isScaled = false;
                }
            }
        }

        private void btnAddLIne_Click(object sender, EventArgs e)
        {
            AddLineForm addLineForm = new(drawLineClasses,
                new(image.Width - 1, image.Height - 1));
            var addLine = addLineForm.ShowDialog();

            if (addLine == DialogResult.OK)
            {
                image = new(algorithmCall.DrawLine(
                        image,
                        addLineForm.SelectedAlgorithm,
                        addLineForm.PointA,
                        addLineForm.PointB));
                if (isScaled)
                {
                    Color[,] newRawData = renderer.ResizeImage(image.RawData, imageScale);
                    renderer.DrawImage(newRawData, imageBox);
                }
                else renderer.DrawImage(image.RawData, imageBox);
            }
        }

        private void btnAddCurve_Click(object sender, EventArgs e)
        {
            AddCurveForm addCurveForm = new(drawCurveClasses,
                new(image.Width - 1, image.Height - 1));
            var addCurve = addCurveForm.ShowDialog();

            if (addCurve == DialogResult.OK)
            {
                image = new(algorithmCall.DrawCurve(
                        image,
                        addCurveForm.SelectedAlgorithm,
                        addCurveForm.Points.ToArray()));
                if (isScaled)
                {
                    Color[,] newRawData = renderer.ResizeImage(image.RawData, imageScale);
                    renderer.DrawImage(newRawData, imageBox);
                }
                else renderer.DrawImage(image.RawData, imageBox);
            }
        }

        private void fillCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (drawFillClasses.Count() > 0)
            {
                fillActive = fillCheckBox.Checked;
                if (fillActive)
                {
                    filledImage = new(image.RawData);

                    filledImage = new(algorithmCall.DrawFill(
                            fillCheckBox,
                            filledImage,
                            SelectedFillAlgorithm));
                    if (isScaled)
                    {
                        Color[,] newRawData = renderer.ResizeImage(filledImage.RawData, imageScale);
                        renderer.DrawImage(newRawData, imageBox);
                    }
                    else renderer.DrawImage(filledImage.RawData, imageBox);
                }
                else
                {
                    if (isScaled)
                    {
                        Color[,] newRawData = renderer.ResizeImage(image.RawData, imageScale);
                        renderer.DrawImage(newRawData, imageBox);
                    }
                    else renderer.DrawImage(image.RawData, imageBox);
                }
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
            image = new(algorithmCall.ApplyFilter(
                    image,
                    SelectedFilterAlgorithm));
            if (isScaled)
            {
                Color[,] newRawData = renderer.ResizeImage(image.RawData, imageScale);
                renderer.DrawImage(newRawData, imageBox);
            }
            else renderer.DrawImage(image.RawData, imageBox);
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
                image = new(algorithmCall.ApplyConvolution(
                        image,
                        applyConvolutionForm.SelectedAlgorithm,
                        applyConvolutionForm.Kernel));
                if (isScaled)
                {
                    Color[,] newRawData = renderer.ResizeImage(image.RawData, imageScale);
                    renderer.DrawImage(newRawData, imageBox);
                }
                else renderer.DrawImage(image.RawData, imageBox);
            }
        }
    }
}