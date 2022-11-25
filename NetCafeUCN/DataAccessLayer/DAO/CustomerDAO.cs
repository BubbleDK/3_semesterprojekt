using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.Model;
using System.Data.SqlClient;

namespace NetCafeUCN.DAL.DAO
{
    public class CustomerDAO : INetCafeDAO<Customer>
    {
        public bool Add(Customer o)
        {
            SqlTransaction trans;
            int id = -1;
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
                            id = Convert.ToInt32(addToPersonCommand.ExecuteScalar());
                        }
                        using (SqlCommand addToCustomerCommand = new SqlCommand("INSERT INTO nc_Customer VALUES(@personid)", conn, trans))
                        {
                            addToCustomerCommand.Parameters.AddWithValue("@personid", id);
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
            string sqlStatement = "SELECT * FROM nc_Customer inner join nc_Person on nc_Person.id = nc_Customer.personid";
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
                            command.ExecuteNonQuery();
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
