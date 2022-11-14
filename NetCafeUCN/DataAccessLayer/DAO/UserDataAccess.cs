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
using System.Data;

namespace DataAccessLayer.DAO
{
    public class UserDataAccess : INetCafeDataAccess<Person>
    {
        public bool Add(Person o)
        {
            string sqlStatement = "INSERT INTO nc_Person(name, phone, email, personType) VALUES (@name, @phone, @email, @personType)";

            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {

                try
                {
                    SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                    conn.Open();
                    cmd.Parameters.Add("@name", SqlDbType.VarChar);
                    cmd.Parameters["@name"].Value = o.Name;
                    cmd.Parameters.Add("@phone", SqlDbType.VarChar);
                    cmd.Parameters["@phone"].Value = o.Phone;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar);
                    cmd.Parameters["@email"].Value = o.Email;
                    cmd.Parameters.Add("@personType", SqlDbType.VarChar);
                    cmd.Parameters["@personType"].Value = o.PersonType;
                    var id = cmd.ExecuteScalar();

                    if (o.PersonType == "Employee")
                    {
                        AddEmployee(id, o.PersonType);
                    }
                    else if(o.PersonType == "Customer")
                    {
                        AddCustomer(id, o.PersonType);
                    }

                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
        }

        private bool AddCustomer(object id, string personType)
        {
            string sqlStatement = "INSERT INTO nc_Customer(id) VALUES (@id)";
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                    conn.Open();
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = id;

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                
            }
            
        }

        private void AddEmployee(object id, string personType)
        {
            string sqlStatement = "INSERT INTO nc_Employee(personid, address, role, zipCode) VALUES (@id, @address, @role, @zipCode)";
            using(SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                conn.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;
                cmd.Parameters.Add("@address", SqlDbType.VarChar);
                //cmd.Parameters["@address"].Value = 
            }
            throw new NotImplementedException();
        }

        public Person? Get(dynamic key)
        {
            string sqlStatement = "SELECT * FROM nc_Person WHERE phone = @phone";
            string secondSqlStatement = "";
            string personType = "";
            using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                cmd.Parameters.Add("@phone", SqlDbType.VarChar);
                cmd.Parameters["@phone"].Value = key;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if ((string?)reader["personType"] == "Customer")
                        {
                            secondSqlStatement = "SELECT * FROM nc_Customer inner join nc_Person on nc_Person.id = nc_Customer.personid where nc_Person.phone = @phone";
                            personType = "Customer";
                        }
                        else if ((string?)reader["personType"] == "Employee")
                        {
                            secondSqlStatement = "SELECT * FROM nc_Employee inner join nc_Person on nc_Person.id = nc_Employee.personid where nc_Person.phone = @phone";
                            personType = "Employee";
                        }
                    }
                }
                catch (Exception)
                {

                    throw new DataAccessException("Can't access data");
                }
            }
            using(SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(secondSqlStatement, conn);
                cmd.Parameters.Add("@phone", SqlDbType.VarChar);
                cmd.Parameters["@phone"].Value = key;
                Person? person = null;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if(personType == "Customer")
                        {
                            person = new Customer()
                            {
                                Name = (string?)reader["name"],
                                Email = (string?)reader["email"],
                                Phone = (string?)reader["phone"]
                            };
                        }
                        else if(personType == "Employee")
                        {
                            person = new Employee()
                            {
                                Name = (string?)reader["name"],
                                Email = (string?)reader["email"],
                                Phone = (string?)reader["phone"],
                                Role = (string)reader["role"],
                                Address = (string)reader["address"],
                                Zipcode = (string)reader["zipcode"],
                                City = (string)reader["City"]
                            };
                        }
                    }
                    return person;
                }
                catch (Exception)
                {

                    throw new DataAccessException("Can't access data");
                }
            }
        }

        public IEnumerable<Person> GetAll()
        {
            string sqlStatement = "SELECT * FROM nc_Person";
            List<Person> list = new();
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
                            Phone = (string?)reader["phone"],
                            PersonType = (string)reader["personType"]
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

        public IEnumerable<Customer> GetAllCustomers()
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
                            Customer person = new Customer()
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
        public IEnumerable<Employee> GetAllEmployee()
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
                            Employee person = new Employee()
                            {
                                Name = (string?)reader["name"],
                                Email = (string?)reader["email"],
                                Phone = (string?)reader["phone"],
                                Role = (string?)reader["role"],
                                Address = (string?)reader["address"],
                                City = (string?)reader["city"],
                                Zipcode = (string?)reader["zipcode"]
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
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.ConnectionString))
                {
                    using (var cmd = conn.CreateCommand())
                    {


                        conn.Open();
                        cmd.CommandText = sqlStatement;
                        cmd.Parameters.AddWithValue("@phone", key);
                        cmd.ExecuteNonQuery();

                        return true;


                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool Update(Person o)
        {
            throw new NotImplementedException();
        }
    }
}
