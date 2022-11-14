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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Form productsForm = new ProductsForm();
            productsForm.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Form usersForm = new UsersForm();
            usersForm.Show();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            Form bookingsForm = new BookingForm();
            bookingsForm.Show();
        }
    }
}
