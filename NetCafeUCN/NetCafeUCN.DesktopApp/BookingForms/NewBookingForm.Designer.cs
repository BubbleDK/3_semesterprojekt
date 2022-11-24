namespace NetCafeUCN.DesktopApp.BookingForms
{
    partial class NewBookingForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.cmbEndTime = new System.Windows.Forms.ComboBox();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.cmbStartTime = new System.Windows.Forms.ComboBox();
            this.clndPicker = new System.Windows.Forms.MonthCalendar();
            this.dgvAvailableGamingstations = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableGamingstations)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvAvailableGamingstations);
            this.splitContainer1.Size = new System.Drawing.Size(1072, 604);
            this.splitContainer1.SplitterDistance = 279;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textBox2);
            this.splitContainer2.Panel1.Controls.Add(this.lblPhone);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cmbEndTime);
            this.splitContainer2.Panel2.Controls.Add(this.lblEndTime);
            this.splitContainer2.Panel2.Controls.Add(this.lblStartTime);
            this.splitContainer2.Panel2.Controls.Add(this.cmbStartTime);
            this.splitContainer2.Panel2.Controls.Add(this.clndPicker);
            this.splitContainer2.Size = new System.Drawing.Size(279, 604);
            this.splitContainer2.SplitterDistance = 73;
            this.splitContainer2.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(134, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(115, 23);
            this.textBox2.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(12, 24);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(45, 15);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "Telefon";
            // 
            // cmbEndTime
            // 
            this.cmbEndTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbEndTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndTime.FormattingEnabled = true;
            this.cmbEndTime.Location = new System.Drawing.Point(12, 271);
            this.cmbEndTime.Name = "cmbEndTime";
            this.cmbEndTime.Size = new System.Drawing.Size(225, 23);
            this.cmbEndTime.TabIndex = 4;
            this.cmbEndTime.SelectionChangeCommitted += new System.EventHandler(this.cmbEndTime_SelectionChangeCommitted);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(12, 253);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(41, 15);
            this.lblEndTime.TabIndex = 3;
            this.lblEndTime.Text = "Sluttid";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(12, 180);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(48, 15);
            this.lblStartTime.TabIndex = 2;
            this.lblStartTime.Text = "Starttid:";
            // 
            // cmbStartTime
            // 
            this.cmbStartTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbStartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartTime.FormattingEnabled = true;
            this.cmbStartTime.Location = new System.Drawing.Point(10, 198);
            this.cmbStartTime.Name = "cmbStartTime";
            this.cmbStartTime.Size = new System.Drawing.Size(226, 23);
            this.cmbStartTime.TabIndex = 1;
            this.cmbStartTime.SelectionChangeCommitted += new System.EventHandler(this.cmbStartTime_SelectionChangeCommitted);
            // 
            // clndPicker
            // 
            this.clndPicker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.clndPicker.Location = new System.Drawing.Point(10, 9);
            this.clndPicker.MaxSelectionCount = 1;
            this.clndPicker.MinDate = new System.DateTime(1971, 1, 1, 0, 0, 0, 0);
            this.clndPicker.Name = "clndPicker";
            this.clndPicker.TabIndex = 0;
            // 
            // dgvAvailableGamingstations
            // 
            this.dgvAvailableGamingstations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableGamingstations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAvailableGamingstations.Location = new System.Drawing.Point(0, 0);
            this.dgvAvailableGamingstations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAvailableGamingstations.Name = "dgvAvailableGamingstations";
            this.dgvAvailableGamingstations.ReadOnly = true;
            this.dgvAvailableGamingstations.RowHeadersWidth = 51;
            this.dgvAvailableGamingstations.RowTemplate.Height = 29;
            this.dgvAvailableGamingstations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailableGamingstations.Size = new System.Drawing.Size(789, 604);
            this.dgvAvailableGamingstations.TabIndex = 0;
            // 
            // NewBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 604);
            this.Controls.Add(this.splitContainer1);
            this.Name = "NewBookingForm";
            this.Text = "NewBookingForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableGamingstations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox textBox2;
        private Label lblPhone;
        private SplitContainer splitContainer2;
        private ComboBox cmbEndTime;
        private Label lblEndTime;
        private Label lblStartTime;
        private ComboBox cmbStartTime;
        private MonthCalendar clndPicker;
        private DataGridView dgvAvailableGamingstations;
    }
}