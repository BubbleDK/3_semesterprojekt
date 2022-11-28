using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.API.DTO
{
    public class BookingDTO
    {
        public string BookingNo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PhoneNo { get; set; }
        public List<BookingLineDTO> BookingLines { get; set; }
        public BookingDTO()
        {
            BookingLines = new List<BookingLineDTO>();
        }

        public void addToBookingLine(BookingLineDTO bl)
        {
            BookingLines.Add(bl);
        }
    }
}
