﻿namespace NetCafeUCN.DesktopApp
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
            this.dgvConsumables = new System.Windows.Forms.DataGridView();
            this.tbGamingstations = new System.Windows.Forms.TabPage();
            this.dgvGamingstations = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumables)).BeginInit();
            this.tbGamingstations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGamingstations)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbProducts);
            this.splitContainer1.Size = new System.Drawing.Size(819, 469);
            this.splitContainer1.SplitterDistance = 273;
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(273, 469);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCreateProduct
            // 
            this.btnCreateProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreateProduct.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreateProduct.Location = new System.Drawing.Point(3, 3);
            this.btnCreateProduct.Name = "btnCreateProduct";
            this.btnCreateProduct.Size = new System.Drawing.Size(267, 150);
            this.btnCreateProduct.TabIndex = 0;
            this.btnCreateProduct.Text = "Nyt Produkt";
            this.btnCreateProduct.UseVisualStyleBackColor = true;
            this.btnCreateProduct.Click += new System.EventHandler(this.btnCreateProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateProduct.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateProduct.Location = new System.Drawing.Point(3, 159);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(267, 150);
            this.btnUpdateProduct.TabIndex = 1;
            this.btnUpdateProduct.Text = "Opdatér Produkt";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteProduct.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteProduct.Location = new System.Drawing.Point(3, 315);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(267, 151);
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
            this.tbProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbProducts.Name = "tbProducts";
            this.tbProducts.SelectedIndex = 0;
            this.tbProducts.Size = new System.Drawing.Size(542, 469);
            this.tbProducts.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbProducts.TabIndex = 0;
            this.tbProducts.Deselected += new System.Windows.Forms.TabControlEventHandler(this.tbProducts_Deselected);
            // 
            // tbConsumable
            // 
            this.tbConsumable.Controls.Add(this.dgvConsumables);
            this.tbConsumable.Location = new System.Drawing.Point(4, 24);
            this.tbConsumable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbConsumable.Name = "tbConsumable";
            this.tbConsumable.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbConsumable.Size = new System.Drawing.Size(534, 441);
            this.tbConsumable.TabIndex = 0;
            this.tbConsumable.Text = "Mad & Drikke";
            this.tbConsumable.UseVisualStyleBackColor = true;
            // 
            // dgvConsumables
            // 
            this.dgvConsumables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConsumables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvConsumables.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvConsumables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsumables.Location = new System.Drawing.Point(3, 2);
            this.dgvConsumables.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvConsumables.MultiSelect = false;
            this.dgvConsumables.Name = "dgvConsumables";
            this.dgvConsumables.ReadOnly = true;
            this.dgvConsumables.RowHeadersWidth = 51;
            this.dgvConsumables.RowTemplate.Height = 29;
            this.dgvConsumables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsumables.Size = new System.Drawing.Size(528, 437);
            this.dgvConsumables.TabIndex = 0;
            // 
            // tbGamingstations
            // 
            this.tbGamingstations.Controls.Add(this.dgvGamingstations);
            this.tbGamingstations.Controls.Add(this.lstGamingstations);
            this.tbGamingstations.Location = new System.Drawing.Point(4, 24);
            this.tbGamingstations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbGamingstations.Name = "tbGamingstations";
            this.tbGamingstations.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbGamingstations.Size = new System.Drawing.Size(534, 441);
            this.tbGamingstations.TabIndex = 1;
            this.tbGamingstations.Text = "Computere";
            this.tbGamingstations.UseVisualStyleBackColor = true;
            // 
            // dgvGamingstations
            // 
            this.dgvGamingstations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGamingstations.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGamingstations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvGamingstations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGamingstations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGamingstations.Location = new System.Drawing.Point(3, 2);
            this.dgvGamingstations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvGamingstations.MultiSelect = false;
            this.dgvGamingstations.Name = "dgvGamingstations";
            this.dgvGamingstations.ReadOnly = true;
            this.dgvGamingstations.RowHeadersWidth = 51;
            this.dgvGamingstations.RowTemplate.Height = 29;
            this.dgvGamingstations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGamingstations.Size = new System.Drawing.Size(528, 437);
            this.dgvGamingstations.TabIndex = 1;
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
            this.lstGamingstations.Location = new System.Drawing.Point(3, 2);
            this.lstGamingstations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstGamingstations.Name = "lstGamingstations";
            this.lstGamingstations.Size = new System.Drawing.Size(528, 437);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 469);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumables)).EndInit();
            this.tbGamingstations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGamingstations)).EndInit();
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
        private DataGridView dgvConsumables;
        private ListView lstGamingstations;
        private ColumnHeader colComputerName;
        private ColumnHeader colProductNo;
        private ColumnHeader colmProductType;
        private ColumnHeader colSeatNo;
        private ColumnHeader colDesc;
        private DataGridView dgvGamingstations;
    }
}