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

namespace NetCafeUCN.DesktopApp.UserForms
{
    public partial class CreateUpdateUser : Form
    {
        UsersForm usersForm;
        //0 for customer, 1 for employee
        int personType = -1;
        //0 for create, 1 for update
        int actionType = -1;
        EmployeeDTO? _employee;
        CustomerDTO? _customer;

        //Constructor til at oprette customer/employee
        public CreateUpdateUser(UsersForm usersForm, int type)
        {
            InitializeComponent();
            this.usersForm = usersForm;
            this.personType = type;
            actionType = 0;
            if (type == 0)
            {
                lblAddress.Visible = false;
                lblAddress.Enabled = false;
                txtAddress.Visible = false;
                txtAddress.Visible = false;
                lblRole.Visible = false;
                lblRole.Enabled = false;
                txtRole.Visible = false;
                txtRole.Enabled = false;
                lblZipCode.Visible = false;
                lblZipCode.Enabled = false;
                txtZipCode.Visible = false;
                txtZipCode.Enabled = false;
                txtPersonType.Text = "Customer";
            }
            else if(type == 1)
            {
                txtPersonType.Text = "Employee";
            }
        }
        //Constructor til at opdatere customers
        public CreateUpdateUser(UsersForm usersForm, CustomerDTO c)
        {
            InitializeComponent();
            this.usersForm = usersForm;
            this.personType = 0;
            actionType = 1;
            lblAddress.Visible = false;
            lblAddress.Enabled = false;
            txtAddress.Visible = false;
            txtAddress.Visible = false;
            lblRole.Visible = false;
            lblRole.Enabled = false;
            txtRole.Visible = false;
            txtRole.Enabled = false;
            lblZipCode.Visible = false;
            lblZipCode.Enabled = false;
            txtZipCode.Visible = false;
            txtZipCode.Enabled = false;
            txtName.Text = c.Name;
            txtEmail.Text = c.Email;
            txtPhone.Text = c.Phone;
            txtPhone.Enabled = false;
            txtPersonType.Text = c.PersonType;
        }
        //Constructor til at opdatere employees
        public CreateUpdateUser(UsersForm usersForm, EmployeeDTO e)
        {
            InitializeComponent();
            this.usersForm = usersForm;
            this.personType = 1;
            actionType = 1;
            txtName.Text = e.Name;
            txtEmail.Text = e.Email;
            txtPhone.Text = e.Phone;
            txtPhone.Enabled = false;
            txtPersonType.Text = e.PersonType;
            txtRole.Text = e.Role;
            txtAddress.Text = e.Address;
            txtZipCode.Text = e.Zipcode.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ConfirmInput();
            this.Dispose();
        }

        private void ConfirmInput()
        {
            //Hvis persontypen er 0 arbejdes der med customers og derfor customerservice
            if (personType == 0) 
            {
                INetCafeDataAccess<CustomerDTO> customerService = new CustomerService("https://localhost:7197/api/Customer/");
                _customer = new();
                _customer.Name = txtName.Text;
                _customer.Email = txtEmail.Text;
                _customer.Phone = txtPhone.Text;
                _customer.PersonType = txtPersonType.Text;
                _customer.isActive = true;
                if(actionType == 0)
                {
                    customerService.Add(_customer);
                }else if(actionType == 1)
                {
                    customerService.Update(_customer);
                }
                usersForm.RefreshList();

            }
            //Hvis persontypen er 1 arbejdes der med employees og derfor employeeservice
            else if (personType == 1)
            {
                INetCafeDataAccess<EmployeeDTO> employeeService = new EmployeeService("https://localhost:7197/api/Employee/");
                _employee = new();
                _employee.Name = txtName.Text;
                _employee.Email = txtEmail.Text;
                _employee.Phone = txtPhone.Text;
                _employee.PersonType = txtPersonType.Text;
                _employee.Role = txtRole.Text;
                _employee.Address = txtAddress.Text;
                _employee.Zipcode = int.Parse(txtZipCode.Text);
                _employee.isActive = true;
                if (actionType == 0)
                {
                    employeeService.Add(_employee);
                }
                else if (actionType == 1)
                {
                    employeeService.Update(_employee);
                }
                usersForm.RefreshList();
            }
        }
    }
}
