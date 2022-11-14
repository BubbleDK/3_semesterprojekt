using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.Model;
using System.Data.SqlClient;

namespace NetCafeUCN.DAL.DAO
{
    public class EmployeeDAO : INetCafeDataAccess<Employee>
    {
        public bool Add(Employee o)
        {
            throw new NotImplementedException();
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
