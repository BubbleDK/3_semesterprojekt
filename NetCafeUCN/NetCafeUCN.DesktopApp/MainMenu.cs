using NetCafeUCN.DesktopApp.UserForms;

namespace NetCafeUCN.DesktopApp
{
    public partial class MainMenu : Form
    {
        public static string BaseUrl { get; set; } = String.Empty;
        /// <summary>
        /// Constructoren til at oprette main menu vinduet
        /// </summary>
        /// <param name="baseUrl">Strengen til den baseurl service skal kontakte</param>
        public MainMenu(string baseUrl)
        {
            InitializeComponent();
            BaseUrl = baseUrl;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ProductsForm productsForm = new ProductsForm();
            productsForm.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();
            usersForm.Show();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            BookingsForm bookingsForm = new BookingsForm();
            bookingsForm.Show();
        }
    }
}
