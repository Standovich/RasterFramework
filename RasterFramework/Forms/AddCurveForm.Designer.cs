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
            lblPoints.Location = new Point(12, 64);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new Size(43, 17);
            lblPoints.TabIndex = 1;
            lblPoints.Text = "Body:";
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(12, 235);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 2;
            btnOK.Text = "Přidat";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(110, 235);
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
            // 
            // AddCurveForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(229, 275);
            Controls.Add(curveSelectBox);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(lblPoints);
            Controls.Add(lblAlgorithm);
            Name = "AddCurveForm";
            Text = "Křivka";
            Load += AddCurveForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAlgorithm;
        private Label lblPoints;
        private Button btnOK;
        private Button btnCancel;
        private ComboBox curveSelectBox;
    }
}