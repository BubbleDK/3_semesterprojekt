using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp
{
    public partial class Form1 : Form
    {
        INetCafeDataAccess<Person> UserService = new UserService("https://localhost:7197/api/Person");
        public Form1()
        {
            InitializeComponent();
            ShowAllBookings();
        }

        private void ShowAllBookings()
        {
            lstAllproducts.Items.Clear();
            var all = UserService.GetAll();
            lstAllproducts.Items.Add(UserService.GetAll());
        }
    }
}