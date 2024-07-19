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
            btnApply.Location = new Point(12, 318);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(75, 23);
            btnApply.TabIndex = 4;
            btnApply.Text = "Aplikovat";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(93, 318);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Zrušit";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // kernelGrid
            // 
            kernelGrid.AutoSize = true;
            kernelGrid.ColumnCount = 2;
            kernelGrid.ColumnStyles.Add(new ColumnStyle());
            kernelGrid.ColumnStyles.Add(new ColumnStyle());
            kernelGrid.ColumnStyles.Add(new ColumnStyle());
            kernelGrid.Location = new Point(12, 123);
            kernelGrid.Name = "kernelGrid";
            kernelGrid.RowCount = 3;
            kernelGrid.RowStyles.Add(new RowStyle());
            kernelGrid.RowStyles.Add(new RowStyle());
            kernelGrid.RowStyles.Add(new RowStyle());
            kernelGrid.Size = new Size(0, 0);
            kernelGrid.TabIndex = 7;
            // 
            // ApplyConvolutionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 355);
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
    }
}