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
                            command.Parameters.AddWithValue("@personid", id);
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
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                using SqlCommand command = new SqlCommand(
                    "SELECT name, phone, email, personType, address, role, zipCode FROM nc_Person INNER JOIN nc_Employee ON nc_Person.id = nc_Employee.personid WHERE phone = @phone;", conn);
                command.Parameters.AddWithValue("@phone", key);
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Employee person = new Employee()
                            {
                                Name = (string?)reader["name"],
                                Email = (string?)reader["email"],
                                Phone = (string?)reader["phone"],
                                Role = (string?)reader["role"],
                                Address = (string?)reader["address"],
                                Zipcode = (int)reader["zipCode"],
                                PersonType = (string)reader["personType"],
                            };
                            return person;
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

        public IEnumerable<Employee> GetAll()
        {
            string sqlStatement = "SELECT name, phone, email, personType, address, role, zipCode FROM nc_Person INNER JOIN nc_Employee ON nc_Person.id = nc_Employee.personid;";
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
                            Zipcode = (int)reader["zipCode"],
                            PersonType = (string)reader["personType"],
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
            SqlTransaction trans;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                conn.Open();
                using (trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(
                            "UPDATE nc_Person SET name = @name, phone = @phone, email = @email, personType = @personType WHERE phone = @phone", conn, trans))
                        {
                            command.Parameters.AddWithValue("@phone", o.Phone);
                            command.Parameters.AddWithValue("@name", o.Name);
                            command.Parameters.AddWithValue("@email", o.Email);
                            command.Parameters.AddWithValue("@personType", o.PersonType);
                            command.ExecuteNonQuery();
                        }
                        using (SqlCommand gcommand = new SqlCommand(
                            "UPDATE nc_Employee SET address = @address, role = @role, zipCode = @zipCode WHERE personid = (SELECT id FROM nc_Person WHERE phone = @phone)", conn, trans))
                        {
                            gcommand.Parameters.AddWithValue("@phone", o.Phone);
                            gcommand.Parameters.AddWithValue("@address", o.Address);
                            gcommand.Parameters.AddWithValue("@role", o.Role);
                            gcommand.Parameters.AddWithValue("@zipCode", o.Zipcode);
                            gcommand.ExecuteNonQuery();
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
