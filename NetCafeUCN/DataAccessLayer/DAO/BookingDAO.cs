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
            SqlTransaction trans;
            int id = 0;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                conn.Open();
                using (trans = conn.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        foreach (var item in o.BookingLines)
                        {
                            Console.WriteLine(BookingCheck(o.StartTime, o.EndTime, item.StationId));
                            if (BookingCheck(o.StartTime, o.EndTime, item.StationId)) return false;
                        }
                        using (SqlCommand bookingCommand = new SqlCommand(
                                "INSERT INTO nc_Booking VALUES(@bookingNo, @startTime, @endTime, @phoneNo); SELECT SCOPE_IDENTITY();", conn, trans))
                        {
                            bookingCommand.Parameters.AddWithValue("@bookingNo", o.BookingNo);
                            bookingCommand.Parameters.AddWithValue("@startTime", o.StartTime);
                            bookingCommand.Parameters.AddWithValue("@endTime", o.EndTime);
                            bookingCommand.Parameters.AddWithValue("@phoneNo", o.PhoneNo);
                            id = Convert.ToInt32(bookingCommand.ExecuteScalar());
                        }
                        foreach (var item in o.BookingLines)
                        {
                            using (SqlCommand bookingLineCommand = new SqlCommand(
                                "INSERT INTO nc_BookingLine VALUES(@bookingid, @quantity, @stationid, @consumableid)", conn, trans))
                            {
                                bookingLineCommand.Parameters.AddWithValue("@bookingid", id);
                                bookingLineCommand.Parameters.AddWithValue("@quantity", item.Quantity);
                                bookingLineCommand.Parameters.AddWithValue("@stationid", item.StationId);
                                bookingLineCommand.Parameters.AddWithValue("@consumableid", item.ConsumableId);
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
                                    PhoneNo = (string)reader["phone"],
                                };
                                isBookingCreated = true;
                            }

                            booking?.addToBookingLine(new BookingLine() { Quantity = (int)reader["quantity"], StationId = (int)reader["stationid"], ConsumableId = (int)reader["consumableid"] });
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
        //TODO: FIX: Skal ikke hente bookinglines her, da bookinglines gør det slow. Samtidigt skal telefonnumre gemmes på ordren i stedet for id.
        public IEnumerable<Booking> GetAll()
        {
            string sqlStatement = "SELECT * FROM nc_Booking";
            List<Booking> bookingList = new List<Booking>();

            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bookingList.Add(new Booking()
                        {
                            BookingNo = (string)reader["BookingNo"],
                            StartTime = (DateTime)reader["startTime"],
                            EndTime = (DateTime)reader["endTime"],
                            PhoneNo = (string)reader["Phone"]
                        });
                    }
                    return bookingList;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            
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
                                bookingLineCommand.Parameters.AddWithValue("@stationid", item.StationId);
                                bookingLineCommand.Parameters.AddWithValue("@consumableid", item.ConsumableId);
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
        private bool BookingCheck(DateTime startTime, DateTime endTime, int stationid)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT stationid, startTime, endTime FROM nc_Booking INNER JOIN nc_BookingLine ON " +
                    "nc_Booking.id = nc_BookingLine.bookingid where startTime = @startTime AND endTime = @endTime AND stationid = @stationid", conn);
                command.Parameters.AddWithValue("@startTime", startTime);
                command.Parameters.AddWithValue("@endTime", endTime);
                command.Parameters.AddWithValue("@stationid", stationid);
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
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