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
            this.lstAllBookings = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstAllBookings
            // 
            this.lstAllBookings.FormattingEnabled = true;
            this.lstAllBookings.ItemHeight = 15;
            this.lstAllBookings.Location = new System.Drawing.Point(85, 45);
            this.lstAllBookings.Name = "lstAllBookings";
            this.lstAllBookings.Size = new System.Drawing.Size(417, 244);
            this.lstAllBookings.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstAllBookings);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lstAllBookings;
    }
}