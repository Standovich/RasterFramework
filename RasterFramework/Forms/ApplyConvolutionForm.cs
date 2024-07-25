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
        private bool EventsOff = false;

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
            EventsOff = true;

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
            CreateKernelCopy(kernels.First());
            kernelSelectBox.SelectedIndex = 0;
            InitKernelGrid(Kernel);

            EventsOff = false;
        }

        private void CreateKernelCopy(double[,] kernel)
        {
            Kernel = new double[kernel.GetLength(0), kernel.GetLength(1)];
            Array.Copy(kernel, Kernel, kernel.Length);
        }

        private void InitKernelGrid(double[,] kernel)
        {
            int gridSize = (int)Math.Sqrt(kernel.Length);

            kernelGrid.Rows.Clear();
            kernelGrid.Columns.Clear();
            kernelGrid.ColumnCount = gridSize;

            for (int y = 0; y < gridSize; y++)
            {
                DataGridViewRow row = new();
                row.CreateCells(kernelGrid);

                for (int x = 0; x < gridSize; x++)
                {
                    row.Cells[x].Value = kernel[y, x];
                }
                kernelGrid.Rows.Add(row);
            }
        }

        private void CreateEmptyKernel(int size)
        {
            Kernel = new double[size, size];
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Kernel[y, x] = 0;
                }
            }
        }

        private void numGridSize_ValueChanged(object sender, EventArgs e)
        {
            kernelSelectBox.SelectedIndex = kernelSelectBox.Items.Count - 1;

            int newSize = (int)numGridSize.Value;

            CreateEmptyKernel(newSize);
            kernelGrid.Rows.Clear();
            kernelGrid.Columns.Clear();
            kernelGrid.ColumnCount = newSize;

            for (int y = 0; y < newSize; y++)
            {
                DataGridViewRow row = new();
                row.CreateCells(kernelGrid);

                for (int x = 0; x < newSize; x++)
                {
                    row.Cells[x].Value = 0;
                }
                kernelGrid.Rows.Add(row);
            }
        }

        private void kernelGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            kernelSelectBox.SelectedIndex = kernelSelectBox.Items.Count - 1;

            int indexX = e.ColumnIndex;
            int indexY = e.RowIndex;

            Kernel[indexY, indexX] = double.Parse(kernelGrid[indexX, indexY].Value.ToString());
        }

        private void kernelSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!EventsOff)
            {
                if (kernelSelectBox.SelectedItem.ToString() != "Vlastní")
                {
                    CreateKernelCopy(kernels[kernelSelectBox.SelectedIndex]);

                    int gridSize = (int)Math.Sqrt(Kernel.Length);

                    kernelGrid.Rows.Clear();
                    kernelGrid.Columns.Clear();
                    kernelGrid.ColumnCount = gridSize;

                    for (int y = 0; y < gridSize; y++)
                    {
                        DataGridViewRow row = new();
                        row.CreateCells(kernelGrid);

                        for (int x = 0; x < gridSize; x++)
                        {
                            row.Cells[x].Value = Kernel[y, x];
                        }
                        kernelGrid.Rows.Add(row);
                    }
                }
            }
        }

        private void methodSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!EventsOff)
            {
                foreach (Type type in listOfClasses)
                {
                    object convolutionClass = Activator.CreateInstance(type);
                    MethodInfo methodInfo = type.GetMethod("GetName");
                    var result = methodInfo.Invoke(convolutionClass, null);

                    if ((string)result == methodSelectBox.SelectedItem.ToString())
                    {
                        SelectedAlgorithm = type;
                        break;
                    }
                }
            }
        }
    }
}
