using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NetCafeUCN.DAL.DAO
{
    /* @authors Rasmus Gudiksen, Jakob Kjeldsteen, Emil Tolstrup Petersen, Christian Funder og Mark Drongesen
     * <summary>
     * Denne klasse styrer kontakten mellem database og systemet omhandlende Consumable
     * <summary/>
     */
    public class ConsumableDAO : INetCafeDAO<Consumable>
    {
        /*
        * <summary>
	    * Metoden tilføjer en Consumable en til databasen.
	    * <summary/>
	    * <param name="o">Er den Consumable der bliver tilføjet til databasen</param>
	    * <returns>En bool<returns/>
	    */
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
        /*
        * <summary>
	    * Metoden henter en specifik Consumable fra databasen.
	    * <summary/>
	    * <param name="productNo">Er et produkt nummer der bliver brugt til at finde en Consumable</param>
	    * <returns>En Consumable<returns/>
	    */
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
                            Consumable product = new Consumable()
                            {
                                ProductNumber = (string)reader["productNo"],
                                Name = (string)reader["name"],
                                Description = (string)reader["description"],
                                Type = (string)reader["productType"],
                                IsActive = (bool)reader["isActive"],
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
        /*
        * <summary>
	    * Metoden henter alle Consumable fra databasen.
	    * <summary/>
	    * <returns>En liste af Consumable<returns/>
	    */
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
        /*
        * <summary>
	    * Metoden opdaterer isActive på en Consumable.
	    * <summary/>
	    * <param name="key">Er et produkt nummer der bliver brugt til at finde en Consumable</param>
	    * <returns>En bool<returns/>
	    */
        public bool Remove(dynamic key)
        {
            SqlTransaction trans;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                conn.Open();
                using (trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM nc_Product WHERE productNo = @productNo", conn, trans))
                        {
                            deleteCommand.Parameters.AddWithValue("@productNo", key);
                            deleteCommand.ExecuteNonQuery();
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
        /*
        * <summary>
	    * Metoden opdaterer en Consumable fra databasen.
	    * <summary/>
	    * <param name="o">Er den opdateret Consumable</param>
	    * <returns>En bool<returns/>
	    */
        public bool Update(Consumable o)
        {
            SqlTransaction trans;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                conn.Open();
                using (trans = conn.BeginTransaction())
                {
                    try
                    { 
                        using(SqlCommand productCommand = new SqlCommand("UPDATE nc_Product SET productType = @productType, name = @name, isActive = @isActive WHERE productNo = @productNo", conn, trans))
                        {
                            productCommand.Parameters.AddWithValue("@productType", o.Type);
                            productCommand.Parameters.AddWithValue("@name", o.Name);
                            productCommand.Parameters.AddWithValue("@isActive", o.IsActive);
                            productCommand.Parameters.AddWithValue("@productNo", o.ProductNumber);
                            productCommand.ExecuteNonQuery();
                        }
                        using(SqlCommand consumableCommand = new SqlCommand(
                            "UPDATE nc_Consumables SET description = @description WHERE productid = (SELECT id FROM nc_Product WHERE productNo = @productNo)", conn, trans))
                        {
                            consumableCommand.Parameters.AddWithValue("@description", o.Description);
                            consumableCommand.Parameters.AddWithValue("@productNo", o.ProductNumber);
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
    }
}
