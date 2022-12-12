using RasterFramework.Core;
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
    public partial class ConvEditor : Form
    {
        public List<ConvMethod> ConvMethods { get; }
        private List<string> ConvMethodNames;

        private int gridLength = 9;
        private int colmnNum = 3;
        public ConvEditor(List<ConvMethod> methods)
        {
            InitializeComponent();
            ConvMethods = new(methods);
        }

        private void ConvEditor_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < gridLength; i++)
            {
                numUDgrid.Controls.Add(
                    new NumericUpDown()
                    {
                        Width = 40,
                        Minimum = -99,
                        Maximum = 99
                    });
            }

            ConvMethodNames = new List<string>();
            UpdateConvMethods();
        }

        private void ReloadGrid()
        {
            numUDgrid.Controls.Clear();
            numUDgrid.Width = colmnNum * 40 + (6 + (colmnNum - 1) * 6);

            int index = convMethodBox.SelectedIndex < 0 ?
                0 : convMethodBox.SelectedIndex;

            for (int x = 0; x < colmnNum; x++)
            {
                for (int y = 0; y < colmnNum; y++)
                {
                    numUDgrid.Controls.Add(    
                        new NumericUpDown()   
                        {
                            Width = 40,
                            Minimum = -99,
                            Maximum = 99,
                            Value = ConvMethods[index].Kernel[x, y]
                        });
                }
            }
        }

        private void UpdateConvMethods()
        {
            convMethodBox.DataSource = null;
            ConvMethodNames.Clear();
            foreach (ConvMethod item in ConvMethods)
            {
                ConvMethodNames.Add(item.Name);
            }
            convMethodBox.DataSource = ConvMethodNames;
        }

        private void convMethodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = convMethodBox.SelectedIndex < 0 ?
                0 : convMethodBox.SelectedIndex;
            gridLength = ConvMethods[index].Kernel.Length;
            colmnNum = (int)Math.Pow(gridLength, 0.5);
            checkDivide.Checked = ConvMethods[index].Divide;
            txtMethodName.Text = ConvMethods[index].Name;
            ReloadGrid();
        }

        private void btnAddConv_Click(object sender, EventArgs e)
        {
            int index = 0;
            int[,] newKernel = new int[colmnNum, colmnNum];

            for (int x = 0; x < colmnNum; x++)
            {
                for (int y = 0; y < colmnNum; y++)
                {
                    NumericUpDown idk = (NumericUpDown)numUDgrid.Controls[index];
                    newKernel[y, x] = Convert.ToInt32(idk.Value);
                    index++; 
                }
            }

            string name = "";
            if (string.IsNullOrWhiteSpace(txtMethodName.Text))
            {
                name = "New custom";
            }
            else name = txtMethodName.Text;

            ConvMethods.Add(new(name, newKernel, checkDivide.Checked));
            ConvMethodNames.Add(name);

            UpdateConvMethods();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ConvMethods.RemoveAt(convMethodBox.SelectedIndex);
            ConvMethodNames.RemoveAt(convMethodBox.SelectedIndex);

            UpdateConvMethods();
        }

        private void btnEditConv_Click(object sender, EventArgs e)
        {
            int index = 0;
            int[,] newKernel = new int[colmnNum, colmnNum];

            for (int x = 0; x < colmnNum; x++)
            {
                for (int y = 0; y < colmnNum; y++)
                {
                    NumericUpDown idk = (NumericUpDown)numUDgrid.Controls[index];
                    newKernel[y, x] = Convert.ToInt32(idk.Value);
                    index++;
                }
            }

            string name = "";
            if (string.IsNullOrWhiteSpace(txtMethodName.Text))
            {
                name = "New custom";
            }
            else name = txtMethodName.Text;

            ConvMethods[convMethodBox.SelectedIndex] = 
                new(name, newKernel, checkDivide.Checked);
            ConvMethodNames[convMethodBox.SelectedIndex] = name;

            UpdateConvMethods();
        }
    }
}
