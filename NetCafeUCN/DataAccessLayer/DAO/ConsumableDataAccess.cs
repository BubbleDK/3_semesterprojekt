using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.Model;
using System.Data.SqlClient;

namespace NetCafeUCN.DAL.DAO
{
    public class ConsumableDataAccess : INetCafeDataAccess<Consumable>
    {
        public bool Add(Consumable o)
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
                            productCommand.Parameters.AddWithValue("@productNo", o.ProductNumber);
                            productCommand.Parameters.AddWithValue("@productType", o.Type);
                            productCommand.Parameters.AddWithValue("@name", o.Name);
                            productCommand.Parameters.AddWithValue("@isActive", "true");
                            id = Convert.ToInt32(productCommand.ExecuteScalar());
                        }


                        using (SqlCommand consumableCommand = new SqlCommand(
                                "INSERT INTO nc_Consumables VALUES(@productid, @description)", conn, trans))
                        {
                            consumableCommand.Parameters.AddWithValue("@productid", id);
                            consumableCommand.Parameters.AddWithValue("@description", o.Description);
                            consumableCommand.ExecuteNonQuery();
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
                        Consumable product = new Consumable()
                        {
                            ProductNumber = (string)reader["productNo"],
                            Name = (string)reader["name"],
                            Description = (string)reader["description"],
                            Type = (string)reader["productType"],
                            IsActive = (bool)reader["isActive"],
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
                using SqlCommand consumableCommand = new SqlCommand("UPDATE nc_Consumable SET description WHERE productNo = @productNo", conn);
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
