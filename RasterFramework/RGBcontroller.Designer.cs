namespace RasterFramework
{
    partial class RGBcontroller
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
            this.txtRed = new System.Windows.Forms.Label();
            this.redBar = new System.Windows.Forms.TrackBar();
            this.txtGreen = new System.Windows.Forms.Label();
            this.greenBar = new System.Windows.Forms.TrackBar();
            this.txtBlue = new System.Windows.Forms.Label();
            this.blueBar = new System.Windows.Forms.TrackBar();
            this.txtRedValue = new System.Windows.Forms.Label();
            this.txtGreenValue = new System.Windows.Forms.Label();
            this.txtBlueValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.redBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueBar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRed
            // 
            this.txtRed.AutoSize = true;
            this.txtRed.Location = new System.Drawing.Point(3, 3);
            this.txtRed.Name = "txtRed";
            this.txtRed.Size = new System.Drawing.Size(75, 15);
            this.txtRed.TabIndex = 0;
            this.txtRed.Text = "Red channel:";
            // 
            // redBar
            // 
            this.redBar.Location = new System.Drawing.Point(3, 21);
            this.redBar.Maximum = 200;
            this.redBar.Name = "redBar";
            this.redBar.Size = new System.Drawing.Size(148, 45);
            this.redBar.TabIndex = 1;
            this.redBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.redBar.Scroll += new System.EventHandler(this.redBar_Scroll);
            // 
            // txtGreen
            // 
            this.txtGreen.AutoSize = true;
            this.txtGreen.Location = new System.Drawing.Point(3, 54);
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.Size = new System.Drawing.Size(86, 15);
            this.txtGreen.TabIndex = 2;
            this.txtGreen.Text = "Green channel:";
            // 
            // greenBar
            // 
            this.greenBar.Location = new System.Drawing.Point(3, 72);
            this.greenBar.Maximum = 200;
            this.greenBar.Name = "greenBar";
            this.greenBar.Size = new System.Drawing.Size(148, 45);
            this.greenBar.TabIndex = 3;
            this.greenBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.greenBar.Scroll += new System.EventHandler(this.greenBar_Scroll);
            // 
            // txtBlue
            // 
            this.txtBlue.AutoSize = true;
            this.txtBlue.Location = new System.Drawing.Point(3, 107);
            this.txtBlue.Name = "txtBlue";
            this.txtBlue.Size = new System.Drawing.Size(78, 15);
            this.txtBlue.TabIndex = 4;
            this.txtBlue.Text = "Blue channel:";
            // 
            // blueBar
            // 
            this.blueBar.Location = new System.Drawing.Point(3, 125);
            this.blueBar.Maximum = 200;
            this.blueBar.Name = "blueBar";
            this.blueBar.Size = new System.Drawing.Size(148, 45);
            this.blueBar.TabIndex = 5;
            this.blueBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.blueBar.Scroll += new System.EventHandler(this.blueBar_Scroll);
            // 
            // txtRedValue
            // 
            this.txtRedValue.Location = new System.Drawing.Point(113, 3);
            this.txtRedValue.Name = "txtRedValue";
            this.txtRedValue.Size = new System.Drawing.Size(38, 15);
            this.txtRedValue.TabIndex = 6;
            this.txtRedValue.Text = "100 %";
            this.txtRedValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGreenValue
            // 
            this.txtGreenValue.Location = new System.Drawing.Point(113, 54);
            this.txtGreenValue.Name = "txtGreenValue";
            this.txtGreenValue.Size = new System.Drawing.Size(38, 15);
            this.txtGreenValue.TabIndex = 7;
            this.txtGreenValue.Text = "100 %";
            this.txtGreenValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBlueValue
            // 
            this.txtBlueValue.Location = new System.Drawing.Point(113, 107);
            this.txtBlueValue.Name = "txtBlueValue";
            this.txtBlueValue.Size = new System.Drawing.Size(38, 15);
            this.txtBlueValue.TabIndex = 8;
            this.txtBlueValue.Text = "100 %";
            this.txtBlueValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RGBcontroller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBlueValue);
            this.Controls.Add(this.txtGreenValue);
            this.Controls.Add(this.txtRedValue);
            this.Controls.Add(this.blueBar);
            this.Controls.Add(this.txtBlue);
            this.Controls.Add(this.greenBar);
            this.Controls.Add(this.txtGreen);
            this.Controls.Add(this.redBar);
            this.Controls.Add(this.txtRed);
            this.Name = "RGBcontroller";
            this.Size = new System.Drawing.Size(155, 165);
            this.Load += new System.EventHandler(this.RGBcontroller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.redBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label txtRed;
        private TrackBar redBar;
        private Label txtGreen;
        private TrackBar greenBar;
        private Label txtBlue;
        private TrackBar blueBar;
        private Label txtRedValue;
        private Label txtGreenValue;
        private Label txtBlueValue;
    }
}
