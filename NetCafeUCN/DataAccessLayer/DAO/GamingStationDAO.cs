using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.Model;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.DAO
{
    /* @authors Rasmus Gudiksen, Jakob Kjeldsteen, Emil Tolstrup Petersen, Christian Funder og Mark Drongesen
     * <summary>
     * Denne klasse styrer kontakten mellem database og systemet omhandlende Gamingstation
     * <summary/>
     */
    public class GamingStationDAO : INetCafeDAO<GamingStation>
    {
        /*
        * <summary>
	    * Metoden tilføjer en GamingStation en til databasen.
	    * <summary/>
	    * <param name="p">Er den GamingStation der bliver tilføjet til databasen</param>
	    * <returns>En bool<returns/>
	    */
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
        /*
        * <summary>
	    * Metoden henter en specifik GamingStation fra databasen.
	    * <summary/>
	    * <param name="key">Er et produkt nummer der bliver brugt til at finde en GamingStation</param>
	    * <returns>En GamingStation<returns/>
	    */
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
        /*
        * <summary>
	    * Metoden henter alle GamingStations fra databasen.
	    * <summary/>
	    * <returns>En liste af GamingStations<returns/>
	    */
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
        /*
        * <summary>
	    * Metoden opdaterer isActive på en GamingStation.
	    * <summary/>
	    * <param name="key">Er et produkt nummer der bliver brugt til at finde en GamingStation</param>
	    * <returns>En bool<returns/>
	    */
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
        //public bool Remove(dynamic key)
        //{
        //    SqlTransaction trans;
        //    int id = 0;
        //    using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
        //    {
        //        conn.Open();
        //        using (trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                using (SqlCommand command = new SqlCommand("SELECT id FROM nc_Product WHERE productNo = @productNo", conn, trans)) 
        //                { 
        //                    command.Parameters.AddWithValue("@productNo", key);
        //                    SqlDataReader reader = command.ExecuteReader();
        //                    while (reader.Read())
        //                    {
        //                        id = (int)reader["id"];
        //                    }
        //                    reader.Close();
        //                }
        //                using (SqlCommand updateCommand = new SqlCommand("UPDATE nc_BookingLine SET stationid = @id WHERE stationid = @id", conn, trans))
        //                {
        //                    updateCommand.Parameters.AddWithValue("@id", id);
        //                    updateCommand.ExecuteNonQuery();
        //                }
        //                using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM nc_Product WHERE id = @id", conn, trans))
        //                {
        //                    deleteCommand.Parameters.AddWithValue("@id", id);
        //                    deleteCommand.ExecuteNonQuery();
        //                    trans.Commit();
        //                    return true;
        //                }
        //            }
        //            catch (DataAccessException)
        //            {
        //                trans.Rollback();
        //                throw new DataAccessException("Can't access data");
        //            }
        //        }
        //    }
        //}

        /*
        * <summary>
	    * Metoden opdaterer en GamingStation fra databasen.
	    * <summary/>
	    * <param name="o">Er den opdateret GamingStation</param>
	    * <returns>En bool<returns/>
	    */
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



