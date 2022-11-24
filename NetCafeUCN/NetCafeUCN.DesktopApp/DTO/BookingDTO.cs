namespace NetCafeUCN.DesktopApp.DTO
{
    public class BookingDTO
    {
        public int BookingNo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CustomerId { get; set; }
        public List<BookingLineDTO> BookingLines { get; set; }

        public void addToBookingLine(BookingLineDTO bl)
        {
            BookingLines.Add(bl);
        }
    }
}
