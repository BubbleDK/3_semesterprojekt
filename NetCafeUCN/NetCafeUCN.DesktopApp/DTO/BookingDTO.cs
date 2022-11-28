﻿namespace NetCafeUCN.DesktopApp.DTO
{
    public class BookingDTO
    {
        public string? BookingNo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PhoneNo { get; set; }
        public List<BookingLineDTO> BookingLines { get; set; }

        public void addToBookingLine(BookingLineDTO bl)
        {
            BookingLines.Add(bl);
        }
    }
}
