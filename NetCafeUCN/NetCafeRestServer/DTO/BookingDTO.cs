using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.API.DTO
{
    /// <summary>
    ///  BookingDTO model
    /// </summary>
    public class BookingDTO
    {
        public string? BookingNo { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PhoneNo { get; set; } = string.Empty;
        public List<BookingLineDTO> BookingLines { get; set; }
        public BookingDTO()
        {
            BookingLines = new List<BookingLineDTO>();
        }
        /// <summary>
        /// Tilføjet en bookinglinje til bookingen
        /// </summary>
        /// <param name="bl">En BookingLineDTO</param>
        public void addToBookingLine(BookingLineDTO bl)
        {
            BookingLines.Add(bl);
        }
    }
}
