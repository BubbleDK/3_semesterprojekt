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
    public partial class AddPersonForm : Form
    {
        INetCafeDataAccess<Person> UserService;
        public AddPersonForm(INetCafeDataAccess<Person> UserService)
        {
            this.UserService = UserService;
            InitializeComponent();
        }

        private void btnSavePerson_Click(object sender, EventArgs e)
        {
            UserService.Add(AddPerson());
        }

        private Person AddPerson()
        {
            Person person = new Customer();
            person.Email = txtEmail.Text;
            person.Name = txtName.Text;
            person.Phone = txtPhoneNumber.Text;
            return person;
        }
    }
}
