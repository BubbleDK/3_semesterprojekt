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
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.clndPicker = new System.Windows.Forms.MonthCalendar();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cmbEndTime = new System.Windows.Forms.ComboBox();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.cmbStartTime = new System.Windows.Forms.ComboBox();
            this.dgvAvailableGamingstations = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableGamingstations)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvAvailableGamingstations);
            this.splitContainer1.Size = new System.Drawing.Size(1125, 748);
            this.splitContainer1.SplitterDistance = 259;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtPhoneNo);
            this.splitContainer2.Panel1.Controls.Add(this.lblPhone);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(259, 748);
            this.splitContainer2.SplitterDistance = 88;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPhoneNo.Location = new System.Drawing.Point(114, 21);
            this.txtPhoneNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhoneNo.MaxLength = 8;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(131, 27);
            this.txtPhoneNo.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(14, 32);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(61, 20);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "Telefon:";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.clndPicker);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnConfirm);
            this.splitContainer3.Panel2.Controls.Add(this.cmbEndTime);
            this.splitContainer3.Panel2.Controls.Add(this.lblEndTime);
            this.splitContainer3.Panel2.Controls.Add(this.lblStartTime);
            this.splitContainer3.Panel2.Controls.Add(this.cmbStartTime);
            this.splitContainer3.Size = new System.Drawing.Size(259, 654);
            this.splitContainer3.SplitterDistance = 260;
            this.splitContainer3.SplitterWidth = 6;
            this.splitContainer3.TabIndex = 0;
            // 
            // clndPicker
            // 
            this.clndPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clndPicker.Location = new System.Drawing.Point(0, 0);
            this.clndPicker.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.clndPicker.MaxSelectionCount = 1;
            this.clndPicker.MinDate = new System.DateTime(1971, 1, 1, 0, 0, 0, 0);
            this.clndPicker.Name = "clndPicker";
            this.clndPicker.TabIndex = 0;
            this.clndPicker.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.clndPicker_DateChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(170, 329);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(86, 30);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Bekræft";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cmbEndTime
            // 
            this.cmbEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEndTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndTime.FormattingEnabled = true;
            this.cmbEndTime.Location = new System.Drawing.Point(10, 166);
            this.cmbEndTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbEndTime.Name = "cmbEndTime";
            this.cmbEndTime.Size = new System.Drawing.Size(245, 28);
            this.cmbEndTime.TabIndex = 4;
            this.cmbEndTime.SelectionChangeCommitted += new System.EventHandler(this.cmbEndTime_SelectionChangeCommitted);
            // 
            // lblEndTime
            // 
            this.lblEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(14, 142);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(55, 20);
            this.lblEndTime.TabIndex = 3;
            this.lblEndTime.Text = "Sluttid:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(14, 20);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(61, 20);
            this.lblStartTime.TabIndex = 2;
            this.lblStartTime.Text = "Starttid:";
            // 
            // cmbStartTime
            // 
            this.cmbStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartTime.FormattingEnabled = true;
            this.cmbStartTime.Location = new System.Drawing.Point(9, 44);
            this.cmbStartTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbStartTime.Name = "cmbStartTime";
            this.cmbStartTime.Size = new System.Drawing.Size(246, 28);
            this.cmbStartTime.TabIndex = 1;
            this.cmbStartTime.SelectionChangeCommitted += new System.EventHandler(this.cmbStartTime_SelectionChangeCommitted);
            // 
            // dgvAvailableGamingstations
            // 
            this.dgvAvailableGamingstations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailableGamingstations.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAvailableGamingstations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableGamingstations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAvailableGamingstations.Location = new System.Drawing.Point(0, 0);
            this.dgvAvailableGamingstations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAvailableGamingstations.Name = "dgvAvailableGamingstations";
            this.dgvAvailableGamingstations.ReadOnly = true;
            this.dgvAvailableGamingstations.RowHeadersWidth = 51;
            this.dgvAvailableGamingstations.RowTemplate.Height = 29;
            this.dgvAvailableGamingstations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailableGamingstations.Size = new System.Drawing.Size(861, 748);
            this.dgvAvailableGamingstations.TabIndex = 0;
            // 
            // NewBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 748);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NewBookingForm";
            this.Text = "NewBookingForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableGamingstations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox txtPhoneNo;
        private Label lblPhone;
        private SplitContainer splitContainer2;
        private ComboBox cmbEndTime;
        private Label lblEndTime;
        private Label lblStartTime;
        private ComboBox cmbStartTime;
        private MonthCalendar clndPicker;
        private DataGridView dgvAvailableGamingstations;
        private Button btnConfirm;
        private SplitContainer splitContainer3;
    }
}