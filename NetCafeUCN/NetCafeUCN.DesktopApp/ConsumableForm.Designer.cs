namespace NetCafeUCN.DesktopApp
{
    partial class ConsumableForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblProductNum = new System.Windows.Forms.Label();
            this.txtProductNum = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.lblProductType = new System.Windows.Forms.Label();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Controls.Add(this.lblProductNum);
            this.panel1.Controls.Add(this.txtProductNum);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.lblProductType);
            this.panel1.Controls.Add(this.txtProductType);
            this.panel1.Controls.Add(this.txtProductName);
            this.panel1.Controls.Add(this.lblProductName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 373);
            this.panel1.TabIndex = 12;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(201, 330);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(86, 31);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "Bekræft";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(16, 181);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(84, 20);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Beskrivelse:";
            // 
            // lblProductNum
            // 
            this.lblProductNum.AutoSize = true;
            this.lblProductNum.Location = new System.Drawing.Point(16, 7);
            this.lblProductNum.Name = "lblProductNum";
            this.lblProductNum.Size = new System.Drawing.Size(80, 20);
            this.lblProductNum.TabIndex = 0;
            this.lblProductNum.Text = "Produkt nr:";
            // 
            // txtProductNum
            // 
            this.txtProductNum.Location = new System.Drawing.Point(105, 7);
            this.txtProductNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductNum.Name = "txtProductNum";
            this.txtProductNum.Size = new System.Drawing.Size(114, 27);
            this.txtProductNum.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(105, 177);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(114, 127);
            this.txtDescription.TabIndex = 8;
            this.txtDescription.Text = "";
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(16, 68);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(43, 20);
            this.lblProductType.TabIndex = 2;
            this.lblProductType.Text = "Type:";
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(105, 64);
            this.txtProductType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(114, 27);
            this.txtProductType.TabIndex = 3;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(105, 123);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(114, 27);
            this.txtProductName.TabIndex = 5;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(16, 123);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(46, 20);
            this.lblProductName.TabIndex = 4;
            this.lblProductName.Text = "Navn:";
            // 
            // ConsumableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 373);
            this.Controls.Add(this.panel1);
            this.Name = "ConsumableForm";
            this.Text = "Consumables";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnConfirm;
        private Label lblDescription;
        private Label lblProductNum;
        private TextBox txtProductNum;
        private RichTextBox txtDescription;
        private Label lblProductType;
        private TextBox txtProductType;
        private TextBox txtProductName;
        private Label lblProductName;
    }
}