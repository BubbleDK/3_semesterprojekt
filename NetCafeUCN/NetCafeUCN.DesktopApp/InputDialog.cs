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
    public partial class InputDialog : Form
    {
        public InputDialog(string inputFormIdentity)
        {
            InitializeComponent();
            lblInput.Text = inputFormIdentity;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            confirmInupt();
        }

        private void confirmInupt()
        {
            if (txtInput.Text.ToLower().Equals("gamingstation"))
            {
                Form gamingStationForm = new GamingstationForm();
                gamingStationForm.Show();
            }
            else if (txtInput.Text.ToLower().Equals("consumable"))
            {

            }
        }
    }
}
