using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp
{
    public partial class AddCustomerForm : Form
    {
        INetCafeDataAccess<Customer> CustomerService;
        public AddCustomerForm(INetCafeDataAccess<Customer> CustomerService)
        {
            this.CustomerService = CustomerService;
            InitializeComponent();
        }

        private void btnSavePerson_Click(object sender, EventArgs e)
        {
            CustomerService.Add(AddCustomer());
        }

        private Customer AddCustomer()
        {
            Customer customer = new Customer();
            customer.Email = txtEmail.Text;
            customer.Name = txtName.Text;
            customer.Phone = txtPhoneNumber.Text;
            return customer;
        }
    }
}
