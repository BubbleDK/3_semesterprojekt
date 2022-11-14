using DataAccessLayer.DAO;
using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NetCafeUCN.DAL.DAO
{
    public class GamingStationDataAccess : INetCafeDataAccess<GamingStation>
    {
        public bool Add(GamingStation p)
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
                        using (SqlCommand productCommand = new SqlCommand(
                                "INSERT INTO nc_Product VALUES(@productNo, @productType, @name, @isActive); SELECT SCOPE_IDENTITY();", conn, trans))
                        {
                            productCommand.Parameters.AddWithValue("@productNo", p.ProductNumber);
                            productCommand.Parameters.AddWithValue("@productType", p.Type);
                            productCommand.Parameters.AddWithValue("@name", p.Name);
                            productCommand.Parameters.AddWithValue("@isActive", 1);
                            id = Convert.ToInt32(productCommand.ExecuteScalar());
                        }

                        using (SqlCommand command = new SqlCommand(
                            "INSERT INTO nc_GamingStation VALUES(@stationid, @seatNo, @description)", conn, trans))
                        {
                            command.Parameters.AddWithValue("@stationid", id);
                            command.Parameters.AddWithValue("@seatNo", p.SeatNumber);
                            command.Parameters.AddWithValue("@description", p.Description);
                            command.ExecuteNonQuery();
                            trans.Commit();
                        }
                    }
                    catch (DataAccessException)
                    {
                        trans.Rollback();
                        throw new DataAccessException("Can't access data");
                    }
                }
            }
            return true;
        }

        public GamingStation? Get(dynamic key)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT productNo, name, description, productType, seatNo FROM nc_Product INNER JOIN nc_GamingStation ON nc_Product.id = nc_GamingStation.stationid WHERE productNo = @productNo;", conn);
                command.Parameters.AddWithValue("@productNo", key);
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                                    GamingStation product = new GamingStation()
                                    {
                                        ProductNumber = (string)reader["productNo"],
                                        Name = (string)reader["name"],
                                        Description = (string)reader["description"],
                                        Type = (string)reader["productType"],
                                        SeatNumber = (string)reader["seatNo"],
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
            return null;
        }
    

        public IEnumerable<GamingStation> GetAll()
        {

            string sqlStatement = "SELECT productNo, name, description, productType, seatNo FROM nc_Product INNER JOIN nc_GamingStation ON nc_Product.id = nc_GamingStation.stationid";
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
                                GamingStation product = new()
                                {
                                    ProductNumber = (string)reader["productNo"],
                                    Name = (string)reader["name"],
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
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                using SqlCommand command = new SqlCommand("UPDATE nc_Product SET IsActive = 0 WHERE productNo = @productNo AND productType = 'gamingstation'", conn);
                command.Parameters.AddWithValue("@productNo", key);
                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (DataAccessException)
                {
                    throw new DataAccessException("Can't access data");
                }
            }
        }

        public bool Update(GamingStation o)
        {
            SqlTransaction trans;
            int id = 0;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                conn.Open();
                using (trans = conn.BeginTransaction())
                {
                    using SqlCommand command = new SqlCommand("UPDATE nc_Product SET name = @name, IsActive = @isactive WHERE productNo = @productNo; SCOPE_IDENTITY()", conn, trans);
                    using SqlCommand gCommand = new SqlCommand("UPDATE nc_GamingStation SET seatNo = @seatNo, description = @description WHERE stationid = @id", conn, trans);
                    command.Parameters.AddWithValue("@name", o.Name);
                    command.Parameters.AddWithValue("@productNo", o.ProductNumber);
                    command.Parameters.AddWithValue("@isActive", o.IsActive);
                    try
                    {
                        id = Convert.ToInt32(command.ExecuteScalar());
                        gCommand.Parameters.AddWithValue("@seatNo", o.SeatNumber);
                        gCommand.Parameters.AddWithValue("@description", o.Description);
                        gCommand.Parameters.AddWithValue("@stationid", id);
                        gCommand.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (DataAccessException)
                    {
                        trans.Rollback();
                        throw new DataAccessException("Can't access data");
                    }
                }
            }
            return true;
        }
    }
}

