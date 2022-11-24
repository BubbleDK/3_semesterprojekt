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
    public class PackDao : INetCafeDAO<Pack>
    {
        public bool Add(Pack o)
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
                                "INSERT INTO nc_Product VALUES(@productNo, @type, @name, @isActive); SELECT SCOPE_IDENTITY();", conn, trans))
                        {
                            productCommand.Parameters.AddWithValue("@productNo", o.ProductNumber);
                            productCommand.Parameters.AddWithValue("@type", o.Type);
                            productCommand.Parameters.AddWithValue("@name", o.Name);
                            productCommand.Parameters.AddWithValue("@isActive", o.IsActive);
                            id = Convert.ToInt32(productCommand.ExecuteScalar());
                        }
                        using(SqlCommand packCommand = new SqlCommand(
                                "INSERT INTO nc_Pack VALUES(@productid);", conn, trans))
                        {
                            packCommand.Parameters.AddWithValue("@productid", id);
                            packCommand.ExecuteNonQuery();
                        }
                        foreach(var item in o.PackLines)
                        {
                            using (SqlCommand packCommand = new SqlCommand(
                                "INSERT INTO nc_PackLine VALUES(@productid, @quantity, @packid);", conn, trans))
                            {
                                int productid = GetProductById(item.Product.ProductNumber);
                                packCommand.Parameters.AddWithValue("@productid", productid);
                                packCommand.Parameters.AddWithValue("@quantity", item.Quantity);
                                packCommand.Parameters.AddWithValue("@packid", id);
                                packCommand.ExecuteNonQuery();
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

        public Pack? Get(dynamic key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pack> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(dynamic key)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pack o)
        {
            throw new NotImplementedException();
        }

        private int GetProductById(dynamic key)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                using SqlCommand command = new SqlCommand("SELECT * FROM nc_Product productNo = @productNo;", conn);
                command.Parameters.AddWithValue("@productNo", key);
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                                int id = Convert.ToInt32(reader["id"]);
                                return id;
                        }
                    }
                    catch (DataAccessException)
                    {

                        throw new DataAccessException("Can't access data");
                    }
                }
            }
            return 0;
        }
    }
}
