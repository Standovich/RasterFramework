namespace RasterFramework.Forms
{
    partial class AddCurveForm
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
            lblAlgorithm = new Label();
            lblPoints = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            curveSelectBox = new ComboBox();
            pointsListBox = new ListBox();
            numPointX = new NumericUpDown();
            numPointY = new NumericUpDown();
            lblX = new Label();
            lblY = new Label();
            btnAddPoint = new Button();
            ((System.ComponentModel.ISupportInitialize)numPointX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPointY).BeginInit();
            SuspendLayout();
            // 
            // lblAlgorithm
            // 
            lblAlgorithm.AutoSize = true;
            lblAlgorithm.Location = new Point(12, 9);
            lblAlgorithm.Name = "lblAlgorithm";
            lblAlgorithm.Size = new Size(69, 15);
            lblAlgorithm.TabIndex = 0;
            lblAlgorithm.Text = "Algoritmus:";
            // 
            // lblPoints
            // 
            lblPoints.AutoSize = true;
            lblPoints.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblPoints.Location = new Point(12, 132);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new Size(94, 17);
            lblPoints.TabIndex = 1;
            lblPoints.Text = "Přidané body:";
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(13, 267);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 2;
            btnOK.Text = "Přidat";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(93, 267);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Zrušit";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // curveSelectBox
            // 
            curveSelectBox.FormattingEnabled = true;
            curveSelectBox.Location = new Point(12, 27);
            curveSelectBox.Name = "curveSelectBox";
            curveSelectBox.Size = new Size(121, 23);
            curveSelectBox.TabIndex = 4;
            curveSelectBox.SelectedIndexChanged += curveSelectBox_SelectedIndexChanged;
            // 
            // pointsListBox
            // 
            pointsListBox.FormattingEnabled = true;
            pointsListBox.ItemHeight = 15;
            pointsListBox.Location = new Point(13, 152);
            pointsListBox.Name = "pointsListBox";
            pointsListBox.Size = new Size(155, 109);
            pointsListBox.TabIndex = 5;
            // 
            // numPointX
            // 
            numPointX.Location = new Point(36, 64);
            numPointX.Name = "numPointX";
            numPointX.Size = new Size(55, 23);
            numPointX.TabIndex = 6;
            // 
            // numPointY
            // 
            numPointY.Location = new Point(36, 93);
            numPointY.Name = "numPointY";
            numPointY.Size = new Size(55, 23);
            numPointY.TabIndex = 7;
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblX.Location = new Point(13, 67);
            lblX.Name = "lblX";
            lblX.Size = new Size(21, 17);
            lblX.TabIndex = 8;
            lblX.Text = "X:";
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblY.Location = new Point(14, 96);
            lblY.Name = "lblY";
            lblY.Size = new Size(20, 17);
            lblY.TabIndex = 9;
            lblY.Text = "Y:";
            // 
            // btnAddPoint
            // 
            btnAddPoint.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddPoint.Location = new Point(97, 65);
            btnAddPoint.Name = "btnAddPoint";
            btnAddPoint.Size = new Size(50, 50);
            btnAddPoint.TabIndex = 10;
            btnAddPoint.Text = "+";
            btnAddPoint.UseVisualStyleBackColor = true;
            btnAddPoint.Click += btnAddPoint_Click;
            // 
            // AddCurveForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(183, 301);
            Controls.Add(btnAddPoint);
            Controls.Add(lblY);
            Controls.Add(lblX);
            Controls.Add(numPointY);
            Controls.Add(numPointX);
            Controls.Add(pointsListBox);
            Controls.Add(curveSelectBox);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(lblPoints);
            Controls.Add(lblAlgorithm);
            MinimumSize = new Size(199, 275);
            Name = "AddCurveForm";
            Text = "Křivka";
            Load += AddCurveForm_Load;
            ((System.ComponentModel.ISupportInitialize)numPointX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPointY).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAlgorithm;
        private Label lblPoints;
        private Button btnOK;
        private Button btnCancel;
        private ComboBox curveSelectBox;
        private ListBox pointsListBox;
        private NumericUpDown numPointX;
        private NumericUpDown numPointY;
        private Label lblX;
        private Label lblY;
        private Button btnAddPoint;
    }
}