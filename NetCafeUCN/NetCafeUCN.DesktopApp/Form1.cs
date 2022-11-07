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
            UserService.GetAll().ToList().ForEach(x => lstAllproducts.Items.Add(x));
        }

        private void btnDeleteByPhoneNumber_Click(object sender, EventArgs e)
        {
            UserService.Remove(txtPhoneNumber.Text);
        }
    }
}