using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Exceptions;
using NetCafeUCN.DAL.DAO;

namespace DataAccessLayer.DAO
{
    public class UserDataAccess : INetCafeDataAccess<Person>
    {
        public bool Add(Person o)
        {
            throw new NotImplementedException();
        }

        public Person? Get(dynamic key)
        {
            string sqlStatement = "SELECT * FROM nc_Person WHERE phone = @phone";

            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                cmd.Parameters.Add("@phone", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@phone"].Value = key;
                Person? person = null;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if ((string?)reader["personType"] == "Customer")
                        {
                            person = new Customer()
                            {
                                Name = (string?)reader["name"],
                                Email = (string?)reader["email"],
                                Phone = (string?)reader["phone"]
                            };
                        }
                        else if ((string?)reader["personType"] == "Employee")
                        {
                            person = new Employee()
                            {
                                Name = (string?)reader["name"],
                                Email = (string?)reader["email"],
                                Phone = (string?)reader["phone"],
                                Role = (string)reader["role"],
                                Address = (string)reader["address"],
                                Zipcode = (int)reader["zipcode"],
                                City = (string)reader["City"]

                            };
                        }
                        
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return person;
            }
        }

        public IEnumerable<Person> GetAll()
        {
            string sqlStatement = "SELECT * FROM nc_Person";
            List<Person> list = new List<Person>();
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Person person = new Customer()
                        {
                            Name = (string?)reader["name"],
                            Email = (string?)reader["email"],
                            Phone = (string?)reader["phone"]
                        };
                        list.Add(person);
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
            string sqlStatement = "DELETE FROM nc_Person WHERE phone = @phone";

            using(SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);

                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    cmd.Parameters.Add("@phone", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@phone"].Value = key;
                    cmd.ExecuteNonQuery();


                }
                catch (Exception)
                {

                    throw;
                }
            }
            throw new NotImplementedException();
        }

        public bool Update(Person o)
        {
            throw new NotImplementedException();
        }
    }
}
