using DataAccessLayer.DAO;
using DataAccessLayer.Exceptions;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.DAO
{
    public class CustomerDAO : INetCafeDataAccess<Customer>
    {
        public bool Add(Customer o)
        {
            throw new NotImplementedException();
        }

        public Customer? Get(dynamic key)
        {
            throw new NotImplementedException();
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
