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
            bookingService = new BookingService(MainMenu.BaseUrl + "Bookings/");
            RefreshList();
        }

        public void RefreshList()
        {
            dgvBookings.DataSource = null;
            dgvBookings.Rows.Clear();
            List<BookingDTO> bookings = bookingService.GetAll().ToList();
            if(bookings != null)
            {
                dgvBookings.DataSource = bookings;
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
            //ShowUpdateBookingForm();
            MessageBox.Show("Denne funktion er ikke tilgængelig", "Ikke implementeret", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            BookingDTO bookingToRemove = (BookingDTO)dgvBookings.CurrentRow.DataBoundItem;
            if (MessageBox.Show("Er du sikker på du at vil slette: " + bookingToRemove.BookingNo, "Slet booking", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                bookingService.Remove(bookingToRemove.BookingNo);
                MessageBox.Show("Booking slettet: " + bookingToRemove.BookingNo, "Booking slettet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Afbrød slet booking", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            RefreshList();
        }

        private void BookingsForm_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                RefreshList();
            }
        }
    }
}
