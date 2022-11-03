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
            using(SqlConnection Connection = new SqlConnection(DBConnection.ConnectionString)) {
                Connection.Open();
                Assert.True(Connection.State == ConnectionState.Open);
                Connection.Close();
            }
            //Act
            
            //Assert
            
            
        }
    }
}