using NetCafeUCN.API.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCafeUCN.Desktop
{
    public partial class FrontPage : Form
    {
        public FrontPage()
        {
            InitializeComponent();
            ShowAllProducts();
        }

        private void ShowAllProducts()
        {
            lstAllProducts.Items.Clear();
            //lstAllProducts.Items.Add(ProductController.)
        }
    }
}
