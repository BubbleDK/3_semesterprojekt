using NetCafeUCN.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.DAO
{
    /// <summary>
    /// INetCafeUCNBookingLineDAO er et generic interface til BookingLines i DAO
    /// </summary>
    public interface INetCafeUCNBookingLineDAO
    {
        /// <summary>
        /// Metode til at hente alle bookinglines på en booking
        /// </summary>
        /// <param name="bookingNo">string af booking nummeret på den booking som skal findes</param>
        /// <returns>Collection af typen BookingLine</returns>
        public IEnumerable<BookingLine> GetBookingLinesByBooking(string bookingNo);
    }
}
