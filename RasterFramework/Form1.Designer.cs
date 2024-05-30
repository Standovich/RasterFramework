namespace RasterFramework
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSave = new Button();
            imgSelectBox = new ComboBox();
            lblOpenImg = new Label();
            numZoom = new NumericUpDown();
            lblScale = new Label();
            imagePanel = new Panel();
            imageBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)numZoom).BeginInit();
            imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageBox).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(337, 38);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // imgSelectBox
            // 
            imgSelectBox.FormattingEnabled = true;
            imgSelectBox.Items.AddRange(new object[] { "img1", "img2", "img3", "Select custom" });
            imgSelectBox.Location = new Point(12, 38);
            imgSelectBox.Name = "imgSelectBox";
            imgSelectBox.Size = new Size(121, 23);
            imgSelectBox.TabIndex = 3;
            imgSelectBox.SelectedIndexChanged += imgSelectBox_SelectedIndexChanged;
            // 
            // lblOpenImg
            // 
            lblOpenImg.AutoSize = true;
            lblOpenImg.Location = new Point(12, 20);
            lblOpenImg.Name = "lblOpenImg";
            lblOpenImg.Size = new Size(77, 15);
            lblOpenImg.TabIndex = 4;
            lblOpenImg.Text = "Select image:";
            // 
            // numZoom
            // 
            numZoom.Location = new Point(229, 38);
            numZoom.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numZoom.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numZoom.Name = "numZoom";
            numZoom.Size = new Size(49, 23);
            numZoom.TabIndex = 5;
            numZoom.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numZoom.ValueChanged += numZoom_ValueChanged;
            // 
            // lblScale
            // 
            lblScale.AutoSize = true;
            lblScale.Location = new Point(163, 41);
            lblScale.Name = "lblScale";
            lblScale.Size = new Size(60, 15);
            lblScale.TabIndex = 6;
            lblScale.Text = "Zoom (%)";
            // 
            // imagePanel
            // 
            imagePanel.AutoScroll = true;
            imagePanel.Controls.Add(imageBox);
            imagePanel.Location = new Point(9, 67);
            imagePanel.Name = "imagePanel";
            imagePanel.Size = new Size(403, 403);
            imagePanel.TabIndex = 7;
            // 
            // imageBox
            // 
            imageBox.BorderStyle = BorderStyle.FixedSingle;
            imageBox.Location = new Point(0, 0);
            imageBox.Name = "imageBox";
            imageBox.Size = new Size(400, 400);
            imageBox.SizeMode = PictureBoxSizeMode.AutoSize;
            imageBox.TabIndex = 0;
            imageBox.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 486);
            Controls.Add(imagePanel);
            Controls.Add(lblScale);
            Controls.Add(numZoom);
            Controls.Add(lblOpenImg);
            Controls.Add(imgSelectBox);
            Controls.Add(btnSave);
            MinimumSize = new Size(440, 525);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numZoom).EndInit();
            imagePanel.ResumeLayout(false);
            imagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imageBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSave;
        private ComboBox imgSelectBox;
        private Label lblOpenImg;
        private NumericUpDown numZoom;
        private Label lblScale;
        private Panel imagePanel;
        private PictureBox imageBox;
    }
}