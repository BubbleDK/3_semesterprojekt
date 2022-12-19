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

        /// <summary>
        /// En enum til at bestemme hvilke typer af users der kan oprettes.
        /// </summary>
        private enum Type
        {
            Customer = 0,
            Employee = 1,
        }
        /// <summary>
        /// Constructoren til denne form
        /// </summary>
        /// <param name="userForm">Base userform sendes med</param>
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
        /// <summary>
        /// Metoden der køres når man trykker på bekræft
        /// </summary>
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
