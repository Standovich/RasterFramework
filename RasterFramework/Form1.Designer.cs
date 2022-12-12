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
            this.flPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddModul = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flPanel
            // 
            this.flPanel.AutoScroll = true;
            this.flPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flPanel.Location = new System.Drawing.Point(0, 0);
            this.flPanel.Name = "flPanel";
            this.flPanel.Padding = new System.Windows.Forms.Padding(0, 64, 0, 0);
            this.flPanel.Size = new System.Drawing.Size(634, 721);
            this.flPanel.TabIndex = 0;
            // 
            // btnAddModul
            // 
            this.btnAddModul.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddModul.Location = new System.Drawing.Point(12, 12);
            this.btnAddModul.Name = "btnAddModul";
            this.btnAddModul.Size = new System.Drawing.Size(40, 40);
            this.btnAddModul.TabIndex = 1;
            this.btnAddModul.Text = "+";
            this.btnAddModul.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddModul.UseVisualStyleBackColor = true;
            this.btnAddModul.Click += new System.EventHandler(this.btnAddModul_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 721);
            this.Controls.Add(this.btnAddModul);
            this.Controls.Add(this.flPanel);
            this.MinimumSize = new System.Drawing.Size(600, 760);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flPanel;
        private Button btnAddModul;
    }
}