using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.Model;
using System.Data.SqlClient;

namespace NetCafeUCN.DAL.DAO
{
    /// <summary>
    ///  BookingLineDAO klassen, som implementere INetCafeUCNBookingLineDAO
    /// </summary>
    public class BookingLineDAO : INetCafeUCNBookingLineDAO
    {
        /// <summary>
        /// Metode som henter alle bookinglines tilknyttet til en booking
        /// </summary>
        /// <param name="bookingNo">Et booking nummer</param>
        /// <returns>Returnere en collection af BookingLine</returns>
        public IEnumerable<BookingLine> GetBookingLinesByBooking(string bookingNo)
        {
            List<BookingLine> bookingLines = new List<BookingLine>();
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                using SqlCommand command = new SqlCommand("select * from nc_bookingline inner join nc_Booking on nc_Booking.id = nc_BookingLine.bookingid WHERE bookingNo = @bookingNo", conn);
                command.Parameters.AddWithValue("@bookingno", bookingNo);
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            bookingLines.Add(new BookingLine()
                            {
                                Quantity = (int)reader["quantity"],
                                StationId = (int)reader["stationid"],
                                ConsumableId = (int)reader["consumableid"],
                            });
                        }
                        return bookingLines;
                    }
                    catch (DataAccessException)
                    {

                        throw new DataAccessException("Can't access data");
                    }
                }
            }
        }
    }
}
