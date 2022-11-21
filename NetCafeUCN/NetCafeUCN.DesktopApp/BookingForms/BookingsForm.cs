using NetCafeUCN.DesktopApp.BookingForms;
using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp
{
    public partial class BookingsForm : Form
    {
        INetCafeDataAccess<BookingDTO> bookingService;
        public BookingsForm()
        {
            InitializeComponent();
            bookingService = new BookingService("https://localhost:7197/api/Booking/");
            RefreshList();
        }

        private void RefreshList()
        {
            dgvBookings.DataSource = null;
            dgvBookings.Rows.Clear();
            dgvBookings.DataSource = bookingService.GetAll().ToList();
            dgvBookings.ClearSelection();
            dgvBookings.CurrentCell = null;
        }

        private void btnNewBooking_Click(object sender, EventArgs e)
        {
            ShowNewBookingForm();
        }

        private void ShowNewBookingForm()
        {
            Form newBookingForm = new NewBookingForm();
            newBookingForm.ShowDialog();
        }
    }
}
