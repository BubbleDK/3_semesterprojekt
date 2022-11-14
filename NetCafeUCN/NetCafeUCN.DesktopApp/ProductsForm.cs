using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCafeUCN.DesktopApp
{
    public partial class ProductsForm : Form
    {
        INetCafeDataAccess<Product> productService = new ProductService("https://localhost:7197/api/Product");
        public ProductsForm()
        {
            InitializeComponent();
            UpdateList();
        }

        private void UpdateList()
        {
            lstProducts.Items.Clear();
            //TODO: List should contain Gamingstation and Consumable instead of Product
            List<Product> collection = new();
            collection = productService.GetAll().ToList();
            foreach (Product p in collection)
            {
                lstProducts.Items.Add(p);
            }
        }

        private void ShowInputDialog()
        {
            Form inputDialog = new InputDialog("Produkttype");
            inputDialog.ShowDialog();
        }

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            ShowInputDialog();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            UpdateProduct();
        }

        private void UpdateProduct()
        {
            Product p = lstProducts.SelectedItem as Product;
            Form gamingStationForm = new GamingstationForm(p.ProductNumber, p.Type, p.Name);
            gamingStationForm.Show();
        }
        private void ProductsForm_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                UpdateList();
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            Product p = lstProducts.SelectedItem as Product;
            productService.Remove(p.ProductNumber);
        }
    }
}
