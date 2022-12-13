using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCafeUCN.DesktopApp.BookingForms
{
    public partial class NewBookingForm : Form
    {
        INetCafeDataAccess<GamingStationDTO> gamingStationService;
        INetCafeDataAccess<BookingDTO> bookingService;
        INetCafeDataAccess<CustomerDTO> customerService;
        BookingLineService bookingLineService;
        List<GamingStationDTO> _availableGamingStations;
        BookingsForm bookingsForm;
        BookingDTO bookingDTO;
        string windowStatus;
        public NewBookingForm(BookingsForm bookingsFormWeCameFrom)
        {
            InitializeComponent();
            InitializeTimes();
            clndPicker.MinDate = DateTime.Now;
            gamingStationService = new GamingStationService(MainMenu.BaseUrl + "Gamingstation/");
            bookingService = new BookingService(MainMenu.BaseUrl + "Booking/");
            customerService = new CustomerService(MainMenu.BaseUrl + "Customer/");
            bookingLineService = new BookingLineService(MainMenu.BaseUrl + "BookingLine/");
            RefreshGamingStations(gamingStationService.GetAll().ToList());
            bookingsForm = bookingsFormWeCameFrom;
            windowStatus = "Create";
        }

        public NewBookingForm(BookingDTO bookingToUpdate)
        {
            //TODO: SKAL MARKERE ALLE GAMINGSTATIONS I LISTEN SOM ER PÅ BOOKINGEN 
            InitializeComponent();
            InitializeTimes();
            clndPicker.MinDate = bookingToUpdate.StartTime.Date;
            //TODO: SKAL RUNDES AF
            //cmbStartTime.SelectedValue = bookingToUpdate.StartTime;
            //TODO: SKAL RUNDES AF
            //cmbEndTime.SelectedValue = bookingToUpdate.EndTime;
            gamingStationService = new GamingStationService(MainMenu.BaseUrl + "Gamingstation/");
            bookingService = new BookingService(MainMenu.BaseUrl + "Booking/");
            RefreshGamingStations(gamingStationService.GetAll().ToList());
            bookingDTO = bookingToUpdate;
            windowStatus = "Update";
        }

        private void RefreshGamingStations(List<GamingStationDTO> availableGamingStations)
        {
            dgvAvailableGamingstations.DataSource = availableGamingStations;
            dgvAvailableGamingstations.Columns["ProductID"].Visible = false;
            dgvAvailableGamingstations.Columns["IsActive"].Visible = false;
            dgvAvailableGamingstations.Columns["Type"].Visible = false;
            dgvAvailableGamingstations.Columns["SeatNumber"].HeaderText = "Plads nr:";
            dgvAvailableGamingstations.Columns["Description"].HeaderText = "Beskrivelse:";
            dgvAvailableGamingstations.Columns["Name"].HeaderText = "Produkt navn:";
            dgvAvailableGamingstations.Columns["ProductNumber"].HeaderText = "Produkt nr:";
        }

        private void InitializeTimes()
        {
            cmbStartTime.DataSource = DateTimeUI.GetStartTimes();
            cmbEndTime.DataSource = DateTimeUI.GetEndTimes();
        }

        private void cmbStartTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //TODO: Check om tidspunkt ligger efter nuværende tidspunkt på datetime.now
            if (cmbEndTime.SelectedIndex <= cmbStartTime.SelectedIndex)
            {
                cmbEndTime.SelectedIndex = cmbStartTime.SelectedIndex + 1;
            }
            RefreshGamingStationsTimeChanged();
        }

        private void cmbEndTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //TODO: Check om tidspunkt ligger efter nuværende tidspunkt på datetime.now
            if (cmbEndTime.SelectedIndex <= cmbStartTime.SelectedIndex)
            {
                cmbEndTime.SelectedIndex = cmbStartTime.SelectedIndex + 1;
            }
            RefreshGamingStationsTimeChanged();
        }

        private void clndPicker_DateChanged(object sender, DateRangeEventArgs e)
        {
            RefreshGamingStationsTimeChanged();
        }

        private void RefreshGamingStationsTimeChanged()
        {
            DateTime currDate = clndPicker.SelectionStart;
            TimeSpan startTime = (TimeSpan)cmbStartTime.SelectedItem;
            TimeSpan endTime = (TimeSpan)cmbEndTime.SelectedItem;
            DateTime selectedStartTime = currDate.Date.Add(startTime);
            DateTime selectedEndTime = currDate.Date.Add(endTime);
            _availableGamingStations = new List<GamingStationDTO>();
            List<GamingStationDTO> allGamingStations = gamingStationService.GetAll().ToList();
            List<BookingDTO> allBookings = bookingService.GetAll().ToList();
            List<BookingDTO> bookingsWithinSelectedTimeSpan = new List<BookingDTO>();
            List<BookingLineDTO> bookingLines = new List<BookingLineDTO>();
            //Find alle bookings som er i det tidsrum man har indtastet
            foreach (var item in allBookings)
            {
                if ((item.StartTime <= selectedStartTime && item.EndTime > selectedStartTime) || //Er vores valgte tidsrum imellem bookings starttid og sluttid
                    (item.StartTime < selectedEndTime && item.EndTime > selectedEndTime) || // Er vores valgte sluttidspunkt efter b's starttid og vores valgte sluttid før b's sluttid
                    (item.StartTime >= selectedStartTime && item.EndTime < selectedEndTime) // Er vores valgte tidsrum på begge sider af b's tidsrum
                                                                                            )
                {
                    //Tilføj det fundne bookings til ny liste
                    bookingsWithinSelectedTimeSpan.Add(item);
                }
            }
            List<int> stationProductIds = new List<int>();
            //Gå igennem de fundne bookings for at finde de optagede gamingstation IDs
            foreach (var item in bookingsWithinSelectedTimeSpan)
            {

                
                //Hent alle bookinglines på bookings i tidsrummet
                bookingLines.AddRange(bookingLineService.GetAll(item.BookingNo));
            }
            //Se på hver gamingstation om den ligger i listen af bookinglines
            foreach (var item in allGamingStations)
            {
                bool res = true;
                //Kør igennem bookinglines fra metoden før
                foreach (var bl in bookingLines)
                {
                    if (item.ProductID == bl.StationId)
                    {
                        res = false;
                        break;
                    }
                }

                //Hvis gamingstationen ikke bliver fundet på nogle af de bookinglines vi kigger på
                //Så skal den tilføjes til listen over tilgængelige
                if (res)
                {
                    _availableGamingStations.Add(item);
                }
            }
            RefreshGamingStations(_availableGamingStations);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (windowStatus.Equals("Create"))
            {
                CreateBooking();
            }else if (windowStatus.Equals("Update"))
            {
                UpdateBooking();
            }
        }

        private void UpdateBooking()
        {
            DateTime currDate = clndPicker.SelectionStart;
            TimeSpan startTime = (TimeSpan)cmbStartTime.SelectedItem;
            TimeSpan endTime = (TimeSpan)cmbEndTime.SelectedItem;
            DateTime selectedStartTime = currDate.Date.Add(startTime);
            DateTime selectedEndTime = currDate.Date.Add(endTime);
            bookingDTO.StartTime = selectedStartTime;
            bookingDTO.EndTime = selectedEndTime;
            bookingDTO.PhoneNo = txtPhoneNo.Text;
            foreach (DataGridViewRow row in dgvAvailableGamingstations.SelectedRows)
            {
                GamingStationDTO currentGamingstation = (GamingStationDTO)row.DataBoundItem;
                bookingDTO.addToBookingLine(new BookingLineDTO { Quantity = 1, StationId = (int)currentGamingstation.ProductID, ConsumableId = -1 });
            }
            if (CheckPhoneNo(txtPhoneNo.Text))
            {
                if (bookingDTO.BookingLines.Count > 0)
                {
                    bookingService.Update(bookingDTO);
                    bookingsForm.RefreshList();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Du skal vælge minimum en PC", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Det indtastede telefonnr er ugyldigt", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CreateBooking()
        {
            BookingDTO bookingDTO = new BookingDTO();
            bookingDTO.BookingLines = new List<BookingLineDTO>();
            DateTime currDate = clndPicker.SelectionStart;
            TimeSpan startTime = (TimeSpan)cmbStartTime.SelectedItem;
            TimeSpan endTime = (TimeSpan)cmbEndTime.SelectedItem;
            DateTime selectedStartTime = currDate.Date.Add(startTime);
            DateTime selectedEndTime = currDate.Date.Add(endTime);
            bookingDTO.StartTime = selectedStartTime;
            bookingDTO.EndTime = selectedEndTime;
            bookingDTO.PhoneNo = txtPhoneNo.Text;
            //dgvAvailableGamingstations.ForEach(row => rows.SelectedRows(new BookingLineDTO { StationId = row.id, Quantity = 1, ConsumableId =-1 }));

            foreach (DataGridViewRow row in dgvAvailableGamingstations.SelectedRows)
            {
                GamingStationDTO currentGamingstation = (GamingStationDTO)row.DataBoundItem;
                bookingDTO.addToBookingLine(new BookingLineDTO { Quantity = 1, StationId = (int)currentGamingstation.ProductID, ConsumableId = -1 });
            }
            if (CheckPhoneNo(txtPhoneNo.Text))
            {
                CustomerDTO searchedCustomer = customerService.Get(txtPhoneNo.Text);
                if (searchedCustomer != null)
                {
                    if (bookingDTO.BookingLines.Count > 0)
                    {
                        if(bookingService.Add(bookingDTO))
                        {
                            MessageBox.Show("Oprettet booking fra: " + bookingDTO.StartTime + " til: " + bookingDTO.EndTime , "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bookingsForm.RefreshList();
                            this.Dispose();
                        }
                        else
                        {
                            RefreshGamingStationsTimeChanged();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Du skal vælge minimum en PC", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Telefonnummer er ikke i databasen", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Det indtastede telefonnummer er ugyldigt", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool CheckPhoneNo(string phoneNo)
        {
            Regex validatePhoneNoRegex = new Regex("^\\+?[1-9][0-9]{7}$");
            return validatePhoneNoRegex.IsMatch(phoneNo);
        }
    }
}
