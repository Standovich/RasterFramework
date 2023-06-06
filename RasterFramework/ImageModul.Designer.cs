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
            imageBox = new PictureBox();
            txtPictureUI = new Label();
            imgSelectBox = new ComboBox();
            txtConvUI = new Label();
            convolutionBox = new ComboBox();
            checkGray = new CheckBox();
            checkNegative = new CheckBox();
            txtThresholdUI = new Label();
            numThreshold = new NumericUpDown();
            btnRemove = new Button();
            rgBcontroller1 = new RGBcontroller();
            hsLcontroller1 = new HSLcontroller();
            numZoom = new NumericUpDown();
            lblZoomUI = new Label();
            ImagePanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)imageBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numZoom).BeginInit();
            ImagePanel.SuspendLayout();
            SuspendLayout();
            // 
            // imageBox
            // 
            imageBox.BorderStyle = BorderStyle.FixedSingle;
            imageBox.Location = new Point(3, 3);
            imageBox.Name = "imageBox";
            imageBox.Size = new Size(354, 354);
            imageBox.SizeMode = PictureBoxSizeMode.AutoSize;
            imageBox.TabIndex = 0;
            imageBox.TabStop = false;
            // 
            // txtPictureUI
            // 
            txtPictureUI.AutoSize = true;
            txtPictureUI.Location = new Point(2, 6);
            txtPictureUI.Name = "txtPictureUI";
            txtPictureUI.Size = new Size(77, 15);
            txtPictureUI.TabIndex = 1;
            txtPictureUI.Text = "Select image:";
            // 
            // imgSelectBox
            // 
            imgSelectBox.FormattingEnabled = true;
            imgSelectBox.Items.AddRange(new object[] { "img1", "img2", "img3", "Select custom" });
            imgSelectBox.Location = new Point(3, 24);
            imgSelectBox.Name = "imgSelectBox";
            imgSelectBox.Size = new Size(121, 23);
            imgSelectBox.TabIndex = 2;
            imgSelectBox.SelectedIndexChanged += imgSelectBox_SelectedIndexChanged;
            // 
            // txtConvUI
            // 
            txtConvUI.AutoSize = true;
            txtConvUI.Location = new Point(190, 420);
            txtConvUI.Name = "txtConvUI";
            txtConvUI.Size = new Size(121, 15);
            txtConvUI.TabIndex = 5;
            txtConvUI.Text = "Convolution method:";
            // 
            // convolutionBox
            // 
            convolutionBox.FormattingEnabled = true;
            convolutionBox.Location = new Point(190, 438);
            convolutionBox.Name = "convolutionBox";
            convolutionBox.Size = new Size(121, 23);
            convolutionBox.TabIndex = 6;
            convolutionBox.SelectedIndexChanged += convolutionBox_SelectedIndexChanged;
            // 
            // checkGray
            // 
            checkGray.AutoSize = true;
            checkGray.Location = new Point(3, 419);
            checkGray.Name = "checkGray";
            checkGray.Size = new Size(76, 19);
            checkGray.TabIndex = 7;
            checkGray.Text = "Grayscale";
            checkGray.UseVisualStyleBackColor = true;
            checkGray.CheckedChanged += checkGray_CheckedChanged;
            // 
            // checkNegative
            // 
            checkNegative.AutoSize = true;
            checkNegative.Location = new Point(85, 419);
            checkNegative.Name = "checkNegative";
            checkNegative.Size = new Size(73, 19);
            checkNegative.TabIndex = 9;
            checkNegative.Text = "Negative";
            checkNegative.UseVisualStyleBackColor = true;
            checkNegative.CheckedChanged += checkNegative_CheckedChanged;
            // 
            // txtThresholdUI
            // 
            txtThresholdUI.AutoSize = true;
            txtThresholdUI.Location = new Point(190, 471);
            txtThresholdUI.Name = "txtThresholdUI";
            txtThresholdUI.Size = new Size(129, 15);
            txtThresholdUI.TabIndex = 10;
            txtThresholdUI.Text = "Convolution threshold:";
            // 
            // numThreshold
            // 
            numThreshold.Location = new Point(323, 469);
            numThreshold.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numThreshold.Name = "numThreshold";
            numThreshold.Size = new Size(44, 23);
            numThreshold.TabIndex = 11;
            numThreshold.ValueChanged += numThreshold_ValueChanged;
            // 
            // btnRemove
            // 
            btnRemove.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRemove.Location = new Point(528, 3);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(23, 23);
            btnRemove.TabIndex = 14;
            btnRemove.Text = "×";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // rgBcontroller1
            // 
            rgBcontroller1.Location = new Point(369, 238);
            rgBcontroller1.Name = "rgBcontroller1";
            rgBcontroller1.Size = new Size(155, 165);
            rgBcontroller1.TabIndex = 15;
            // 
            // hsLcontroller1
            // 
            hsLcontroller1.Location = new Point(369, 53);
            hsLcontroller1.Name = "hsLcontroller1";
            hsLcontroller1.Size = new Size(155, 165);
            hsLcontroller1.TabIndex = 16;
            // 
            // numZoom
            // 
            numZoom.Location = new Point(237, 25);
            numZoom.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numZoom.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numZoom.Name = "numZoom";
            numZoom.Size = new Size(49, 23);
            numZoom.TabIndex = 17;
            numZoom.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numZoom.ValueChanged += numZoom_ValueChanged;
            // 
            // lblZoomUI
            // 
            lblZoomUI.AutoSize = true;
            lblZoomUI.Location = new Point(174, 27);
            lblZoomUI.Name = "lblZoomUI";
            lblZoomUI.Size = new Size(60, 15);
            lblZoomUI.TabIndex = 18;
            lblZoomUI.Text = "Zoom (%)";
            // 
            // ImagePanel
            // 
            ImagePanel.AutoScroll = true;
            ImagePanel.Controls.Add(imageBox);
            ImagePanel.Location = new Point(3, 53);
            ImagePanel.Name = "ImagePanel";
            ImagePanel.Size = new Size(360, 360);
            ImagePanel.TabIndex = 19;
            // 
            // ImageModul
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(ImagePanel);
            Controls.Add(lblZoomUI);
            Controls.Add(numZoom);
            Controls.Add(hsLcontroller1);
            Controls.Add(rgBcontroller1);
            Controls.Add(btnRemove);
            Controls.Add(numThreshold);
            Controls.Add(txtThresholdUI);
            Controls.Add(checkNegative);
            Controls.Add(checkGray);
            Controls.Add(convolutionBox);
            Controls.Add(txtConvUI);
            Controls.Add(imgSelectBox);
            Controls.Add(txtPictureUI);
            Name = "ImageModul";
            Size = new Size(554, 570);
            Load += ImageModul_Load;
            ((System.ComponentModel.ISupportInitialize)imageBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)numThreshold).EndInit();
            ((System.ComponentModel.ISupportInitialize)numZoom).EndInit();
            ImagePanel.ResumeLayout(false);
            ImagePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox imageBox;
        private Label txtPictureUI;
        private ComboBox imgSelectBox;
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
        private Panel ImagePanel;
    }
}
