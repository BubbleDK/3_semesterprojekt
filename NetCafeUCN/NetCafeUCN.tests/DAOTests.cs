using NetCafeUCN.DAL.DAO;
using System.Data;
using System.Data.Common;
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
            SqlConnection Connection = new SqlConnection(DBConnection.ConnectionString);
            
                Connection.Open();
                connectionstate = Connection.State;

                Connection.Close();
            
            //Act

            //Assert
            Assert.True(connectionstate == ConnectionState.Open);

        }
    }
}