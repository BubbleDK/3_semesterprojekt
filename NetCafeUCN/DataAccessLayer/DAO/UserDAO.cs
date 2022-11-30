using NetCafeUCN.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetCafeUCN.DAL.Model.User;

namespace NetCafeUCN.DAL.DAO
{
    public class UserDAO
    {
        public IEnumerable<User> GetAll()
        {
            UserRole tempRole = UserRole.Administrator;
            string sqlStatement = "SELECT * FROM nc_Person";
            List<User> list = new();
            using(SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string stringRole = (string)reader["PersonType"];
                        if (string.Equals(stringRole, "Employee", StringComparison.OrdinalIgnoreCase))
                        {
                            tempRole = UserRole.Administrator;
                        }
                        else
                        {
                            tempRole = UserRole.User;
                        }
                        User user = new User()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Email = (string)reader["Email"],
                            PhoneNo = (string)reader["Phone"],
                            PasswordHash = (string)reader["PasswordHash"],
                            Role = tempRole
                        };
                        list.Add(user);
                    }
                    return list;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public UserLogin? GetHashByEmail(string email)
        {
            string sqlStatement = "SELECT Email, passwordHash from nc_person where @email = email";
            UserLogin? user = null;
            using(SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@email", email);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new UserLogin()
                        {
                            Email = (string)reader["email"],
                            PasswordHash = (string)reader["PasswordHash"]
                        };
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return user;
            }
        }

        public User? GetUserByLogin(string Email, string passwordHash)
        {
            string sqlStatement = "SELECT * FROM nc_Person WHERE @email = Email and @passwordHash = passwordHash";
            User? user = null;
            UserRole tempRole;
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string stringRole = (string)reader["PersonType"];
                        if (string.Equals(stringRole, "Employee", StringComparison.OrdinalIgnoreCase))
                        {
                            tempRole = UserRole.Administrator;
                        }
                        else
                        {
                            tempRole = UserRole.User;
                        }
                        user = new User()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Email = (string)reader["Email"],
                            PhoneNo = (string)reader["Phone"],
                            PasswordHash = (string)reader["PasswordHash"],
                            Role = tempRole
                        };
                    }
                }


                catch (Exception)
                {

                    throw;
                }
            }
            return user;
        }
    }
}

        

