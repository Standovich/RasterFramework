using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RasterFramework
{
    public partial class HSLcontroller : UserControl
    {
        public HSLcontroller()
        {
            InitializeComponent();
        }

        private void HSLcontroller_Load(object sender, EventArgs e)
        {
            hueBar.Value = 0;
            satBar.Value = 0;
            ligBar.Value = 0;
        }

        public void ResetValues()
        {
            hueBar.Value = 0;
            satBar.Value = 0;
            ligBar.Value = 0;

            txtHueValue.Text = "0°";
            txtLigValue.Text = "0";
            txtSatValue.Text = "0";
        }

        private void hueBar_Scroll(object sender, EventArgs e)
        {
            if(hueBar.Value == 0) txtHueValue.Text = hueBar.Value.ToString() + "°";
            if(hueBar.Value > 0) txtHueValue.Text = "+"+ hueBar.Value.ToString() + "°";
            if(hueBar.Value < 0) txtHueValue.Text = hueBar.Value.ToString() + "°";
        }

        private void satBar_Scroll(object sender, EventArgs e)
        {
            if (satBar.Value == 0) txtSatValue.Text = satBar.Value.ToString();
            if (satBar.Value > 0) txtSatValue.Text = "+" + satBar.Value.ToString();
            if (satBar.Value < 0) txtSatValue.Text = satBar.Value.ToString();
        }

        private void ligBar_Scroll(object sender, EventArgs e)
        {
            if (ligBar.Value == 0) txtLigValue.Text = ligBar.Value.ToString();
            if (ligBar.Value > 0) txtLigValue.Text = "+" + ligBar.Value.ToString();
            if (ligBar.Value < 0) txtLigValue.Text = ligBar.Value.ToString();
        }
    }
}
