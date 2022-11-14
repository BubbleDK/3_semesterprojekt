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
    public class ConsumableDataAccess : INetCafeDataAccess<Consumable>
    {
        public bool Add(Consumable o)
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
                        productCommand.Parameters.AddWithValue("@productNo", o.ProductNumber);
                        productCommand.Parameters.AddWithValue("productType", o.Type);
                        productCommand.Parameters.AddWithValue("@name", o.Name);
                        productCommand.Parameters.AddWithValue("@isActive", 1);
                        conn.Open();
                        id = (int)productCommand.ExecuteScalar();
                    }

                    using (SqlCommand consumableCommand = new SqlCommand(
                            "INSERT INTO nc_Consumable VALUES(@productid, @description)", conn))
                    {
                        consumableCommand.Parameters.AddWithValue("@productid", id);
                        consumableCommand.Parameters.AddWithValue("@description", o.Description);
                        conn.Open();
                        consumableCommand.ExecuteNonQuery();
                    }
                }
                catch (DataAccessException)
                {
                    throw new DataAccessException("Can't access data");
                }
            }

            return false;
        }

        public Consumable? Get(dynamic productNo)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT nc_Consumables.description, nc_Product.productNo, nc_Product.productType, nc_Product.name, nc_Product.isActive FROM nc_Product INNER JOIN nc_Consumables ON nc_Product.id = nc_Consumables.productid WHERE productNo = @productNo", conn);
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
                                Consumable product = new Consumable()
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
                    catch (DataAccessException)
                    {

                        throw new DataAccessException("Can't access data");
                    }
                }
            }
            return null;
        }

        public IEnumerable<Consumable> GetAll()
        {
            string sqlStatement = "SELECT nc_Consumables.description, nc_Product.productNo, nc_Product.productType, nc_Product.name, nc_Product.isActive FROM nc_Product INNER JOIN nc_Consumables ON nc_Product.id = nc_Consumables.productid";
            List<Consumable> list = new List<Consumable>();
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if ((int)reader["isActive"] != 0)
                        {
                            Consumable product = new Consumable()
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

        public bool Remove(dynamic productNo)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                using SqlCommand command = new SqlCommand("UPDATE nc_Product SET IsActive = 0 WHERE productNo = @productNo", conn);
                command.Parameters.AddWithValue("@productNo", productNo);
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

        public bool Update(Consumable o)
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
