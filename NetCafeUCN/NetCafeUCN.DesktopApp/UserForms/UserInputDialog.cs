using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCafeUCN.DesktopApp.UserForms
{
    public partial class UserInputDialog : Form
    {
        UsersForm userForm;

        private enum Type
        {
            Customer = 0,
            Employee = 1,
        }
        public UserInputDialog(UsersForm userForm)
        {
            InitializeComponent();
            cmbInput.DataSource = Enum.GetValues(typeof(Type));
            this.userForm = userForm;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Hide();
            confirmInput();
            this.Dispose();
        }
        private void confirmInput()
        {
            if (cmbInput.SelectedIndex == 0)
            {
                int choice = cmbInput.SelectedIndex;
                Form cuUserForm = new CreateUpdateUser(userForm, choice);
                cuUserForm.ShowDialog();
            }
            else if (cmbInput.SelectedIndex == 1)
            {
                int choice = cmbInput.SelectedIndex;
                Form cuUserForm = new CreateUpdateUser(userForm, choice);
                cuUserForm.ShowDialog();
            }
        }
    }
}
