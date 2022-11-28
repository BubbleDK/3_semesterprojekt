namespace NetCafeUCN.DesktopApp.BookingForms
{
    partial class BookingNumberInputForm
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
            this.lblBookingNo = new System.Windows.Forms.Label();
            this.txtBookingNo = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBookingNo
            // 
            this.lblBookingNo.AutoSize = true;
            this.lblBookingNo.Location = new System.Drawing.Point(12, 9);
            this.lblBookingNo.Name = "lblBookingNo";
            this.lblBookingNo.Size = new System.Drawing.Size(136, 15);
            this.lblBookingNo.TabIndex = 0;
            this.lblBookingNo.Text = "Indtast bookingnummer";
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.Location = new System.Drawing.Point(12, 27);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(100, 23);
            this.txtBookingNo.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(160, 65);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Bekræft";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // BookingNumberInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 100);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtBookingNo);
            this.Controls.Add(this.lblBookingNo);
            this.Name = "BookingNumberInputForm";
            this.Text = "Indtast bookingnummer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblBookingNo;
        private TextBox txtBookingNo;
        private Button btnConfirm;
    }
}