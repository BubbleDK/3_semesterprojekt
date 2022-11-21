using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.Model;
using System.Data.SqlClient;

namespace NetCafeUCN.DAL.DAO
{
    public class BookingDAO : INetCafeDAO<Booking>
    {
        public bool Add(Booking o)
        {
            SqlTransaction trans;
            int id = 0;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                conn.Open();
                using (trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand bookingCommand = new SqlCommand(
                                "INSERT INTO nc_Booking VALUES(@bookingNo, @startTime, @endTime, @customerId); SELECT SCOPE_IDENTITY();", conn, trans))
                        {
                            bookingCommand.Parameters.AddWithValue("@bookingNo", o.BookingNo);
                            bookingCommand.Parameters.AddWithValue("@startTime", o.StartTime);
                            bookingCommand.Parameters.AddWithValue("@endTime", o.EndTime);
                            bookingCommand.Parameters.AddWithValue("@customerId", o.CustomerId);
                            id = Convert.ToInt32(bookingCommand.ExecuteScalar());
                        }

                        using (SqlCommand bookingLineCommand = new SqlCommand(
                                "INSERT INTO nc_BookingLine VALUES(@bookingid, @quantity, @stationid, @consumableid)", conn, trans))
                        {
                            foreach (var item in o.BookingLines)
                            {
                                bookingLineCommand.Parameters.AddWithValue("@bookingid", id);
                                bookingLineCommand.Parameters.AddWithValue("quantity", item.Quantity);
                                bookingLineCommand.Parameters.AddWithValue("@stationid", item.Stationid);
                                bookingLineCommand.Parameters.AddWithValue("@consumableid", item.Consumableid);
                                bookingLineCommand.ExecuteNonQuery();
                            }
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

        public Booking? Get(dynamic bookingNo)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT nc_Consumables.description, nc_Product.productNo, nc_Product.productType, nc_Product.name, nc_Product.isActive FROM nc_Product INNER JOIN nc_Consumables ON nc_Product.id = nc_Consumables.productid WHERE productNo = @productNo", conn);
                command.Parameters.AddWithValue("@productNo", bookingNo);
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Booking booking = new Booking()
                            {
                                Id = (int)reader["id"],
                                BookingNo = (int)reader["bookingNo"],
                                StartTime = (DateTime)reader["startTime"],
                                EndTime = (DateTime)reader["endTime"],
                                CustomerId = (int)reader["customerId"],
                            };
                            return booking;
                        }
                    }
                    catch (DataAccessException)
                    {

                        throw new DataAccessException("Can't access data");
                    }
                }
            }
            return null;
        }

        public IEnumerable<Booking> GetAll()
        {
            string sqlStatement = "SELECT * FROM nc_Booking";
            string sqlBookingLinesStatement = "SELECT * FROM nc_BookingLine WHERE bookingid = @id";
            List<Booking> list = new List<Booking>();
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                SqlCommand bookingLinesCMD = new SqlCommand(sqlBookingLinesStatement, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Booking booking = new Booking()
                        {
                            Id = (int)reader["id"],
                            BookingNo = (int)reader["bookingNo"],
                            StartTime = (DateTime)reader["startTime"],
                            EndTime = (DateTime)reader["endTime"],
                            CustomerId = (int)reader["customerId"],
                        };
                        list.Add(booking);

                        SqlDataReader read = bookingLinesCMD.ExecuteReader();
                        while (read.Read())
                        {
                            foreach (var item in list)
                            {
                                if ((int)reader["id"] == (int)read["bookingid"])
                                {
                                    item.addToBookingLine(new BookingLine((int)read["bookingid"], (int)read["quantity"], (int)read["stationid"], (int)read["consumableid"]));
                                }
                            }
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
            throw new NotImplementedException();
        }

        public bool Update(Booking o)
        {
            throw new NotImplementedException();
        }
    }
}