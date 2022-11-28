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

        public void RefreshList()
        {
            dgvBookings.DataSource = null;
            dgvBookings.Rows.Clear();
            List<BookingDTO> bookings = bookingService.GetAll().ToList();
            if(bookings != null)
            {
                dgvBookings.DataSource = bookingService.GetAll().ToList();
            }
            dgvBookings.ClearSelection();
            dgvBookings.CurrentCell = null;
        }

        private void btnNewBooking_Click(object sender, EventArgs e)
        {
            ShowNewBookingForm();
        }

        private void ShowNewBookingForm()
        {
            Form newBookingForm = new NewBookingForm(this);
            newBookingForm.ShowDialog();
        }

        private void btnUpdateBooking_Click(object sender, EventArgs e)
        {
            ShowUpdateBookingForm();
        }

        private void ShowUpdateBookingForm()
        {
            //TODO: TAG FAT I DEN MARKEREDE BOOKING
            BookingDTO bookingToUpdate = (BookingDTO)dgvBookings.CurrentRow.DataBoundItem;
            NewBookingForm updateBooking = new NewBookingForm(bookingToUpdate);
            updateBooking.ShowDialog();
            RefreshList();
        }

        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            DeleteBooking();
        }

        private void DeleteBooking()
        {
            //bookingService.Remove();
            RefreshList();
        }
    }
}
