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
    public partial class RGBcontroller : UserControl
    {
        public RGBcontroller()
        {
            InitializeComponent();
        }

        private void RGBcontroller_Load(object sender, EventArgs e)
        {
            redBar.Value = 100;
            greenBar.Value = 100;
            blueBar.Value = 100;
        }

        public void ResetValues()
        {
            redBar.Value = 100;
            greenBar.Value = 100;
            blueBar.Value = 100;

            txtRedValue.Text = "100 %";
            txtGreenValue.Text = "100 %";
            txtBlueValue.Text = "100 %";
        }

        private void redBar_Scroll(object sender, EventArgs e)
        {
            txtRedValue.Text = redBar.Value.ToString() + " %";
        }

        private void greenBar_Scroll(object sender, EventArgs e)
        {
            txtGreenValue.Text = greenBar.Value.ToString() + " %";
        }

        private void blueBar_Scroll(object sender, EventArgs e)
        {
            txtBlueValue.Text = blueBar.Value.ToString() + " %";
        }
    }
}
