namespace RasterFramework
{
    partial class RasterFramework
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
            btnNewInstance = new Button();
            canvasSelectBox = new ComboBox();
            lblCanvasSize = new Label();
            btnAddLIne = new Button();
            lblLine = new Label();
            lblCurve = new Label();
            btnAddCurve = new Button();
            fillSelectBox = new ComboBox();
            fillCheckBox = new CheckBox();
            lblFilter = new Label();
            lblDrawing = new Label();
            lblPostProcessing = new Label();
            filterSelectBox = new ComboBox();
            btnApplyFilter = new Button();
            lblConvolution = new Label();
            btnAddConvolution = new Button();
            ((System.ComponentModel.ISupportInitialize)numZoom).BeginInit();
            imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageBox).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(472, 38);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Uložit";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // imgSelectBox
            // 
            imgSelectBox.FormattingEnabled = true;
            imgSelectBox.Items.AddRange(new object[] { "Obrázek1", "Obrázek2", "Obrázek3", "Vlastní obrázek" });
            imgSelectBox.Location = new Point(9, 38);
            imgSelectBox.Name = "imgSelectBox";
            imgSelectBox.Size = new Size(121, 23);
            imgSelectBox.TabIndex = 3;
            imgSelectBox.SelectedIndexChanged += imgSelectBox_SelectedIndexChanged;
            // 
            // lblOpenImg
            // 
            lblOpenImg.AutoSize = true;
            lblOpenImg.Location = new Point(9, 20);
            lblOpenImg.Name = "lblOpenImg";
            lblOpenImg.Size = new Size(88, 15);
            lblOpenImg.TabIndex = 4;
            lblOpenImg.Text = "Vybrat obrázek:";
            // 
            // numZoom
            // 
            numZoom.Location = new Point(147, 38);
            numZoom.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numZoom.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numZoom.Name = "numZoom";
            numZoom.Size = new Size(49, 23);
            numZoom.TabIndex = 5;
            numZoom.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numZoom.ValueChanged += numZoom_ValueChanged;
            // 
            // lblScale
            // 
            lblScale.AutoSize = true;
            lblScale.Location = new Point(147, 20);
            lblScale.Name = "lblScale";
            lblScale.Size = new Size(54, 15);
            lblScale.TabIndex = 6;
            lblScale.Text = "Zvětšení:";
            // 
            // imagePanel
            // 
            imagePanel.AutoScroll = true;
            imagePanel.Controls.Add(imageBox);
            imagePanel.Location = new Point(147, 67);
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
            // btnNewInstance
            // 
            btnNewInstance.Location = new Point(358, 38);
            btnNewInstance.Name = "btnNewInstance";
            btnNewInstance.Size = new Size(77, 23);
            btnNewInstance.TabIndex = 8;
            btnNewInstance.Text = "Přidat okno";
            btnNewInstance.UseVisualStyleBackColor = true;
            btnNewInstance.Click += btnNewInstance_Click;
            // 
            // canvasSelectBox
            // 
            canvasSelectBox.FormattingEnabled = true;
            canvasSelectBox.Items.AddRange(new object[] { "400x400", "1280x720" });
            canvasSelectBox.Location = new Point(218, 38);
            canvasSelectBox.Name = "canvasSelectBox";
            canvasSelectBox.Size = new Size(121, 23);
            canvasSelectBox.TabIndex = 9;
            canvasSelectBox.SelectedIndexChanged += canvasSelectBox_SelectedIndexChanged;
            // 
            // lblCanvasSize
            // 
            lblCanvasSize.AutoSize = true;
            lblCanvasSize.Location = new Point(218, 20);
            lblCanvasSize.Name = "lblCanvasSize";
            lblCanvasSize.Size = new Size(110, 15);
            lblCanvasSize.TabIndex = 10;
            lblCanvasSize.Text = "Velikost plátna (px):";
            // 
            // btnAddLIne
            // 
            btnAddLIne.Location = new Point(9, 118);
            btnAddLIne.Name = "btnAddLIne";
            btnAddLIne.Size = new Size(75, 23);
            btnAddLIne.TabIndex = 11;
            btnAddLIne.Text = "Přidat";
            btnAddLIne.UseVisualStyleBackColor = true;
            btnAddLIne.Click += btnAddLIne_Click;
            // 
            // lblLine
            // 
            lblLine.AutoSize = true;
            lblLine.Location = new Point(9, 100);
            lblLine.Name = "lblLine";
            lblLine.Size = new Size(47, 15);
            lblLine.TabIndex = 12;
            lblLine.Text = "Úsečky:";
            // 
            // lblCurve
            // 
            lblCurve.AutoSize = true;
            lblCurve.Location = new Point(9, 153);
            lblCurve.Name = "lblCurve";
            lblCurve.Size = new Size(42, 15);
            lblCurve.TabIndex = 13;
            lblCurve.Text = "Křivky:";
            // 
            // btnAddCurve
            // 
            btnAddCurve.Location = new Point(9, 171);
            btnAddCurve.Name = "btnAddCurve";
            btnAddCurve.Size = new Size(75, 23);
            btnAddCurve.TabIndex = 14;
            btnAddCurve.Text = "Přidat";
            btnAddCurve.UseVisualStyleBackColor = true;
            btnAddCurve.Click += btnAddCurve_Click;
            // 
            // fillSelectBox
            // 
            fillSelectBox.FormattingEnabled = true;
            fillSelectBox.Location = new Point(9, 235);
            fillSelectBox.Name = "fillSelectBox";
            fillSelectBox.Size = new Size(96, 23);
            fillSelectBox.TabIndex = 16;
            fillSelectBox.SelectedIndexChanged += fillSelectBox_SelectedIndexChanged;
            // 
            // fillCheckBox
            // 
            fillCheckBox.AutoSize = true;
            fillCheckBox.Location = new Point(9, 210);
            fillCheckBox.Name = "fillCheckBox";
            fillCheckBox.Size = new Size(59, 19);
            fillCheckBox.TabIndex = 17;
            fillCheckBox.Text = "Výplň:";
            fillCheckBox.UseVisualStyleBackColor = true;
            fillCheckBox.CheckedChanged += fillCheckBox_CheckedChanged;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(12, 295);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(30, 15);
            lblFilter.TabIndex = 18;
            lblFilter.Text = "Filtr:";
            // 
            // lblDrawing
            // 
            lblDrawing.AutoSize = true;
            lblDrawing.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDrawing.Location = new Point(9, 80);
            lblDrawing.Name = "lblDrawing";
            lblDrawing.Size = new Size(81, 15);
            lblDrawing.TabIndex = 19;
            lblDrawing.Text = "Vykreslování:";
            // 
            // lblPostProcessing
            // 
            lblPostProcessing.AutoSize = true;
            lblPostProcessing.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPostProcessing.Location = new Point(9, 276);
            lblPostProcessing.Name = "lblPostProcessing";
            lblPostProcessing.Size = new Size(112, 15);
            lblPostProcessing.TabIndex = 20;
            lblPostProcessing.Text = "Zpracování obrazu:";
            // 
            // filterSelectBox
            // 
            filterSelectBox.FormattingEnabled = true;
            filterSelectBox.Location = new Point(9, 313);
            filterSelectBox.Name = "filterSelectBox";
            filterSelectBox.Size = new Size(96, 23);
            filterSelectBox.TabIndex = 21;
            filterSelectBox.SelectedIndexChanged += filterSelectBox_SelectedIndexChanged;
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.Location = new Point(9, 342);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(75, 23);
            btnApplyFilter.TabIndex = 22;
            btnApplyFilter.Text = "Aplikovat";
            btnApplyFilter.UseVisualStyleBackColor = true;
            btnApplyFilter.Click += btnApplyFilter_Click;
            // 
            // lblConvolution
            // 
            lblConvolution.AutoSize = true;
            lblConvolution.Location = new Point(12, 378);
            lblConvolution.Name = "lblConvolution";
            lblConvolution.Size = new Size(66, 15);
            lblConvolution.TabIndex = 23;
            lblConvolution.Text = "Konvoluce:";
            // 
            // btnAddConvolution
            // 
            btnAddConvolution.Location = new Point(9, 396);
            btnAddConvolution.Name = "btnAddConvolution";
            btnAddConvolution.Size = new Size(75, 23);
            btnAddConvolution.TabIndex = 24;
            btnAddConvolution.Text = "Aplikovat";
            btnAddConvolution.UseVisualStyleBackColor = true;
            btnAddConvolution.Click += btnAddConvolution_Click;
            // 
            // RasterFramework
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 486);
            Controls.Add(btnAddConvolution);
            Controls.Add(lblConvolution);
            Controls.Add(btnApplyFilter);
            Controls.Add(filterSelectBox);
            Controls.Add(lblPostProcessing);
            Controls.Add(lblDrawing);
            Controls.Add(lblFilter);
            Controls.Add(fillCheckBox);
            Controls.Add(fillSelectBox);
            Controls.Add(btnAddCurve);
            Controls.Add(lblCurve);
            Controls.Add(lblLine);
            Controls.Add(btnAddLIne);
            Controls.Add(lblCanvasSize);
            Controls.Add(canvasSelectBox);
            Controls.Add(btnNewInstance);
            Controls.Add(imagePanel);
            Controls.Add(lblScale);
            Controls.Add(numZoom);
            Controls.Add(lblOpenImg);
            Controls.Add(imgSelectBox);
            Controls.Add(btnSave);
            MinimumSize = new Size(580, 525);
            Name = "RasterFramework";
            Text = "RasterFramework";
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
        private Button btnNewInstance;
        private ComboBox canvasSelectBox;
        private Label lblCanvasSize;
        private Button btnAddLIne;
        private Label lblLine;
        private Label lblCurve;
        private Button btnAddCurve;
        private ComboBox fillSelectBox;
        private CheckBox fillCheckBox;
        private Label lblFilter;
        private Label lblDrawing;
        private Label lblPostProcessing;
        private ComboBox filterSelectBox;
        private Button btnApplyFilter;
        private Label lblConvolution;
        private Button btnAddConvolution;
    }
}