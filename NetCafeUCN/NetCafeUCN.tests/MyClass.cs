using NetCafeUCN.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.tests
{
    public class MyClass
    {
        
        public void TestDBConn()
        {
            SqlConnection Connection = new SqlConnection(DBConnection.ConnectionString);
            Connection.Open();
            Console.WriteLine(Connection.State == ConnectionState.Open);
            //string querystring = "Select * From Booking";
            //SqlCommand command = new SqlCommand(querystring, Connection);
            //Assert.Throws<SqlException>(() => command.ExecuteNonQuery());
            Connection.Close();
        }
    }
}