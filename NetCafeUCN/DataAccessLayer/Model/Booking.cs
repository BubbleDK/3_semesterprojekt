using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.Model
{
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

        public string GenerateBookingNo()
        {
            string myuuidAsString = Guid.NewGuid().ToString("N");
            string res = myuuidAsString.Remove(0, 24);

            return "BO-" + res.ToUpper();
        }

        public void addToBookingLine(BookingLine bl)
        {
            BookingLines.Add(bl);
        }
    }
}
