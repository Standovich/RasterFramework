namespace RasterFramework
{
    partial class HSLcontroller
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLigValue = new System.Windows.Forms.Label();
            this.txtSatValue = new System.Windows.Forms.Label();
            this.txtHueValue = new System.Windows.Forms.Label();
            this.ligBar = new System.Windows.Forms.TrackBar();
            this.txtLightness = new System.Windows.Forms.Label();
            this.satBar = new System.Windows.Forms.TrackBar();
            this.txtSaturation = new System.Windows.Forms.Label();
            this.hueBar = new System.Windows.Forms.TrackBar();
            this.txtHue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ligBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.satBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueBar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLigValue
            // 
            this.txtLigValue.Location = new System.Drawing.Point(113, 107);
            this.txtLigValue.Name = "txtLigValue";
            this.txtLigValue.Size = new System.Drawing.Size(38, 15);
            this.txtLigValue.TabIndex = 17;
            this.txtLigValue.Text = "0";
            this.txtLigValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSatValue
            // 
            this.txtSatValue.Location = new System.Drawing.Point(113, 54);
            this.txtSatValue.Name = "txtSatValue";
            this.txtSatValue.Size = new System.Drawing.Size(38, 15);
            this.txtSatValue.TabIndex = 16;
            this.txtSatValue.Text = "0";
            this.txtSatValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHueValue
            // 
            this.txtHueValue.Location = new System.Drawing.Point(96, 3);
            this.txtHueValue.Name = "txtHueValue";
            this.txtHueValue.Size = new System.Drawing.Size(55, 15);
            this.txtHueValue.TabIndex = 15;
            this.txtHueValue.Text = "0°";
            this.txtHueValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ligBar
            // 
            this.ligBar.Location = new System.Drawing.Point(3, 125);
            this.ligBar.Maximum = 50;
            this.ligBar.Minimum = -50;
            this.ligBar.Name = "ligBar";
            this.ligBar.Size = new System.Drawing.Size(148, 45);
            this.ligBar.TabIndex = 14;
            this.ligBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ligBar.Scroll += new System.EventHandler(this.ligBar_Scroll);
            // 
            // txtLightness
            // 
            this.txtLightness.AutoSize = true;
            this.txtLightness.Location = new System.Drawing.Point(3, 107);
            this.txtLightness.Name = "txtLightness";
            this.txtLightness.Size = new System.Drawing.Size(60, 15);
            this.txtLightness.TabIndex = 13;
            this.txtLightness.Text = "Lightness:";
            // 
            // satBar
            // 
            this.satBar.Location = new System.Drawing.Point(3, 72);
            this.satBar.Maximum = 50;
            this.satBar.Minimum = -50;
            this.satBar.Name = "satBar";
            this.satBar.Size = new System.Drawing.Size(148, 45);
            this.satBar.TabIndex = 12;
            this.satBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.satBar.Scroll += new System.EventHandler(this.satBar_Scroll);
            // 
            // txtSaturation
            // 
            this.txtSaturation.AutoSize = true;
            this.txtSaturation.Location = new System.Drawing.Point(3, 54);
            this.txtSaturation.Name = "txtSaturation";
            this.txtSaturation.Size = new System.Drawing.Size(64, 15);
            this.txtSaturation.TabIndex = 11;
            this.txtSaturation.Text = "Saturation:";
            // 
            // hueBar
            // 
            this.hueBar.Location = new System.Drawing.Point(3, 21);
            this.hueBar.Maximum = 180;
            this.hueBar.Minimum = -180;
            this.hueBar.Name = "hueBar";
            this.hueBar.Size = new System.Drawing.Size(148, 45);
            this.hueBar.TabIndex = 10;
            this.hueBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.hueBar.Scroll += new System.EventHandler(this.hueBar_Scroll);
            // 
            // txtHue
            // 
            this.txtHue.AutoSize = true;
            this.txtHue.Location = new System.Drawing.Point(3, 3);
            this.txtHue.Name = "txtHue";
            this.txtHue.Size = new System.Drawing.Size(32, 15);
            this.txtHue.TabIndex = 9;
            this.txtHue.Text = "Hue:";
            // 
            // HSLcontroller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLigValue);
            this.Controls.Add(this.txtSatValue);
            this.Controls.Add(this.txtHueValue);
            this.Controls.Add(this.ligBar);
            this.Controls.Add(this.txtLightness);
            this.Controls.Add(this.satBar);
            this.Controls.Add(this.txtSaturation);
            this.Controls.Add(this.hueBar);
            this.Controls.Add(this.txtHue);
            this.Name = "HSLcontroller";
            this.Size = new System.Drawing.Size(155, 165);
            this.Load += new System.EventHandler(this.HSLcontroller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ligBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.satBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label txtLigValue;
        private Label txtSatValue;
        private Label txtHueValue;
        private TrackBar ligBar;
        private Label txtLightness;
        private TrackBar satBar;
        private Label txtSaturation;
        private TrackBar hueBar;
        private Label txtHue;
    }
}
