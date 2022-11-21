using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp
{
    public partial class AddCustomerForm : Form
    {
        INetCafeDataAccess<CustomerDTO> CustomerService;
        public AddCustomerForm(INetCafeDataAccess<CustomerDTO> CustomerService)
        {
            this.CustomerService = CustomerService;
            InitializeComponent();
        }

        private void btnSavePerson_Click(object sender, EventArgs e)
        {
            CustomerService.Add(AddCustomer());
        }

        private CustomerDTO AddCustomer()
        {
            CustomerDTO customer = new CustomerDTO();
            customer.Email = txtEmail.Text;
            customer.Name = txtName.Text;
            customer.Phone = txtPhoneNumber.Text;
            return customer;
        }
    }
}
