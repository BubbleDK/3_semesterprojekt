namespace NetCafeUCN.DesktopApp
{
    partial class ProductInputDialog
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
            this.lblInput = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cmbInput = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInput.Location = new System.Drawing.Point(0, 0);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(125, 28);
            this.lblInput.TabIndex = 1;
            this.lblInput.Text = "Produkttype:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(134, 83);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(86, 31);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Bekræft";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cmbInput
            // 
            this.cmbInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInput.FormattingEnabled = true;
            this.cmbInput.Location = new System.Drawing.Point(0, 32);
            this.cmbInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbInput.Name = "cmbInput";
            this.cmbInput.Size = new System.Drawing.Size(219, 28);
            this.cmbInput.TabIndex = 3;
            // 
            // ProductInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 129);
            this.Controls.Add(this.cmbInput);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblInput);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProductInputDialog";
            this.Text = "InputDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblInput;
        private Button btnConfirm;
        private ComboBox cmbInput;
    }
}