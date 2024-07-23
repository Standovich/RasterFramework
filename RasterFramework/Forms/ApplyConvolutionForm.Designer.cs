namespace RasterFramework.Forms
{
    partial class ApplyConvolutionForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMethod = new Label();
            methodSelectBox = new ComboBox();
            lblKernel = new Label();
            kernelSelectBox = new ComboBox();
            btnApply = new Button();
            btnCancel = new Button();
            numGridSize = new NumericUpDown();
            lblGridSize = new Label();
            kernelGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)numGridSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kernelGrid).BeginInit();
            SuspendLayout();
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Location = new Point(12, 9);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(51, 15);
            lblMethod.TabIndex = 0;
            lblMethod.Text = "Metoda:";
            // 
            // methodSelectBox
            // 
            methodSelectBox.FormattingEnabled = true;
            methodSelectBox.Location = new Point(12, 27);
            methodSelectBox.Name = "methodSelectBox";
            methodSelectBox.Size = new Size(121, 23);
            methodSelectBox.TabIndex = 1;
            methodSelectBox.SelectedIndexChanged += methodSelectBox_SelectedIndexChanged;
            // 
            // lblKernel
            // 
            lblKernel.AutoSize = true;
            lblKernel.Location = new Point(12, 65);
            lblKernel.Name = "lblKernel";
            lblKernel.Size = new Size(46, 15);
            lblKernel.TabIndex = 2;
            lblKernel.Text = "Matice:";
            // 
            // kernelSelectBox
            // 
            kernelSelectBox.FormattingEnabled = true;
            kernelSelectBox.Location = new Point(12, 83);
            kernelSelectBox.Name = "kernelSelectBox";
            kernelSelectBox.Size = new Size(121, 23);
            kernelSelectBox.TabIndex = 3;
            kernelSelectBox.SelectedIndexChanged += kernelSelectBox_SelectedIndexChanged;
            // 
            // btnApply
            // 
            btnApply.DialogResult = DialogResult.OK;
            btnApply.Location = new Point(12, 404);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(75, 23);
            btnApply.TabIndex = 4;
            btnApply.Text = "Aplikovat";
            btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(93, 404);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Zrušit";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // numGridSize
            // 
            numGridSize.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            numGridSize.Location = new Point(128, 129);
            numGridSize.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            numGridSize.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numGridSize.Name = "numGridSize";
            numGridSize.Size = new Size(40, 23);
            numGridSize.TabIndex = 7;
            numGridSize.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numGridSize.ValueChanged += numGridSize_ValueChanged;
            // 
            // lblGridSize
            // 
            lblGridSize.AutoSize = true;
            lblGridSize.Location = new Point(12, 131);
            lblGridSize.Name = "lblGridSize";
            lblGridSize.Size = new Size(110, 15);
            lblGridSize.TabIndex = 9;
            lblGridSize.Text = "Velikost matice (x²):";
            // 
            // kernelGrid
            // 
            kernelGrid.AllowUserToAddRows = false;
            kernelGrid.AllowUserToDeleteRows = false;
            kernelGrid.AllowUserToResizeColumns = false;
            kernelGrid.AllowUserToResizeRows = false;
            kernelGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            kernelGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            kernelGrid.ColumnHeadersVisible = false;
            kernelGrid.Location = new Point(12, 158);
            kernelGrid.Name = "kernelGrid";
            kernelGrid.RowHeadersVisible = false;
            kernelGrid.RowTemplate.Height = 25;
            kernelGrid.Size = new Size(240, 240);
            kernelGrid.TabIndex = 10;
            kernelGrid.CellValueChanged += kernelGrid_CellValueChanged;
            // 
            // ApplyConvolutionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 436);
            Controls.Add(kernelGrid);
            Controls.Add(lblGridSize);
            Controls.Add(numGridSize);
            Controls.Add(btnCancel);
            Controls.Add(btnApply);
            Controls.Add(kernelSelectBox);
            Controls.Add(lblKernel);
            Controls.Add(methodSelectBox);
            Controls.Add(lblMethod);
            Name = "ApplyConvolutionForm";
            Text = "Konvoluce";
            Load += ApplyConvolutionForm_Load;
            ((System.ComponentModel.ISupportInitialize)numGridSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)kernelGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMethod;
        private ComboBox methodSelectBox;
        private Label lblKernel;
        private ComboBox kernelSelectBox;
        private Button btnApply;
        private Button btnCancel;
        private NumericUpDown numGridSize;
        private NumericUpDown numColumn;
        private Label lblGridSize;
        private Label lblColumn;
        private DataGridView kernelGrid;
    }
}