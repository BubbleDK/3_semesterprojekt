using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.Model;
using System.Data.SqlClient;

namespace NetCafeUCN.DAL.DAO
{
    public class EmployeeDAO : INetCafeDAO<Employee>
    {
        public bool Add(Employee o)
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
                                "INSERT INTO nc_Person VALUES(@name, @phone, @email, @personType); SELECT SCOPE_IDENTITY();", conn, trans))
                        {
                            productCommand.Parameters.AddWithValue("@name", o.Name);
                            productCommand.Parameters.AddWithValue("@phone", o.Phone);
                            productCommand.Parameters.AddWithValue("@email", o.Email);
                            productCommand.Parameters.AddWithValue("@personType", "Employee");
                            id = Convert.ToInt32(productCommand.ExecuteScalar());
                        }

                        using (SqlCommand command = new SqlCommand(
                            "INSERT INTO nc_Employee VALUES(@personid, @address, @role, @zipcode)", conn, trans))
                        {
                            command.Parameters.AddWithValue("@person", id);
                            command.Parameters.AddWithValue("@address", o.Address);
                            command.Parameters.AddWithValue("@role", o.Role);
                            command.Parameters.AddWithValue("@zipcode", o.Zipcode);
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

        public Employee? Get(dynamic key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            string sqlStatement = "SELECT * FROM nc_Employee inner join nc_Person on nc_Person.id = nc_Employee.personid";
            List<Employee> list = new();
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee employee = new Employee()
                        {
                            Name = (string?)reader["name"],
                            Email = (string?)reader["email"],
                            Phone = (string?)reader["phone"],
                            Role = (string?)reader["role"],
                            Address = (string?)reader["address"],
                            City = (string?)reader["city"],
                            Zipcode = (string?)reader["zipcode"]
                        };
                        list.Add(employee);
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

        public bool Update(Employee o)
        {
            throw new NotImplementedException();
        }
    }
}
