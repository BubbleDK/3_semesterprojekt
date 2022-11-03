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
        public int Add(Person o)
        {
            throw new NotImplementedException();
        }

        public Person? Get(dynamic key)
        {
            throw new NotImplementedException();
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

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Person o)
        {
            throw new NotImplementedException();
        }
    }
}
