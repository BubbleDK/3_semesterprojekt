using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp
{
    public partial class UsersForm : Form
    {
        INetCafeDataAccess<Customer> CustomerService = new CustomerService("https://localhost:7197/api/Customer");
        public UsersForm()
        {
            InitializeComponent();
        }
    }
}
