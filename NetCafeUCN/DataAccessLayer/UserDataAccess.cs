using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class UserDataAccess : INetCafeDataAccess<Person>
    {
        private string connectionString = @"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S212_10182474;Password=Password1!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
            string sqlStatement = "SELECT * FROM Persons";
            List<Person> list = new List<Person>();
            using(SqlConnection conn = new SqlConnection(connectionString))
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
                            name = (string)reader["name"],
                            phone = (string)reader["phone"],
                            email = (string)reader["email"]
                        };
                        list.Add(person);
                    }
                }
                catch
                {

                    throw;
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
