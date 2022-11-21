using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.Model
{
    public class Booking
    {
        public string BookingNo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CustomerId { get; set; }
        public List<BookingLine> BookingLines { get; set; }
        public Booking()
        {
            BookingLines = new List<BookingLine>();
        }

        public void addToBookingLine(BookingLine bl)
        {
            BookingLines.Add(bl);
        }
    }
}
