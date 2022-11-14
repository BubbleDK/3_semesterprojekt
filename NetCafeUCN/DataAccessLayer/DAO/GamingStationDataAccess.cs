﻿using DataAccessLayer.DAO;
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
    public class GamingStationDataAccess : INetCafeDataAccess<GamingStation>
    {
        public bool Add(GamingStation p)
        {
            SqlTransaction trans = null;
            int id = 0;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                try
                {
                    using (SqlCommand productCommand = new SqlCommand(
                            "INSERT INTO nc_Product VALUES(@productNo, @productType, @name, @isActive)", conn))
                    {
                        productCommand.Parameters.AddWithValue("@productNo", p.ProductNumber);
                        productCommand.Parameters.AddWithValue("@productType", p.Type);
                        productCommand.Parameters.AddWithValue("@name", p.Name);
                        productCommand.Parameters.AddWithValue("@isActive", 1);
                        
                        using (SqlCommand command = new SqlCommand(
                            "INSERT INTO nc_GamingStation VALUES(@stationid, @seatNo, @description)", conn))
                        {
                            command.Parameters.AddWithValue("@stationid", id);
                            command.Parameters.AddWithValue("@seatNo", p.SeatNumber);
                            command.Parameters.AddWithValue("@description", p.Description);
                            conn.Open();
                            trans = conn.BeginTransaction();
                            id = Convert.ToInt32(productCommand.ExecuteScalar());
                            command.ExecuteNonQuery();
                            trans.Commit();
                        }
                    }
                }
                catch (DataAccessException)
                {
                    trans.Rollback();
                    throw new DataAccessException("Can't access data");
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
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                using SqlCommand command = new SqlCommand("UPDATE nc_Product SET name = @name, IsActive = @isactive WHERE productNo = @productNo", conn);
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

