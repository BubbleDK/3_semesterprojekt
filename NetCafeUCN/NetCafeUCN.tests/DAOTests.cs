using DataAccessLayer.DAO;
using DataAccessLayer.Model;
using NetCafeUCN.DAL.DAO;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace NetCafeUCN.tests
{
    public class DAOTests
    {
        [Fact]
        public void TestDBConnection()
        {
            //Arrange
            ConnectionState? connectionstate = null;
            SqlConnection Connection = new SqlConnection(DBConnection.ConnectionString);
           
            Connection.Open();
            connectionstate = Connection.State;

            Connection.Close();
            
            //Act

            //Assert
            Assert.True(connectionstate == ConnectionState.Open);

        }
        [Fact]
        public void TestGetAll()
        {
            //Arrange
            UserDataAccess userDataAccess = new UserDataAccess();
            IEnumerable<Person> list = userDataAccess.GetAll();
            //Assert
            Console.WriteLine(list);
            //Assert.True(list.;
        }
    }
}