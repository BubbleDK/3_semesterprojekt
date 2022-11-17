using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.Model;
using System.Data.SqlClient;

namespace NetCafeUCN.DAL.DAO
{
    public class CustomerDAO : INetCafeDAO<Customer>
    {
        public bool Add(Customer o)
        {
            int id = -1;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                try
                {
                    using (SqlCommand addToPersonCommand = new SqlCommand(
                        "INSERT INTO nc_Person VALUES(@Name, @Phone, @Email, @PersonType) SELECT SCOPE_IDENTITY();", conn))
                    {
                        addToPersonCommand.Parameters.AddWithValue("@Name", o.Name);
                        addToPersonCommand.Parameters.AddWithValue("@Email", o.Email);
                        addToPersonCommand.Parameters.AddWithValue("@Phone", o.Phone);
                        addToPersonCommand.Parameters.AddWithValue("@PersonType", o.PersonType);
                        conn.Open();
                        id = Convert.ToInt32(addToPersonCommand.ExecuteScalar());
                    }
                    using (SqlCommand addToCustomerCommand = new SqlCommand("INSERT INTO nc_Customer VALUES(@id)", conn))
                    {
                        addToCustomerCommand.Parameters.AddWithValue("@id", id);
                        addToCustomerCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {

                    throw;
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
                                PersonType = (string)reader["PersonType"]
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
                            Phone = (string?)reader["phone"]
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
            throw new NotImplementedException();
        }

        public bool Update(Customer o)
        {
            throw new NotImplementedException();
        }
    }
}
