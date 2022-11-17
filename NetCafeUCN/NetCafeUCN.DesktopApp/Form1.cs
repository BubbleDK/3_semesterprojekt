using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp
{
    public partial class Form1 : Form
    {
        INetCafeDataAccess<Customer> _userService = new CustomerService("https://localhost:7197/api/Customer/");
        public Form1()
        {
            InitializeComponent();
            ShowAllBookings();
        }

        private void ShowAllBookings()
        {
            lstAllusers.Items.Clear();
            try {
                _userService.GetAll().ToList().ForEach(x => lstAllusers.Items.Add(x));
            }catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } }

        private void btnDeleteByPhoneNumber_Click(object sender, EventArgs e)
        {
            if (_userService.Remove(txtPhoneNumber.Text))
            {
                txtDeleteCheck.Text = "True";
            }
            else
            {
                txtDeleteCheck.Text = "False";
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm(_userService);
            addCustomerForm.ShowDialog();
        }
    }
}