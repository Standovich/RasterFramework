namespace RasterFramework.Forms
{
    partial class AddLineForm
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
            btnOK = new Button();
            btnCancel = new Button();
            lineSelectBox = new ComboBox();
            lblLineMethod = new Label();
            lblLineY1 = new Label();
            lblLineY2 = new Label();
            numLineY1 = new NumericUpDown();
            numLineY2 = new NumericUpDown();
            numLineX2 = new NumericUpDown();
            numLineX1 = new NumericUpDown();
            lblLineX2 = new Label();
            lblLineX1 = new Label();
            lblPointA = new Label();
            lblPointB = new Label();
            ((System.ComponentModel.ISupportInitialize)numLineY1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLineY2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLineX2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLineX1).BeginInit();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(12, 155);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 0;
            btnOK.Text = "Potvrdit";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(118, 155);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Zrušit";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lineSelectBox
            // 
            lineSelectBox.FormattingEnabled = true;
            lineSelectBox.Location = new Point(12, 27);
            lineSelectBox.Name = "lineSelectBox";
            lineSelectBox.Size = new Size(121, 23);
            lineSelectBox.TabIndex = 2;
            // 
            // lblLineMethod
            // 
            lblLineMethod.AutoSize = true;
            lblLineMethod.Location = new Point(12, 9);
            lblLineMethod.Name = "lblLineMethod";
            lblLineMethod.Size = new Size(69, 15);
            lblLineMethod.TabIndex = 3;
            lblLineMethod.Text = "Algoritmus:";
            // 
            // lblLineY1
            // 
            lblLineY1.AutoSize = true;
            lblLineY1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblLineY1.Location = new Point(12, 115);
            lblLineY1.Name = "lblLineY1";
            lblLineY1.Size = new Size(20, 17);
            lblLineY1.TabIndex = 4;
            lblLineY1.Text = "Y:";
            // 
            // lblLineY2
            // 
            lblLineY2.AutoSize = true;
            lblLineY2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblLineY2.Location = new Point(112, 115);
            lblLineY2.Name = "lblLineY2";
            lblLineY2.Size = new Size(20, 17);
            lblLineY2.TabIndex = 5;
            lblLineY2.Text = "Y:";
            // 
            // numLineY1
            // 
            numLineY1.Location = new Point(39, 115);
            numLineY1.Name = "numLineY1";
            numLineY1.Size = new Size(55, 23);
            numLineY1.TabIndex = 6;
            // 
            // numLineY2
            // 
            numLineY2.Location = new Point(138, 115);
            numLineY2.Name = "numLineY2";
            numLineY2.Size = new Size(55, 23);
            numLineY2.TabIndex = 7;
            // 
            // numLineX2
            // 
            numLineX2.Location = new Point(138, 86);
            numLineX2.Name = "numLineX2";
            numLineX2.Size = new Size(55, 23);
            numLineX2.TabIndex = 11;
            // 
            // numLineX1
            // 
            numLineX1.Location = new Point(39, 86);
            numLineX1.Name = "numLineX1";
            numLineX1.Size = new Size(55, 23);
            numLineX1.TabIndex = 10;
            // 
            // lblLineX2
            // 
            lblLineX2.AutoSize = true;
            lblLineX2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblLineX2.Location = new Point(112, 86);
            lblLineX2.Name = "lblLineX2";
            lblLineX2.Size = new Size(21, 17);
            lblLineX2.TabIndex = 9;
            lblLineX2.Text = "X:";
            // 
            // lblLineX1
            // 
            lblLineX1.AutoSize = true;
            lblLineX1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblLineX1.Location = new Point(12, 86);
            lblLineX1.Name = "lblLineX1";
            lblLineX1.Size = new Size(21, 17);
            lblLineX1.TabIndex = 8;
            lblLineX1.Text = "X:";
            // 
            // lblPointA
            // 
            lblPointA.AutoSize = true;
            lblPointA.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblPointA.Location = new Point(12, 69);
            lblPointA.Name = "lblPointA";
            lblPointA.Size = new Size(49, 17);
            lblPointA.TabIndex = 12;
            lblPointA.Text = "Bod A:";
            // 
            // lblPointB
            // 
            lblPointB.AutoSize = true;
            lblPointB.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblPointB.Location = new Point(112, 69);
            lblPointB.Name = "lblPointB";
            lblPointB.Size = new Size(48, 17);
            lblPointB.TabIndex = 13;
            lblPointB.Text = "Bod B:";
            // 
            // AddLineForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(205, 189);
            Controls.Add(lblPointB);
            Controls.Add(lblPointA);
            Controls.Add(numLineX2);
            Controls.Add(numLineX1);
            Controls.Add(lblLineX2);
            Controls.Add(lblLineX1);
            Controls.Add(numLineY2);
            Controls.Add(numLineY1);
            Controls.Add(lblLineY2);
            Controls.Add(lblLineY1);
            Controls.Add(lblLineMethod);
            Controls.Add(lineSelectBox);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Name = "AddLineForm";
            Text = "Přidat úsečku";
            Load += AddLineForm_Load;
            ((System.ComponentModel.ISupportInitialize)numLineY1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLineY2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLineX2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLineX1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOK;
        private Button btnCancel;
        private ComboBox lineSelectBox;
        private Label lblLineMethod;
        private Label lblLineY1;
        private Label lblLineY2;
        private NumericUpDown numLineY1;
        private NumericUpDown numLineY2;
        private NumericUpDown numLineX2;
        private NumericUpDown numLineX1;
        private Label lblLineX2;
        private Label lblLineX1;
        private Label lblPointA;
        private Label lblPointB;
    }
}