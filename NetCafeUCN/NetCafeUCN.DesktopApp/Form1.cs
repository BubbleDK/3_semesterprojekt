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
            lstAllusers.Items.Clear();
            try {
                UserService.GetAll().ToList().ForEach(x => lstAllusers.Items.Add(x));
            }catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } }

        private void btnDeleteByPhoneNumber_Click(object sender, EventArgs e)
        {
            if (UserService.Remove(txtPhoneNumber.Text))
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
            AddPersonForm addPersonForm = new AddPersonForm(UserService);
            addPersonForm.ShowDialog();
        }
    }
}