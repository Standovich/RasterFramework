namespace RasterFramework
{
    partial class ConvEditor
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numUDgrid = new System.Windows.Forms.FlowLayoutPanel();
            this.convMethodBox = new System.Windows.Forms.ComboBox();
            this.btnAddConv = new System.Windows.Forms.Button();
            this.txtMethodName = new System.Windows.Forms.TextBox();
            this.lblMethodName = new System.Windows.Forms.Label();
            this.checkDivide = new System.Windows.Forms.CheckBox();
            this.btnDelConv = new System.Windows.Forms.Button();
            this.btnEditConv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(12, 384);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(93, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Zrušit";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // numUDgrid
            // 
            this.numUDgrid.Location = new System.Drawing.Point(12, 63);
            this.numUDgrid.Name = "numUDgrid";
            this.numUDgrid.Size = new System.Drawing.Size(140, 200);
            this.numUDgrid.TabIndex = 2;
            // 
            // convMethodBox
            // 
            this.convMethodBox.FormattingEnabled = true;
            this.convMethodBox.Items.AddRange(new object[] {
            "Žádná",
            "Gaussian blur",
            "Box blur",
            "Sharpen"});
            this.convMethodBox.Location = new System.Drawing.Point(12, 34);
            this.convMethodBox.Name = "convMethodBox";
            this.convMethodBox.Size = new System.Drawing.Size(140, 23);
            this.convMethodBox.TabIndex = 4;
            this.convMethodBox.SelectedIndexChanged += new System.EventHandler(this.convMethodBox_SelectedIndexChanged);
            // 
            // btnAddConv
            // 
            this.btnAddConv.Location = new System.Drawing.Point(171, 275);
            this.btnAddConv.Name = "btnAddConv";
            this.btnAddConv.Size = new System.Drawing.Size(75, 23);
            this.btnAddConv.TabIndex = 5;
            this.btnAddConv.Text = "Přidat";
            this.btnAddConv.UseVisualStyleBackColor = true;
            this.btnAddConv.Click += new System.EventHandler(this.btnAddConv_Click);
            // 
            // txtMethodName
            // 
            this.txtMethodName.Location = new System.Drawing.Point(12, 293);
            this.txtMethodName.Name = "txtMethodName";
            this.txtMethodName.Size = new System.Drawing.Size(140, 23);
            this.txtMethodName.TabIndex = 6;
            // 
            // lblMethodName
            // 
            this.lblMethodName.AutoSize = true;
            this.lblMethodName.Location = new System.Drawing.Point(12, 275);
            this.lblMethodName.Name = "lblMethodName";
            this.lblMethodName.Size = new System.Drawing.Size(115, 15);
            this.lblMethodName.TabIndex = 7;
            this.lblMethodName.Text = "Název nové metody:";
            // 
            // checkDivide
            // 
            this.checkDivide.AutoSize = true;
            this.checkDivide.Location = new System.Drawing.Point(12, 326);
            this.checkDivide.Name = "checkDivide";
            this.checkDivide.Size = new System.Drawing.Size(60, 19);
            this.checkDivide.TabIndex = 8;
            this.checkDivide.Text = "Dělí se";
            this.checkDivide.UseVisualStyleBackColor = true;
            // 
            // btnDelConv
            // 
            this.btnDelConv.Location = new System.Drawing.Point(171, 333);
            this.btnDelConv.Name = "btnDelConv";
            this.btnDelConv.Size = new System.Drawing.Size(75, 23);
            this.btnDelConv.TabIndex = 9;
            this.btnDelConv.Text = "Odebrat";
            this.btnDelConv.UseVisualStyleBackColor = true;
            this.btnDelConv.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEditConv
            // 
            this.btnEditConv.Location = new System.Drawing.Point(171, 304);
            this.btnEditConv.Name = "btnEditConv";
            this.btnEditConv.Size = new System.Drawing.Size(75, 23);
            this.btnEditConv.TabIndex = 10;
            this.btnEditConv.Text = "Uložit";
            this.btnEditConv.UseVisualStyleBackColor = true;
            this.btnEditConv.Click += new System.EventHandler(this.btnEditConv_Click);
            // 
            // ConvEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 418);
            this.Controls.Add(this.btnEditConv);
            this.Controls.Add(this.btnDelConv);
            this.Controls.Add(this.checkDivide);
            this.Controls.Add(this.lblMethodName);
            this.Controls.Add(this.txtMethodName);
            this.Controls.Add(this.btnAddConv);
            this.Controls.Add(this.convMethodBox);
            this.Controls.Add(this.numUDgrid);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "ConvEditor";
            this.Text = "ConvEditor";
            this.Load += new System.EventHandler(this.ConvEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnOK;
        private Button btnCancel;
        private FlowLayoutPanel numUDgrid;
        private ComboBox convMethodBox;
        private Button btnAddConv;
        private TextBox txtMethodName;
        private Label lblMethodName;
        private CheckBox checkDivide;
        private Button btnDelConv;
        private Button btnEditConv;
    }
}