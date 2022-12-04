using NetCafeUCN.MVC.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.MVC.Models
{
    public class BookingDto
    {
        public string? BookingNo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PhoneNo { get; set; }
        public List<BookingLineDto> BookingLines { get; set; }
        public BookingDto()
        {
            BookingLines = new List<BookingLineDto>();
        }
    }
}
