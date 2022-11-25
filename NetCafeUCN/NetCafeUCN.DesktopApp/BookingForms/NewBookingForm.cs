﻿using NetCafeUCN.DesktopApp.DTO;
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
    public partial class NewBookingForm : Form
    {
        INetCafeDataAccess<GamingStationDTO> gamingStationService;
        INetCafeDataAccess<BookingDTO> bookingService;
        List<GamingStationDTO> _availableGamingStations;
        public NewBookingForm()
        {
            InitializeComponent();
            InitializeTimes();
            clndPicker.MinDate = DateTime.Now;
            gamingStationService = new GamingStationService("https://localhost:7197/api/Gamingstation/");
            bookingService = new BookingService("https://localhost:7197/api/Booking/");
            RefreshGamingStations(gamingStationService.GetAll().ToList());
        }

        private void RefreshGamingStations(List<GamingStationDTO> availableGamingStations)
        {
            dgvAvailableGamingstations.DataSource = availableGamingStations;
            dgvAvailableGamingstations.Columns["productID"].Visible = false;
            dgvAvailableGamingstations.Columns["isActive"].Visible = false;
        }

        private void InitializeTimes()
        {
            cmbStartTime.DataSource = DateTimeUI.GetStartTimes();
            cmbEndTime.DataSource = DateTimeUI.GetEndTimes();
        }

        private void cmbStartTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbEndTime.SelectedIndex <= cmbStartTime.SelectedIndex)
            {
                cmbEndTime.SelectedIndex = cmbStartTime.SelectedIndex + 1;
            }
            DateTime currDate = clndPicker.SelectionStart;
            TimeSpan startTime = (TimeSpan)cmbStartTime.SelectedItem;
            TimeSpan endTime = (TimeSpan)cmbEndTime.SelectedItem;
            DateTime selectedStartTime = currDate.Date.Add(startTime);
            DateTime selectedEndTime = currDate.Date.Add(endTime);
            _availableGamingStations = new List<GamingStationDTO>();
            List<GamingStationDTO> allGamingStations = gamingStationService.GetAll().ToList();
            List<BookingDTO> allBookings = bookingService.GetAll().ToList();
            List<BookingDTO> bookingsWithinSelectedTimeSpan = new List<BookingDTO>();
            //Find alle bookings som er i det tidsrum man har indtastet
            foreach (var item in allBookings)
            {
                if ((item.StartTime < selectedStartTime && item.EndTime > selectedStartTime) ||
                    (item.StartTime < selectedEndTime && item.EndTime > selectedEndTime) ||
                    (item.StartTime > selectedStartTime && item.EndTime < selectedEndTime))
                {
                    //Tilføj det fundne bookings til ny liste
                    bookingsWithinSelectedTimeSpan.Add(item);
                }
            }
            List<int> stationProductIds = new List<int>();
            //Gå igennem de fundne bookings for at finde de optagede gamingstation IDs
            foreach (var item in bookingsWithinSelectedTimeSpan)
            {
                foreach (var bl in item.BookingLines)
                {
                    stationProductIds.Add(bl.StationId);
                }
            }
            //Se på hver gamingstation om den ligger i listen af bookinglines
            foreach (var item in allGamingStations)
            {
                bool res = true;
                foreach (int id in stationProductIds)
                {
                    if (item.productID == id)
                    {
                        res = false;
                        break;
                    }
                }
                if (res)
                {
                    _availableGamingStations.Add(item);
                }
            }
            RefreshGamingStations(_availableGamingStations);
        }

        private void cmbEndTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbEndTime.SelectedIndex <= cmbStartTime.SelectedIndex)
            {
                cmbEndTime.SelectedIndex = cmbStartTime.SelectedIndex + 1;
            }
            DateTime currDate = clndPicker.SelectionStart;
            TimeSpan startTime = (TimeSpan)cmbStartTime.SelectedItem;
            TimeSpan endTime = (TimeSpan)cmbEndTime.SelectedItem;
            DateTime selectedStartTime = currDate.Date.Add(startTime);
            DateTime selectedEndTime = currDate.Date.Add(endTime);
            _availableGamingStations = new List<GamingStationDTO>();
            List<GamingStationDTO> allGamingStations = gamingStationService.GetAll().ToList();
            List<BookingDTO> allBookings = bookingService.GetAll().ToList();
            List<BookingDTO> bookingsWithinSelectedTimeSpan = new List<BookingDTO>();
            //Find alle bookings som er i det tidsrum man har indtastet
            foreach (var item in allBookings)
            {
                if ((item.StartTime < selectedStartTime && item.EndTime > selectedStartTime) || 
                    (item.StartTime < selectedEndTime && item.EndTime > selectedEndTime) || 
                    (item.StartTime > selectedStartTime && item.EndTime < selectedEndTime))
                {
                    //Tilføj det fundne bookings til ny liste
                    bookingsWithinSelectedTimeSpan.Add(item);
                }
            }
            List<int> stationProductIds = new List<int>();
            //Gå igennem de fundne bookings for at finde de optagede gamingstation IDs
            foreach (var item in bookingsWithinSelectedTimeSpan)
            {
                foreach (var bl in item.BookingLines)
                {
                    stationProductIds.Add(bl.StationId);
                }
            }
            //Se på hver gamingstation om den ligger i listen af bookinglines
            foreach (var item in allGamingStations)
            {
                bool res = true;
                foreach (int id in stationProductIds)
                {
                    if(item.productID == id)
                    {
                        res = false;
                        break;
                    }
                }
                if(res)
                {
                    _availableGamingStations.Add(item);
                }
            }
            RefreshGamingStations(_availableGamingStations);
        }
    }
}
