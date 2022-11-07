namespace NetCafeUCN.DesktopApp
{
    partial class AddPersonForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtPersonType = new System.Windows.Forms.TextBox();
            this.btnSavePerson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 67);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(146, 23);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "Name";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 96);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(146, 23);
            this.txtEmail.TabIndex = 0;
            this.txtEmail.Text = "Email";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(12, 125);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(146, 23);
            this.txtPhoneNumber.TabIndex = 0;
            this.txtPhoneNumber.Text = "PhoneNumber";
            // 
            // txtPersonType
            // 
            this.txtPersonType.Location = new System.Drawing.Point(12, 154);
            this.txtPersonType.Name = "txtPersonType";
            this.txtPersonType.Size = new System.Drawing.Size(146, 23);
            this.txtPersonType.TabIndex = 0;
            this.txtPersonType.Text = "PersonType";
            // 
            // btnSavePerson
            // 
            this.btnSavePerson.Location = new System.Drawing.Point(176, 154);
            this.btnSavePerson.Name = "btnSavePerson";
            this.btnSavePerson.Size = new System.Drawing.Size(75, 23);
            this.btnSavePerson.TabIndex = 1;
            this.btnSavePerson.Text = "Save Person";
            this.btnSavePerson.UseVisualStyleBackColor = true;
            this.btnSavePerson.Click += new System.EventHandler(this.btnSavePerson_Click);
            // 
            // AddPersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSavePerson);
            this.Controls.Add(this.txtPersonType);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtName);
            this.Name = "AddPersonForm";
            this.Text = "AddPersonForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPhoneNumber;
        private TextBox txtPersonType;
        private Button btnSavePerson;
    }
}