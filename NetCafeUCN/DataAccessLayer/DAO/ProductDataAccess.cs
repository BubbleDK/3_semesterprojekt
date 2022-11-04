using DataAccessLayer.Exceptions;
using DataAccessLayer.Model;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;
using System.Data.SqlClient;

namespace DataAccessLayer.DAO
{
    public class ProductDataAccess : INetCafeDataAccess<Product>
    {
        public int Add(Product o)
        {
            throw new NotImplementedException();
        }

        public Product? Get(dynamic productNo)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString)) {
                using (SqlCommand command = new SqlCommand("SELECT * FROM nc_Product, nc_GamingStation WHERE productNo = @productNo", conn))
                {
                    command.Parameters.AddWithValue("productNo", productNo);
                    {
                        try
                        {
                            conn.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                Product product = new GamingStation()
                                {
                                    ProductNumber = (string)reader["productNo"],
                                    Description = (string)reader["description"],
                                    SeatNumber = (string)reader["seatNo"],
                                    Tier = (int)reader["tier"],
                                    Booked = (bool)reader["booked"]
                                };
                                return product;
                            }
                        }
                        catch (DataAccessException)
                        {

                            throw new DataAccessException("Can't access data");
                        }
                    }
                }
            }
           return null;
        }
    

        public IEnumerable<Product> GetAll()
        {
            string sqlStatement = "SELECT * FROM nc_Product, nc_GamingStation WHERE productType = 'gamingstation'";
            List<Product> list = new List<Product>();
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new GamingStation()
                        {
                            ProductNumber = (string)reader["productNo"],
                            Description = (string)reader["description"],
                            SeatNumber = (string)reader["seatNo"],
                            Tier = (int)reader["tier"],
                            Booked = (bool)reader["booked"]
                        };
                        list.Add(product);
                    }
                }
                catch (DataAccessException)
                {

                    throw new DataAccessException("Can't access data");
                }
            }
            return list;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product o)
        {
            throw new NotImplementedException();
        }
    }
}
