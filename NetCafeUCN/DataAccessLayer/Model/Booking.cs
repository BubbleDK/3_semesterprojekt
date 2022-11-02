using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Booking
    {
        public int BookingNo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Booking(int bookingNo, DateTime startTime, DateTime endTime)
        {
            BookingNo = bookingNo;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
