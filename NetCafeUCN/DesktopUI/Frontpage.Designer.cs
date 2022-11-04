namespace NetCafeUCN.Desktop
{
    partial class FrontPage
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
            this.lstAllProducts = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstAllProducts
            // 
            this.lstAllProducts.FormattingEnabled = true;
            this.lstAllProducts.ItemHeight = 15;
            this.lstAllProducts.Location = new System.Drawing.Point(172, 48);
            this.lstAllProducts.Name = "lstAllProducts";
            this.lstAllProducts.Size = new System.Drawing.Size(473, 379);
            this.lstAllProducts.TabIndex = 0;
            // 
            // FrontPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstAllProducts);
            this.Name = "FrontPage";
            this.Text = "FrontPage";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lstAllProducts;
    }
}