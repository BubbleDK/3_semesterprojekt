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
        int selectedIndex;
        public ProductsForm()
        {
            InitializeComponent();
            CreateThread();
            //UpdateList();
        }

        private void CreateThread()
        {
            Thread t1 = new Thread(UpdateList);
            t1.Start();
        }

        private void UpdateList()
        {
            ProductsForm.Invoke(new MethodInvoker(delegate ()
            {
                while (true)
                {
                    selectedIndex = lstProducts.SelectedIndex;
                    lstProducts.Items.Clear();
                    List<Product> collection = new();
                    collection = productService.GetAll().ToList();
                    foreach (Product p in collection)
                    {
                        lstProducts.Items.Add(p);
                    }
                    Thread.Sleep(1000);
                }
            }));
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
            lstProducts.SelectedItem = lstProducts.SelectedIndex;
            Product p = lstProducts.SelectedItem as Product;
            Form gamingStationForm = new GamingstationForm(p.ProductNumber, p.Type, p.Name);
            gamingStationForm.Show();
        }
    }
}
