﻿using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.Model;
using System.Data.SqlClient;

namespace NetCafeUCN.DAL.DAO
{
    public class GamingStationDAO : INetCafeDAO<GamingStation>
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
                using SqlCommand command = new SqlCommand("SELECT id, productNo, name, description, productType, seatNo, isActive FROM " +
                    "nc_Product INNER JOIN nc_GamingStation ON nc_Product.id = nc_GamingStation.stationid WHERE productNo = @productNo;", conn);
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
                                ProductID = (int)reader["id"],
                                ProductNumber = (string)reader["productNo"],
                                Name = (string)reader["name"],
                                Description = (string)reader["description"],
                                Type = (string)reader["productType"],
                                SeatNumber = (string)reader["seatNo"],
                                IsActive = (bool)reader["isActive"]
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

            string sqlStatement = "SELECT id, productNo, name, description, productType, seatNo, IsActive FROM nc_Product " +
                "INNER JOIN nc_GamingStation ON nc_Product.id = nc_GamingStation.stationid";
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
                            ProductID = (int)reader["id"],
                            ProductNumber = (string)reader["productNo"],
                            Name = (string)reader["name"],
                            Description = (string)reader["description"],
                            Type = (string)reader["productType"],
                            SeatNumber = (string)reader["seatNo"],
                            IsActive = (bool)reader["isActive"]
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
                using SqlCommand command = new SqlCommand("UPDATE nc_Product SET isActive = 0 WHERE productNo = @productNo AND productType = 'gamingstation'", conn);
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
            int rows = -1;
            SqlTransaction trans;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                conn.Open();
                using (trans = conn.BeginTransaction())
                {
                    try
                    {
                        using(SqlCommand command = new SqlCommand(
                            "UPDATE nc_Product SET productType = @productType, name = @name, isActive = @isActive WHERE productNo = @productNo", conn, trans))
                        {
                            command.Parameters.AddWithValue("@productNo", o.ProductNumber);
                            command.Parameters.AddWithValue("@productType", o.Type);
                            command.Parameters.AddWithValue("@name", o.Name);
                            command.Parameters.AddWithValue("@isActive", o.IsActive);
                            rows = command.ExecuteNonQuery();
                        }
                        using (SqlCommand gcommand = new SqlCommand(
                            "UPDATE nc_Gamingstation SET seatNo = @seatNo, description = @description where stationid = (SELECT id FROM nc_Product WHERE productNo = @productNo)", conn, trans))
                        {
                            gcommand.Parameters.AddWithValue("@productNo", o.ProductNumber);
                            gcommand.Parameters.AddWithValue("@seatNo", o.SeatNumber);
                            gcommand.Parameters.AddWithValue("@description", o.Description);
                            gcommand.ExecuteNonQuery();
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
    }
}



