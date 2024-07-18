namespace RasterFramework.Forms
{
    partial class PointUControl
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
            lblX = new Label();
            lblY = new Label();
            numX = new NumericUpDown();
            numY = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numY).BeginInit();
            SuspendLayout();
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.Location = new Point(14, 5);
            lblX.Name = "lblX";
            lblX.Size = new Size(17, 15);
            lblX.TabIndex = 0;
            lblX.Text = "X:";
            lblX.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new Point(113, 5);
            lblY.Name = "lblY";
            lblY.Size = new Size(17, 15);
            lblY.TabIndex = 1;
            lblY.Text = "Y:";
            lblY.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numX
            // 
            numX.Location = new Point(37, 3);
            numX.Name = "numX";
            numX.Size = new Size(55, 23);
            numX.TabIndex = 2;
            // 
            // numY
            // 
            numY.Location = new Point(136, 3);
            numY.Name = "numY";
            numY.Size = new Size(55, 23);
            numY.TabIndex = 3;
            // 
            // PointUControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numY);
            Controls.Add(numX);
            Controls.Add(lblY);
            Controls.Add(lblX);
            Name = "PointUControl";
            Size = new Size(194, 29);
            ((System.ComponentModel.ISupportInitialize)numX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numY).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblX;
        private Label lblY;
        private NumericUpDown numX;
        private NumericUpDown numY;
    }
}
