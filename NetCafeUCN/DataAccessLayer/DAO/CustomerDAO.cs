using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.Model;
using System.Data.SqlClient;

namespace NetCafeUCN.DAL.DAO
{
    public class CustomerDAO : INetCafeDAO<Customer>
    {
        public bool Add(Customer o)
        {
            if(GetPhoneNo(o.Phone) == true) return false;
            if(EmailCheck(o.Email) == true) return false;
            SqlTransaction trans;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                conn.Open();
                using (trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand addToPersonCommand = new SqlCommand(
                            "INSERT INTO nc_Person VALUES(@name, @phone, @email, @personType, @password, @isActive); SELECT SCOPE_IDENTITY();", conn, trans))
                        {
                            addToPersonCommand.Parameters.AddWithValue("@name", o.Name);
                            addToPersonCommand.Parameters.AddWithValue("@email", o.Email);
                            addToPersonCommand.Parameters.AddWithValue("@phone", o.Phone);
                            addToPersonCommand.Parameters.AddWithValue("@personType", o.PersonType);
                            addToPersonCommand.Parameters.AddWithValue("@password", o.Password);
                            addToPersonCommand.Parameters.AddWithValue("@isActive", o.IsActive);
                            addToPersonCommand.ExecuteNonQuery();
                        }
                        using (SqlCommand addToCustomerCommand = new SqlCommand("INSERT INTO nc_Customer VALUES(@phone)", conn, trans))
                        {
                            addToCustomerCommand.Parameters.AddWithValue("@phone", o.Phone);
                            addToCustomerCommand.ExecuteNonQuery();
                            trans.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
                return true;
            }
        }
        public Customer? Get(dynamic key)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM nc_Person WHERE phone = @phone",conn);
                command.Parameters.AddWithValue("@phone", key);
                {
                    Customer? customer = null;
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            customer = new Customer()
                            {
                                Name = (string)reader["Name"],
                                Email = (string)reader["email"],
                                Phone = (string)reader["phone"],
                                PersonType = (string)reader["personType"],
                                IsActive = (bool)reader["isActive"]
                            };
                        }
                        return customer;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
        public IEnumerable<Customer> GetAll()
        {
            string sqlStatement = "SELECT * FROM nc_Customer inner join nc_Person on nc_Person.phone = nc_Customer.phone";
            List<Customer> list = new();
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Customer customer = new Customer()
                        {
                            Name = (string?)reader["name"],
                            Email = (string?)reader["email"],
                            Phone = (string?)reader["phone"],
                            PersonType = (string)reader["personType"],
                            IsActive = (bool)reader["isActive"]
                        };
                        list.Add(customer);
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
            SqlTransaction trans;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                conn.Open();
                using (trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand deleteCommand = new SqlCommand("UPDATE nc_Person SET isActive = 0 WHERE phone = @phoneNo AND personType = 'Customer'", conn, trans))
                        {
                            deleteCommand.Parameters.AddWithValue("@phoneNo", key);
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
        public bool Update(Customer o)
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
                        using (SqlCommand command = new SqlCommand(
                            "UPDATE nc_Person SET name = @name, phone = @phone, email = @email, personType = @personType, isActive = @isActive WHERE phone = @phone AND personType = 'Customer'", conn, trans))
                        {
                            command.Parameters.AddWithValue("@phone", o.Phone);
                            command.Parameters.AddWithValue("@name", o.Name);
                            command.Parameters.AddWithValue("@email", o.Email);
                            command.Parameters.AddWithValue("@personType", o.PersonType);
                            command.Parameters.AddWithValue("@isActive", o.IsActive);
                            rows = command.ExecuteNonQuery();
                            trans.Commit();
                            if (rows > 0)
                            {
                                return true;
                            }
                            return false;
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

        /// <summary>
        /// Metode til at check om email eksistere
        /// </summary>
        /// <param name="email">string af den email som skal tjekkes</param>
        /// <returns>bool afhængig af statussen på operationen</returns>
        /// <exception cref="DataAccessException"></exception>
        public bool EmailCheck(string email)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT email FROM nc_Person WHERE email = @email", conn);
                command.Parameters.AddWithValue("@email", email);
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else { return false; }
                    }
                    catch (Exception)
                    {
                        throw new DataAccessException("Can't access data");
                    }
                }
            }
        }

        /// <summary>
        /// Metode til at tjekke om telefon nummeret eksistere
        /// </summary>
        /// <param name="key">Dymaisk nøgle som bruges som søge parametre</param>
        /// <returns>bool afhængig af statussen på operationen</returns>
        /// <exception cref="DataAccessException"></exception>
        public bool GetPhoneNo(dynamic key)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT phone FROM nc_Person WHERE phone = @phone", conn);
                command.Parameters.AddWithValue("@phone", key);
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if(reader.HasRows)
                        {
                            return true;
                        }
                        else { return false; }
                    }
                    catch (Exception)
                    {
                        throw new DataAccessException("Can't access data");
                    }
                }
            }
        }
    }
}
