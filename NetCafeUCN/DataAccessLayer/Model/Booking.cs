﻿namespace NetCafeUCN.DAL.Model
{
    /// <summary>
    ///  Booking model klasse
    /// </summary>
    public class Booking
    {
        public string BookingNo { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PhoneNo { get; set; } = string.Empty;
        public List<BookingLine> BookingLines { get; set; }
        public Booking()
        {
            BookingLines = new List<BookingLine>();
        }
        /// <summary>
        /// Metode til at generere et booking nummer
        /// </summary>
        /// <returns>Returnere string af det oprettede booking nummer</returns>
        public string GenerateBookingNo()
        {
            string myuuidAsString = Guid.NewGuid().ToString("N");
            string res = myuuidAsString.Remove(0, 24);

            return "BO-" + res.ToUpper();
        }
        /// <summary>
        /// Metode til at tilføje en BookingLine til bookingen
        /// </summary>
        /// <param name="bl">En BookingLine</param>
        public void addToBookingLine(BookingLine bl)
        {
            BookingLines.Add(bl);
        }
    }
}
