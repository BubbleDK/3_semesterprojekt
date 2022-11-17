using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;
using System.Data;
using System.Data.SqlClient;

namespace NetCafeUCN.tests
{
    public class DAOTests
    {
        [Fact]
        public void TestDBConnection()
        {
            //Arrange
            ConnectionState? connectionstate = null;
            using (SqlConnection Connection = new SqlConnection(DBConnection.ConnectionString))
            {

                Connection.Open();
                connectionstate = Connection.State;

                //Connection.Close();

                //Act

                //Assert
                Assert.True(Connection.State == ConnectionState.Open);
            }
        }
        [Fact]
        public void TestGetAll()
        {
            //Arrange
            CustomerDAO customerDAO = new CustomerDAO();
            List<Customer> list = customerDAO.GetAll().ToList();
            //Assert
            Console.WriteLine(list);
            Assert.True(list.Count > 0);
        }
    }
}