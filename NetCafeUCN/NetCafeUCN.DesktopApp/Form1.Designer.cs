namespace NetCafeUCN.DesktopApp
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
            this.lstAllproducts = new System.Windows.Forms.ListBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.btnDeleteByPhoneNumber = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstAllproducts
            // 
            this.lstAllproducts.FormattingEnabled = true;
            this.lstAllproducts.ItemHeight = 15;
            this.lstAllproducts.Location = new System.Drawing.Point(85, 45);
            this.lstAllproducts.Name = "lstAllproducts";
            this.lstAllproducts.Size = new System.Drawing.Size(417, 244);
            this.lstAllproducts.TabIndex = 0;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(588, 124);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(155, 23);
            this.txtPhoneNumber.TabIndex = 1;
            // 
            // btnDeleteByPhoneNumber
            // 
            this.btnDeleteByPhoneNumber.Location = new System.Drawing.Point(595, 185);
            this.btnDeleteByPhoneNumber.Name = "btnDeleteByPhoneNumber";
            this.btnDeleteByPhoneNumber.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteByPhoneNumber.TabIndex = 2;
            this.btnDeleteByPhoneNumber.Text = "Delete";
            this.btnDeleteByPhoneNumber.UseVisualStyleBackColor = true;
            this.btnDeleteByPhoneNumber.Click += new System.EventHandler(this.btnDeleteByPhoneNumber_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeleteByPhoneNumber);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.lstAllproducts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lstAllproducts;
        private TextBox txtPhoneNumber;
        private Button btnDeleteByPhoneNumber;
    }
}