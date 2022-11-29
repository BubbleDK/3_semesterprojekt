using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.Model;
using System.Data.SqlClient;
using System.Globalization;
using System.Data;

namespace NetCafeUCN.DAL.DAO
{
    /* @authors Rasmus Gudiksen, Jakob Kjeldsteen, Emil Tolstrup Petersen, Christian Funder og Mark Drongesen
     * <summary>
     * Denne klasse styrer kontakten mellem database og systemet omhandlende Booking
     * <summary/>
     */
    public class BookingDAO : INetCafeDAO<Booking>
    {
        /*
       * <summary>
       * Metoden tilføjer en Booking en til databasen.
       * <summary/>
       * <param name="o">Er den Booking der bliver tilføjet til databasen</param>
       * <returns>En bool<returns/>
       */
        public bool Add(Booking o)
        {
            CustomerDAO customerDAO = new CustomerDAO();
            if (customerDAO.GetId(o.PhoneNo) == 0) return false;
            if (BookingCheck(o.StartTime, o.EndTime) == true) return false;
            SqlTransaction trans;
            int id = 0;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                conn.Open();
                using (trans = conn.BeginTransaction(IsolationLevel.RepeatableRead))
                {
                    try
                    {
                        using (SqlCommand bookingCommand = new SqlCommand(
                                "INSERT INTO nc_Booking VALUES(@bookingNo, @startTime, @endTime, @customerId); SELECT SCOPE_IDENTITY();", conn, trans))
                        {
                            bookingCommand.Parameters.AddWithValue("@bookingNo", o.GenerateBookingNo());
                            bookingCommand.Parameters.AddWithValue("@startTime", o.StartTime);
                            bookingCommand.Parameters.AddWithValue("@endTime", o.EndTime);
                            bookingCommand.Parameters.AddWithValue("@customerId", customerDAO.GetId(o.PhoneNo));
                            id = Convert.ToInt32(bookingCommand.ExecuteScalar());
                        }
                        foreach (var item in o.BookingLines)
                        {
                            using (SqlCommand bookingLineCommand = new SqlCommand(
                                "INSERT INTO nc_BookingLine VALUES(@bookingid, @quantity, @stationid, @consumableid)", conn, trans))
                            {
                                bookingLineCommand.Parameters.AddWithValue("@bookingid", id);
                                bookingLineCommand.Parameters.AddWithValue("@quantity", item.Quantity);
                                bookingLineCommand.Parameters.AddWithValue("@stationid", item.Stationid);
                                bookingLineCommand.Parameters.AddWithValue("@consumableid", item.Consumableid);
                                bookingLineCommand.ExecuteNonQuery();
                            }
                        }
                        trans.Commit();
                        return true;
                    }
                    catch (DataAccessException)
                    {
                        trans.Rollback();
                        throw new DataAccessException("Can't access data");
                    }
                }
            }
        }

        public Booking? Get(dynamic bookingNo)
        {
            CustomerDAO customerDAO = new CustomerDAO();
            bool isBookingCreated = false;
            Booking? booking = null;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT * FROM nc_Booking INNER JOIN nc_BookingLine ON nc_Booking.id = nc_BookingLine.bookingid WHERE bookingNo = @bookingNo", conn);
                command.Parameters.AddWithValue("@bookingNo", bookingNo);
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (!isBookingCreated) {
                                booking = new Booking()
                                {
                                    BookingNo = (string)reader["bookingNo"],
                                    StartTime = (DateTime)reader["startTime"],
                                    EndTime = (DateTime)reader["endTime"],
                                    PhoneNo = customerDAO.GetPhoneNo((int)reader["customerId"]),
                                };
                                isBookingCreated = true;
                            }

                            booking?.addToBookingLine(new BookingLine() { Quantity = (int)reader["quantity"], Stationid = (int)reader["stationid"], Consumableid = (int)reader["consumableid"] });
                        }
                        return booking;
                    }
                    catch (DataAccessException)
                    {

                        throw new DataAccessException("Can't access data");
                    }
                }
            }
        }

        public IEnumerable<Booking> GetAll()
        {
            string sqlStatement = "SELECT * FROM nc_Booking INNER JOIN nc_BookingLine ON nc_Booking.id = nc_BookingLine.bookingid";
            CustomerDAO customerDAO = new CustomerDAO();
            List<Booking> list = new List<Booking>();
            string? currentBoNo = null;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if ((string)reader["bookingNo"] == currentBoNo)
                        {
                            foreach (var item in list.ToList())
                            {
                                if (item.BookingNo == currentBoNo)
                                {
                                    item.addToBookingLine(new BookingLine() { Quantity = (int)reader["quantity"], Stationid = (int)reader["stationid"], Consumableid = (int)reader["consumableid"] });
                                }
                            }
                        }
                        else
                        {
                            currentBoNo = (string)reader["bookingNo"];
                            Booking newBooking = new Booking()
                            {
                                BookingNo = (string)reader["bookingNo"],
                                StartTime = (DateTime)reader["startTime"],
                                EndTime = (DateTime)reader["endTime"],
                                PhoneNo = customerDAO.GetPhoneNo((int)reader["customerId"]),
                            };
                            newBooking.addToBookingLine(new BookingLine() { Quantity = (int)reader["quantity"], Stationid = (int)reader["stationid"], Consumableid = (int)reader["consumableid"] });
                            list.Add(newBooking);
                        }
                    }
                }
                catch (DataAccessException)
                {

                    throw new DataAccessException("Can't access data");
                }
            }
            return list;
        }

        public bool Remove(dynamic key)
        {
            SqlTransaction trans;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                conn.Open();
                using (trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM nc_Booking WHERE BookingNo = @BookingNo", conn, trans))
                        {
                            deleteCommand.Parameters.AddWithValue("@BookingNo", key);
                            deleteCommand.ExecuteNonQuery();
                            trans.Commit();
                            return true;
                        }
                    }
                    catch (DataAccessException)
                    {
                        trans.Rollback();
                        throw new DataAccessException("Can't access data");
                    }
                }
            }
        }

        public bool Update(Booking o)
        {
            SqlTransaction trans;
            int rows = -1;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                conn.Open();
                using (trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand bookingCommand = new SqlCommand("UPDATE nc_Booking SET startTime = @startTime, endTime = @endTime WHERE BookingNo = @BookingNo", conn, trans))
                        {
                            bookingCommand.Parameters.AddWithValue("@BookingNo", o.BookingNo);
                            bookingCommand.Parameters.AddWithValue("@startTime", o.StartTime);
                            bookingCommand.Parameters.AddWithValue("@endTime", o.EndTime);
                            rows = bookingCommand.ExecuteNonQuery();
                        }
                        foreach (var item in o.BookingLines)
                        {
                            using (SqlCommand bookingLineCommand = new SqlCommand(
                                "UPDATE nc_BookingLine SET quantity = @quantity, stationid = @stationid, consumableid = @consumableid WHERE bookingid = (SELECT id FROM nc_Booking WHERE BookingNo = @BookingNo)", conn, trans))
                            {
                                bookingLineCommand.Parameters.AddWithValue("@BookingNo", o.BookingNo);
                                bookingLineCommand.Parameters.AddWithValue("@quantity", item.Quantity);
                                bookingLineCommand.Parameters.AddWithValue("@stationid", item.Stationid);
                                bookingLineCommand.Parameters.AddWithValue("@consumableid", item.Consumableid);
                                bookingLineCommand.ExecuteNonQuery();
                            }
                        }
                        trans.Commit();
                        if (rows > 0)
                        {
                            return true;
                        }
                        
                        return false;
                        
                    }
                    catch (DataAccessException)
                    {
                        trans.Rollback();
                        throw new DataAccessException("Can't access data");
                    }
                }
            }
        }
        public bool BookingCheck(DateTime startTime, DateTime endTime)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT stationid, startTime, endTime FROM nc_Booking INNER JOIN nc_BookingLine ON " +
                    "nc_Booking.id = nc_BookingLine.bookingid where startTime = @startTime AND endTime = @endTime", conn);
                command.Parameters.AddWithValue("@startTime", startTime);
                command.Parameters.AddWithValue("@endTime", endTime);
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        Console.WriteLine(reader.HasRows);
                        return reader.HasRows;
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