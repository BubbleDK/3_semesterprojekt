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
    public partial class GamingstationForm : Form
    {
        public GamingstationForm()
        {
            InitializeComponent();
        }

        public GamingstationForm(string productNumber, string type, string name)
        {
            //txtDescription.Text = description;
            txtProductName.Text = name;
            txtProductNum.Text = productNumber;
            txtProductType.Text = type;
            //txtSeatNumber.Text = seatNo;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            confirmOption();
        }

        private void confirmOption()
        {
            //TODO: Call add gamingstation somehow somewhere
        }
    }
}
