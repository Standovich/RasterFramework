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
            kernelGrid = new TableLayoutPanel();
            numRow = new NumericUpDown();
            numColumn = new NumericUpDown();
            lblRows = new Label();
            lblColumn = new Label();
            ((System.ComponentModel.ISupportInitialize)numRow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numColumn).BeginInit();
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
            // 
            // btnApply
            // 
            btnApply.DialogResult = DialogResult.OK;
            btnApply.Location = new Point(12, 368);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(75, 23);
            btnApply.TabIndex = 4;
            btnApply.Text = "Aplikovat";
            btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(93, 368);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Zrušit";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // kernelGrid
            // 
            kernelGrid.ColumnCount = 2;
            kernelGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            kernelGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            kernelGrid.Location = new Point(12, 162);
            kernelGrid.Name = "kernelGrid";
            kernelGrid.RowCount = 2;
            kernelGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            kernelGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            kernelGrid.Size = new Size(200, 200);
            kernelGrid.TabIndex = 6;
            // 
            // numRow
            // 
            numRow.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            numRow.Location = new Point(60, 129);
            numRow.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            numRow.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numRow.Name = "numRow";
            numRow.Size = new Size(40, 23);
            numRow.TabIndex = 7;
            numRow.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // numColumn
            // 
            numColumn.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            numColumn.Location = new Point(169, 129);
            numColumn.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            numColumn.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numColumn.Name = "numColumn";
            numColumn.Size = new Size(40, 23);
            numColumn.TabIndex = 8;
            numColumn.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblRows
            // 
            lblRows.AutoSize = true;
            lblRows.Location = new Point(12, 131);
            lblRows.Name = "lblRows";
            lblRows.Size = new Size(42, 15);
            lblRows.TabIndex = 9;
            lblRows.Text = "Řádky:";
            // 
            // lblColumn
            // 
            lblColumn.AutoSize = true;
            lblColumn.Location = new Point(113, 131);
            lblColumn.Name = "lblColumn";
            lblColumn.Size = new Size(52, 15);
            lblColumn.TabIndex = 10;
            lblColumn.Text = "Sloupce:";
            // 
            // ApplyConvolutionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 409);
            Controls.Add(lblColumn);
            Controls.Add(lblRows);
            Controls.Add(numColumn);
            Controls.Add(numRow);
            Controls.Add(kernelGrid);
            Controls.Add(btnCancel);
            Controls.Add(btnApply);
            Controls.Add(kernelSelectBox);
            Controls.Add(lblKernel);
            Controls.Add(methodSelectBox);
            Controls.Add(lblMethod);
            Name = "ApplyConvolutionForm";
            Text = "Konvoluce";
            Load += ApplyConvolutionForm_Load;
            ((System.ComponentModel.ISupportInitialize)numRow).EndInit();
            ((System.ComponentModel.ISupportInitialize)numColumn).EndInit();
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
        private TableLayoutPanel kernelGrid;
        private NumericUpDown numRow;
        private NumericUpDown numColumn;
        private Label lblRows;
        private Label lblColumn;
    }
}