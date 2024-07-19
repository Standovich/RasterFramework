using RasterFramework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RasterFramework.Forms
{
    public partial class ApplyConvolutionForm : Form
    {
        private List<string> listOfAlgorithms;
        private IEnumerable<Type> listOfClasses;
        private Array kernelEnums;
        private List<double[,]> kernels;

        public Type SelectedAlgorithm { get; set; }
        public double[,] Kernel { get; set; }
        public ApplyConvolutionForm(IEnumerable<Type> listOfTypes)
        {
            InitializeComponent();
            InitLists(listOfTypes);
        }

        private void InitLists(IEnumerable<Type> listOfTypes)
        {
            listOfClasses = listOfTypes;
            listOfAlgorithms = new();
            kernels = new();
            kernelEnums = Enum.GetValues(typeof(ConvolutionType));

            foreach (Type type in listOfTypes)
            {
                object lineClass = Activator.CreateInstance(type);
                MethodInfo methodInfo = type.GetMethod("GetName");
                var result = methodInfo.Invoke(lineClass, null);

                listOfAlgorithms.Add((string)result);
            }

            foreach (ConvolutionType item in kernelEnums)
            {
                kernels.Add(GenerateKernel.GetKernel(item));
            }
        }

        private void ApplyConvolutionForm_Load(object sender, EventArgs e)
        {
            foreach (string name in listOfAlgorithms)
            {
                methodSelectBox.Items.Add(name);
            }

            foreach (ConvolutionType item in kernelEnums)
            {
                kernelSelectBox.Items.Add(item);
            }
            kernelSelectBox.Items.Add("Vlastní");

            SelectedAlgorithm = listOfClasses.First();
            methodSelectBox.SelectedIndex = 0;
            Kernel = kernels.First();
            kernelSelectBox.SelectedIndex = 0;
            InitKernelGrid(Kernel);
        }

        private void InitKernelGrid(double[,] kernel)
        {
            int gridSize = (int)Math.Sqrt(kernel.Length);

            kernelGrid.RowCount = gridSize;
            kernelGrid.ColumnCount = gridSize;

            for (int y = 0; y < kernelGrid.RowCount; y++)
            {
                for (int x = 0; x < kernelGrid.ColumnCount; x++)
                {
                    var cell = new NumericUpDown()
                    {
                        Dock = DockStyle.Fill,
                        TextAlign = HorizontalAlignment.Center,
                        Value = (decimal)kernel[y, x],
                        Minimum = -1000,
                        Maximum = 1000,
                        Size = new(50, 25)
                    };
                    cell.Controls[0].Visible = false;
                    cell.Controls[1].Width = Width - 4;

                    kernelGrid.Controls.Add(cell, y, x);
                }
            }
        }

        private void SetKernelGridData(double[,] kernel)
        {
            for (int y = 0; y < kernelGrid.RowCount; y++)
            {
                for (int x = 0; x < kernelGrid.ColumnCount; x++)
                {

                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

        }
    }
}
