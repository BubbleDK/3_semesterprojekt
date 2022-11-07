using DataAccessLayer.DAO;
using DataAccessLayer.Exceptions;
using DataAccessLayer.Model;
using NetCafeUCN.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.DAO
{
    public class GamingStationDataAccess : INetCafeDataAccess<GamingStation>
    {
        public bool Add(GamingStation o)
        {
            throw new NotImplementedException();
        }

        public GamingStation? Get(dynamic key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GamingStation> GetAll()
        {
            string sqlStatement = "SELECT * FROM nc_Product, nc_GamingStation WHERE productType = 'gamingstation'";
            List<GamingStation> list = new List<GamingStation>();
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
                            GamingStation product = new GamingStation()
                            {
                                ProductNumber = (string)reader["productNo"],
                                Description = (string)reader["description"],
                                Type = (string)reader["productType"],
                                SeatNumber = (string)reader["seatNo"],

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
    

        public bool Remove(dynamic key)
        {
            throw new NotImplementedException();
        }

        public bool Update(GamingStation o)
        {
            throw new NotImplementedException();
        }
    }
}
