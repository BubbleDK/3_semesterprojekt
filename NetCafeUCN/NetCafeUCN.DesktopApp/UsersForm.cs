using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp
{
    public partial class UsersForm : Form
    {
        INetCafeDataAccess<Customer> customerService;
        public UsersForm()
        {
            InitializeComponent();
            customerService = new CustomerService("https://localhost:7197/api/Customer/");
            RefreshList();
        }

        private void RefreshList()
        {
            lstCustomers.Items.Clear();
            //TODO: List should contain Gamingstation and Consumable instead of Product
            List<Customer> customers = new();
            customers = customerService.GetAll().ToList();
            foreach (Customer c in customers)
            {
                lstCustomers.Items.Add(c);
            }
        }
    }
}
