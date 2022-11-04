using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp
{
    public partial class Form1 : Form
    {
        public BookingService bookingService = new();
        public Form1()
        {
            InitializeComponent();
            ShowAllBookings();
        }

        private void ShowAllBookings()
        {
            lstAllBookings.Items.Clear();
            lstAllBookings.Items.Add(bookingService.GetAll());
        }
    }
}