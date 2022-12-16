using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCafeUCN.DesktopApp.BookingForms
{
    public partial class BookingNumberInputForm : Form
    {
        INetCafeDataAccess<BookingDTO> bookingService;
        public BookingNumberInputForm()
        {
            InitializeComponent();
            bookingService = new BookingService(MainMenu.BaseUrl + "Bookings/");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ConfirmInput();
        }

        private void ConfirmInput()
        {
            Form updateBooking = new NewBookingForm(bookingService.Get(txtBookingNo.Text));
        }
    }
}
