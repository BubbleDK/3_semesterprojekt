using NetCafeUCN.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.DAO
{
    public interface INetCafeUCNBookingLineDAO
    {
        public IEnumerable<BookingLine> GetBookingLinesByBooking(string bookingNo);
    }
}
