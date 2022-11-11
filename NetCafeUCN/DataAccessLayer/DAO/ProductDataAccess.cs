using DataAccessLayer.Exceptions;
using DataAccessLayer.Model;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DataAccessLayer.DAO
{
    public class ProductDataAccess : INetCafeDataAccess<Product>
    {
        public bool Add(Product p)
        {
            SqlCommand command = new SqlCommand();
            int id = 0;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                try
                {
                    using (SqlCommand productCommand = new SqlCommand(
                            "INSERT INTO nc_Product VALUES(@productNo, @productType, @name, @isActive)", conn))
                    {
                        productCommand.Parameters.AddWithValue("@productNo", p.ProductNumber);
                        productCommand.Parameters.AddWithValue("productType", p.Type);
                        productCommand.Parameters.AddWithValue("@name", p.Name);
                        productCommand.Parameters.AddWithValue("@isActive", 1);
                        conn.Open();
                        id = (int)productCommand.ExecuteScalar();
                    }
                    
                    if (p.Type == "gamingstation")
                    {
                        p = p as GamingStation;
                        using (command = new SqlCommand(
                            "INSERT INTO nc_GamingStation VALUES(@stationid, @seatNo, @description)", conn))
                        {
                            command.Parameters.AddWithValue("@stationid", id);
                            command.Parameters.AddWithValue("seatNo", p);
                            command.Parameters.AddWithValue("description", p);
                        }
                    } else if (p.Type == "consmuable")
                    {
                        p = p as Consumable;
                        using (command = new SqlCommand(
                            "INSERT INTO nc_Consumables VALUES(@description", conn))
                        {
                            command.Parameters.AddWithValue("description", p);
                        }
                    }
                    conn.Open();
                    command.ExecuteNonQuery();
                }
                catch (DataAccessException)
                {
                    throw new DataAccessException("Can't access data");
                }
            }
            return false;
        }

        public Product? Get(dynamic productNo)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString)) {
                using SqlCommand command = new SqlCommand("SELECT * FROM nc_Product, nc_GamingStation, nc_Consumables WHERE productNo = @productNo", conn);
                command.Parameters.AddWithValue("@productNo", productNo);
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if ((int)reader["isActive"] != 0)
                            {

                                if ((string)reader["productType"] == "gamingstation")
                                {
                                    Product product = new GamingStation()
                                    {
                                        ProductNumber = (string)reader["productNo"],
                                        Name = (string)reader["name"],
                                        Description = (string)reader["description"],
                                        Type = (string)reader["productType"],
                                        SeatNumber = (string)reader["seatNo"],
                                    };
                                    return product;
                                }
                                else
                                {
                                    Product product = new Consumable()
                                    {
                                        ProductNumber = (string)reader["productNo"],
                                        Name = (string)reader["name"],
                                        Description = (string)reader["description"],
                                        Type = (string)reader["productType"],
                                    };
                                    return product;
                                }
                            }
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
    

        public IEnumerable<Product> GetAll()
        {
            string sqlStatement = "SELECT * FROM nc_Product, nc_GamingStation, nc_Consumables";
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
                        if ((string)reader["productType"] == "gamingstation" & (int)reader["isActive"] != 0)
                        {
                            Product product = new GamingStation()
                            {
                                ProductNumber = (string)reader["productNo"],
                                Name = (string)reader["name"],
                                Description = (string)reader["description"],
                                Type = (string)reader["productType"],
                                SeatNumber = (string)reader["seatNo"],

                            };
                            list.Add(product);
                        }
                        else
                        {
                            Product product = new Consumable()
                            {
                                ProductNumber = (string)reader["productNo"],
                                Name = (string)reader["name"],
                                Description = (string)reader["description"],
                                Type = (string)reader["productType"],
                            };
                            list.Add(product);
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

        //public bool Remove(dynamic id)
        //{
        //    int indentifier = 0;
        //    using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
        //    {
        //        using SqlCommand command = new SqlCommand("DELETE FROM nc_Product WHERE productNo = @productNo", conn);
        //        using SqlCommand sCommand = new SqlCommand("SELECT id FROM nc_Product WHERE productNo = @productNo", conn);
        //        using SqlCommand uCommand = new SqlCommand("UPDATE nc_BookingLine SET stationid = @stationid WHERE stationid = @stationid", conn);
        //        sCommand.Parameters.AddWithValue("@productNo", id);
        //        try
        //        {
        //            conn.Open();
        //            SqlDataReader reader = sCommand.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                indentifier = (int)reader["id"];
        //            }
        //            reader.Close();
        //            uCommand.Parameters.AddWithValue("@stationid", indentifier);
        //            command.Parameters.AddWithValue("@productNo", id);
        //            uCommand.ExecuteNonQuery();
        //            command.ExecuteNonQuery();
        //        }
        //        catch (DataAccessException)
        //        {

        //            throw new DataAccessException("Can't access data");
        //        }
        //    }
        //    throw new NotImplementedException();
        //}

        public bool Remove(dynamic id)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                using SqlCommand command = new SqlCommand("UPDATE nc_Product SET IsActive = 0 WHERE productNo = @productNo", conn);
                command.Parameters.AddWithValue("@productNo", id);
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
        public bool Update(Product o)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                using SqlCommand command = new SqlCommand("UPDATE nc_Product SET IsActive = 0 WHERE productNo = @productNo", conn);
                command.Parameters.AddWithValue("@productNo", o.ProductNumber);
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
    }
}
