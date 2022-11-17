namespace NetCafeUCN.DesktopApp
{
    partial class ProductsForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreateProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.tbProducts = new System.Windows.Forms.TabControl();
            this.tbConsumable = new System.Windows.Forms.TabPage();
            this.dgwConsumables = new System.Windows.Forms.DataGridView();
            this.tbGamingstations = new System.Windows.Forms.TabPage();
            this.dgwGamingstations = new System.Windows.Forms.DataGridView();
            this.lstGamingstations = new System.Windows.Forms.ListView();
            this.colComputerName = new System.Windows.Forms.ColumnHeader();
            this.colProductNo = new System.Windows.Forms.ColumnHeader();
            this.colmProductType = new System.Windows.Forms.ColumnHeader();
            this.colSeatNo = new System.Windows.Forms.ColumnHeader();
            this.colDesc = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbProducts.SuspendLayout();
            this.tbConsumable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwConsumables)).BeginInit();
            this.tbGamingstations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGamingstations)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbProducts);
            this.splitContainer1.Size = new System.Drawing.Size(936, 625);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnCreateProduct, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdateProduct, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteProduct, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(312, 625);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCreateProduct
            // 
            this.btnCreateProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreateProduct.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreateProduct.Location = new System.Drawing.Point(3, 4);
            this.btnCreateProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreateProduct.Name = "btnCreateProduct";
            this.btnCreateProduct.Size = new System.Drawing.Size(306, 200);
            this.btnCreateProduct.TabIndex = 0;
            this.btnCreateProduct.Text = "Nyt Produkt";
            this.btnCreateProduct.UseVisualStyleBackColor = true;
            this.btnCreateProduct.Click += new System.EventHandler(this.btnCreateProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateProduct.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateProduct.Location = new System.Drawing.Point(3, 212);
            this.btnUpdateProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(306, 200);
            this.btnUpdateProduct.TabIndex = 1;
            this.btnUpdateProduct.Text = "Opdatér Produkt";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteProduct.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteProduct.Location = new System.Drawing.Point(3, 420);
            this.btnDeleteProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(306, 201);
            this.btnDeleteProduct.TabIndex = 2;
            this.btnDeleteProduct.Text = "Slet";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click_1);
            // 
            // tbProducts
            // 
            this.tbProducts.Controls.Add(this.tbConsumable);
            this.tbProducts.Controls.Add(this.tbGamingstations);
            this.tbProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbProducts.Location = new System.Drawing.Point(0, 0);
            this.tbProducts.Name = "tbProducts";
            this.tbProducts.SelectedIndex = 0;
            this.tbProducts.Size = new System.Drawing.Size(619, 625);
            this.tbProducts.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbProducts.TabIndex = 0;
            this.tbProducts.Deselected += new System.Windows.Forms.TabControlEventHandler(this.tbProducts_Deselected);
            // 
            // tbConsumable
            // 
            this.tbConsumable.Controls.Add(this.dgwConsumables);
            this.tbConsumable.Location = new System.Drawing.Point(4, 29);
            this.tbConsumable.Name = "tbConsumable";
            this.tbConsumable.Padding = new System.Windows.Forms.Padding(3);
            this.tbConsumable.Size = new System.Drawing.Size(611, 592);
            this.tbConsumable.TabIndex = 0;
            this.tbConsumable.Text = "Mad & Drikke";
            this.tbConsumable.UseVisualStyleBackColor = true;
            // 
            // dgwConsumables
            // 
            this.dgwConsumables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwConsumables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgwConsumables.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgwConsumables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwConsumables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwConsumables.Location = new System.Drawing.Point(3, 3);
            this.dgwConsumables.MultiSelect = false;
            this.dgwConsumables.Name = "dgwConsumables";
            this.dgwConsumables.RowHeadersWidth = 51;
            this.dgwConsumables.RowTemplate.Height = 29;
            this.dgwConsumables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwConsumables.Size = new System.Drawing.Size(605, 586);
            this.dgwConsumables.TabIndex = 0;
            // 
            // tbGamingstations
            // 
            this.tbGamingstations.Controls.Add(this.dgwGamingstations);
            this.tbGamingstations.Controls.Add(this.lstGamingstations);
            this.tbGamingstations.Location = new System.Drawing.Point(4, 29);
            this.tbGamingstations.Name = "tbGamingstations";
            this.tbGamingstations.Padding = new System.Windows.Forms.Padding(3);
            this.tbGamingstations.Size = new System.Drawing.Size(611, 592);
            this.tbGamingstations.TabIndex = 1;
            this.tbGamingstations.Text = "Computere";
            this.tbGamingstations.UseVisualStyleBackColor = true;
            // 
            // dgwGamingstations
            // 
            this.dgwGamingstations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwGamingstations.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgwGamingstations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgwGamingstations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwGamingstations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwGamingstations.Location = new System.Drawing.Point(3, 3);
            this.dgwGamingstations.MultiSelect = false;
            this.dgwGamingstations.Name = "dgwGamingstations";
            this.dgwGamingstations.RowHeadersWidth = 51;
            this.dgwGamingstations.RowTemplate.Height = 29;
            this.dgwGamingstations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwGamingstations.Size = new System.Drawing.Size(605, 586);
            this.dgwGamingstations.TabIndex = 1;
            // 
            // lstGamingstations
            // 
            this.lstGamingstations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colComputerName,
            this.colProductNo,
            this.colmProductType,
            this.colSeatNo,
            this.colDesc});
            this.lstGamingstations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGamingstations.FullRowSelect = true;
            this.lstGamingstations.GridLines = true;
            this.lstGamingstations.Location = new System.Drawing.Point(3, 3);
            this.lstGamingstations.Name = "lstGamingstations";
            this.lstGamingstations.Size = new System.Drawing.Size(605, 586);
            this.lstGamingstations.TabIndex = 0;
            this.lstGamingstations.UseCompatibleStateImageBehavior = false;
            // 
            // colComputerName
            // 
            this.colComputerName.Text = "Produktnavn";
            // 
            // colProductNo
            // 
            this.colProductNo.Text = "Produkt nr:";
            // 
            // colmProductType
            // 
            this.colmProductType.Text = "Produkt Type";
            // 
            // colSeatNo
            // 
            this.colSeatNo.Text = "Plads nr:";
            // 
            // colDesc
            // 
            this.colDesc.Text = "Beskrivelse: ";
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 625);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProductsForm";
            this.Text = "Products";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ProductsForm_KeyUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tbProducts.ResumeLayout(false);
            this.tbConsumable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwConsumables)).EndInit();
            this.tbGamingstations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwGamingstations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnCreateProduct;
        private Button btnUpdateProduct;
        private Button btnDeleteProduct;
        private TabControl tbProducts;
        private TabPage tbConsumable;
        private TabPage tbGamingstations;
        private DataGridView dgwConsumables;
        private ListView lstGamingstations;
        private ColumnHeader colComputerName;
        private ColumnHeader colProductNo;
        private ColumnHeader colmProductType;
        private ColumnHeader colSeatNo;
        private ColumnHeader colDesc;
        private DataGridView dgwGamingstations;
    }
}