namespace RasterFramework
{
    partial class ImageModul
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
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.txtPictureUI = new System.Windows.Forms.Label();
            this.imgSelectBox = new System.Windows.Forms.ComboBox();
            this.grayScaleBox = new System.Windows.Forms.ComboBox();
            this.txtGrayUI = new System.Windows.Forms.Label();
            this.txtConvUI = new System.Windows.Forms.Label();
            this.convolutionBox = new System.Windows.Forms.ComboBox();
            this.checkGray = new System.Windows.Forms.CheckBox();
            this.checkNegative = new System.Windows.Forms.CheckBox();
            this.txtThresholdUI = new System.Windows.Forms.Label();
            this.numThreshold = new System.Windows.Forms.NumericUpDown();
            this.btnRemove = new System.Windows.Forms.Button();
            this.rgBcontroller1 = new RasterFramework.RGBcontroller();
            this.hsLcontroller1 = new RasterFramework.HSLcontroller();
            this.numZoom = new System.Windows.Forms.NumericUpDown();
            this.lblZoomUI = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox
            // 
            this.imageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox.Location = new System.Drawing.Point(3, 53);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(350, 350);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageBox.TabIndex = 0;
            this.imageBox.TabStop = false;
            // 
            // txtPictureUI
            // 
            this.txtPictureUI.AutoSize = true;
            this.txtPictureUI.Location = new System.Drawing.Point(2, 6);
            this.txtPictureUI.Name = "txtPictureUI";
            this.txtPictureUI.Size = new System.Drawing.Size(77, 15);
            this.txtPictureUI.TabIndex = 1;
            this.txtPictureUI.Text = "Select image:";
            // 
            // imgSelectBox
            // 
            this.imgSelectBox.FormattingEnabled = true;
            this.imgSelectBox.Items.AddRange(new object[] {
            "img1",
            "img2",
            "img3",
            "Select custom"});
            this.imgSelectBox.Location = new System.Drawing.Point(3, 24);
            this.imgSelectBox.Name = "imgSelectBox";
            this.imgSelectBox.Size = new System.Drawing.Size(121, 23);
            this.imgSelectBox.TabIndex = 2;
            this.imgSelectBox.SelectedIndexChanged += new System.EventHandler(this.imgSelectBox_SelectedIndexChanged);
            // 
            // grayScaleBox
            // 
            this.grayScaleBox.FormattingEnabled = true;
            this.grayScaleBox.Items.AddRange(new object[] {
            "Average",
            "Weighted"});
            this.grayScaleBox.Location = new System.Drawing.Point(3, 449);
            this.grayScaleBox.Name = "grayScaleBox";
            this.grayScaleBox.Size = new System.Drawing.Size(105, 23);
            this.grayScaleBox.TabIndex = 3;
            this.grayScaleBox.SelectedIndexChanged += new System.EventHandler(this.grayScaleBox_SelectedIndexChanged);
            // 
            // txtGrayUI
            // 
            this.txtGrayUI.AutoSize = true;
            this.txtGrayUI.Location = new System.Drawing.Point(3, 431);
            this.txtGrayUI.Name = "txtGrayUI";
            this.txtGrayUI.Size = new System.Drawing.Size(105, 15);
            this.txtGrayUI.TabIndex = 4;
            this.txtGrayUI.Text = "Grayscale method:";
            // 
            // txtConvUI
            // 
            this.txtConvUI.AutoSize = true;
            this.txtConvUI.Location = new System.Drawing.Point(190, 410);
            this.txtConvUI.Name = "txtConvUI";
            this.txtConvUI.Size = new System.Drawing.Size(121, 15);
            this.txtConvUI.TabIndex = 5;
            this.txtConvUI.Text = "Convolution method:";
            // 
            // convolutionBox
            // 
            this.convolutionBox.FormattingEnabled = true;
            this.convolutionBox.Items.AddRange(new object[] {
            "Vlastní",
            "Gaussian blur",
            "Box blur",
            "Sharpen"});
            this.convolutionBox.Location = new System.Drawing.Point(190, 428);
            this.convolutionBox.Name = "convolutionBox";
            this.convolutionBox.Size = new System.Drawing.Size(121, 23);
            this.convolutionBox.TabIndex = 6;
            this.convolutionBox.SelectedIndexChanged += new System.EventHandler(this.convolutionBox_SelectedIndexChanged);
            // 
            // checkGray
            // 
            this.checkGray.AutoSize = true;
            this.checkGray.Location = new System.Drawing.Point(3, 409);
            this.checkGray.Name = "checkGray";
            this.checkGray.Size = new System.Drawing.Size(76, 19);
            this.checkGray.TabIndex = 7;
            this.checkGray.Text = "Grayscale";
            this.checkGray.UseVisualStyleBackColor = true;
            this.checkGray.CheckedChanged += new System.EventHandler(this.checkGray_CheckedChanged);
            // 
            // checkNegative
            // 
            this.checkNegative.AutoSize = true;
            this.checkNegative.Location = new System.Drawing.Point(85, 409);
            this.checkNegative.Name = "checkNegative";
            this.checkNegative.Size = new System.Drawing.Size(73, 19);
            this.checkNegative.TabIndex = 9;
            this.checkNegative.Text = "Negative";
            this.checkNegative.UseVisualStyleBackColor = true;
            this.checkNegative.CheckedChanged += new System.EventHandler(this.checkNegative_CheckedChanged);
            // 
            // txtThresholdUI
            // 
            this.txtThresholdUI.AutoSize = true;
            this.txtThresholdUI.Location = new System.Drawing.Point(190, 461);
            this.txtThresholdUI.Name = "txtThresholdUI";
            this.txtThresholdUI.Size = new System.Drawing.Size(129, 15);
            this.txtThresholdUI.TabIndex = 10;
            this.txtThresholdUI.Text = "Convolution threshold:";
            // 
            // numThreshold
            // 
            this.numThreshold.Location = new System.Drawing.Point(323, 459);
            this.numThreshold.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numThreshold.Name = "numThreshold";
            this.numThreshold.Size = new System.Drawing.Size(44, 23);
            this.numThreshold.TabIndex = 11;
            this.numThreshold.ValueChanged += new System.EventHandler(this.numThreshold_ValueChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemove.Location = new System.Drawing.Point(528, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(23, 23);
            this.btnRemove.TabIndex = 14;
            this.btnRemove.Text = "×";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // rgBcontroller1
            // 
            this.rgBcontroller1.Location = new System.Drawing.Point(359, 238);
            this.rgBcontroller1.Name = "rgBcontroller1";
            this.rgBcontroller1.Size = new System.Drawing.Size(155, 165);
            this.rgBcontroller1.TabIndex = 15;
            // 
            // hsLcontroller1
            // 
            this.hsLcontroller1.Location = new System.Drawing.Point(359, 53);
            this.hsLcontroller1.Name = "hsLcontroller1";
            this.hsLcontroller1.Size = new System.Drawing.Size(155, 165);
            this.hsLcontroller1.TabIndex = 16;
            // 
            // numZoom
            // 
            this.numZoom.Location = new System.Drawing.Point(237, 25);
            this.numZoom.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numZoom.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numZoom.Name = "numZoom";
            this.numZoom.Size = new System.Drawing.Size(49, 23);
            this.numZoom.TabIndex = 17;
            this.numZoom.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numZoom.ValueChanged += new System.EventHandler(this.numZoom_ValueChanged);
            // 
            // lblZoomUI
            // 
            this.lblZoomUI.AutoSize = true;
            this.lblZoomUI.Location = new System.Drawing.Point(174, 27);
            this.lblZoomUI.Name = "lblZoomUI";
            this.lblZoomUI.Size = new System.Drawing.Size(60, 15);
            this.lblZoomUI.TabIndex = 18;
            this.lblZoomUI.Text = "Zoom (%)";
            // 
            // ImageModul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.lblZoomUI);
            this.Controls.Add(this.numZoom);
            this.Controls.Add(this.hsLcontroller1);
            this.Controls.Add(this.rgBcontroller1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.numThreshold);
            this.Controls.Add(this.txtThresholdUI);
            this.Controls.Add(this.checkNegative);
            this.Controls.Add(this.checkGray);
            this.Controls.Add(this.convolutionBox);
            this.Controls.Add(this.txtConvUI);
            this.Controls.Add(this.txtGrayUI);
            this.Controls.Add(this.grayScaleBox);
            this.Controls.Add(this.imgSelectBox);
            this.Controls.Add(this.txtPictureUI);
            this.Controls.Add(this.imageBox);
            this.Name = "ImageModul";
            this.Size = new System.Drawing.Size(554, 570);
            this.Load += new System.EventHandler(this.ImageModul_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox imageBox;
        private Label txtPictureUI;
        private ComboBox imgSelectBox;
        private ComboBox grayScaleBox;
        private Label txtGrayUI;
        private Label txtConvUI;
        private ComboBox convolutionBox;
        private CheckBox checkGray;
        private CheckBox checkNegative;
        private Label txtThresholdUI;
        private NumericUpDown numThreshold;
        private Button btnRemove;
        private RGBcontroller rgBcontroller1;
        private HSLcontroller hsLcontroller1;
        private NumericUpDown numZoom;
        private Label lblZoomUI;
    }
}
