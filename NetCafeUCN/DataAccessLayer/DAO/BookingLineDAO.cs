using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.DAO
{
    public class BookingLineDAO
    {
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
