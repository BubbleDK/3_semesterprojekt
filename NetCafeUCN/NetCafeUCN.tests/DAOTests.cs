using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;
using NetCafeUCN.MVC.Authentication;
using System.Data;
using System.Data.SqlClient;

namespace NetCafeUCN.tests;

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


            //Act

            //Assert
            Assert.True(Connection.State == ConnectionState.Open);
        }
    }
    [Fact]
    public void TestCustomerGetAll()
    {
        //Arrange
        CustomerDAO customerDAO = new CustomerDAO();
        List<Customer> list = customerDAO.GetAll().ToList();
        //Assert
        Assert.True(list.Count > 0);
    }
    [Fact]
    public void TestBookingGetAll()
    {
        //Arrange
        BookingDAO bookingDAO = new BookingDAO();
        List<Booking> list = bookingDAO.GetAll().ToList();
        //Assert
        Assert.True(list.Count > 0);
    }

    [Fact]
    public void TestCustomerCRUDDAO()
    {

        //Arrange
        Customer customer = new Customer();
        customer.Name = "Bob the Tester";
        customer.Email = "Bob@email.com";
        customer.Phone = "10000000";
        customer.PersonType = "Customer";
        customer.IsActive = true;
        customer.Password = BCryptTool.HashPassword("password");
        CustomerDAO customerDAO = new CustomerDAO();
        UserDAO userDAO = new UserDAO();
        SqlConnection conn = new SqlConnection(DBConnection.ConnectionString);

        try
        {
            //Act
            conn.Open();


            customerDAO.Add(customer);

            Customer customer2 = new Customer();
            customer2 = customerDAO.Get(customer.Phone);
            customer2.Password = userDAO.GetHashByEmail(customer.Email).PasswordHash;
            //Assert
            Assert.Equivalent(customer, customer2);

            customer.Name = "Bobby the Tester";

            Assert.True(customerDAO.Update(customer));

            customerDAO.Remove(customer.Phone);

            Assert.False(customerDAO.Get(customer.Phone).IsActive);

        }
        finally
        {
            SqlCommand deleteCommand = new SqlCommand("DELETE nc_Person WHERE phone = @phoneNo", conn);

            deleteCommand.Parameters.AddWithValue("@phoneNo", 10000000);
            deleteCommand.ExecuteNonQuery();

            conn.Close();

        }
    }
    [Fact]
    public void TestGamingStationCRUDDAO()
    {

        //Arrange
        GamingStation gamingStation = new GamingStation();
        gamingStation.ProductNumber = "Test1000";
        gamingStation.Type = "Gamingstation";
        gamingStation.Name = "Gamer 1";
        gamingStation.IsActive = true;
        gamingStation.SeatNumber = "1";
        gamingStation.Description = "Gamer PC 1 på plads nr 1";
        GamingStationDAO gamingStationDAO = new GamingStationDAO();
        SqlConnection conn = new SqlConnection(DBConnection.ConnectionString);

        try
        {
            //Act
            conn.Open();


            gamingStationDAO.Add(gamingStation);

            GamingStation gamingStation2 = new GamingStation();
            gamingStation2 = gamingStationDAO.Get(gamingStation.ProductNumber);
            //Assert
            Assert.Equal(gamingStation.ProductNumber, gamingStation2.ProductNumber);

            gamingStation.Name = "Gamingstation 1";
            gamingStation.Description = "Gamingstation 1 på plads nr 1";

            Assert.True(gamingStationDAO.Update(gamingStation));

            gamingStationDAO.Remove(gamingStation.ProductNumber);

            Assert.False(gamingStationDAO.Get(gamingStation.ProductNumber).IsActive);

        }
        finally
        {
            SqlCommand deleteCommand = new SqlCommand("DELETE nc_Product WHERE productNo = @productNo", conn);

            deleteCommand.Parameters.AddWithValue("@productNo", "Test1000");
            deleteCommand.ExecuteNonQuery();

            conn.Close();
        }
    }

    [Fact]
    public void TestConsumableCRUDDAO()
    {

        //Arrange
        Consumable consumable = new Consumable();
        consumable.ProductNumber = "Test2000";
        consumable.Type = "Consumable";
        consumable.Name = "Consumable 1";
        consumable.IsActive = true;
        consumable.Description = "Consumable 1";
        ConsumableDAO consumableDAO = new ConsumableDAO();
        SqlConnection conn = new SqlConnection(DBConnection.ConnectionString);

        try
        {
            //Act
            conn.Open();


            consumableDAO.Add(consumable);

            Consumable consumable2 = new Consumable();
            consumable2 = consumableDAO.Get(consumable.ProductNumber);
            //Assert
            Assert.Equivalent(consumable, consumable2);

            consumable.Name = "Banan";
            consumable.Description = "Banan";

            Assert.True(consumableDAO.Update(consumable));

            consumableDAO.Remove(consumable.ProductNumber);

            Assert.Null(consumableDAO.Get(consumable.ProductNumber));

        }
        finally
        {
            SqlCommand deleteCommand = new SqlCommand("DELETE nc_Product WHERE productNo = @productNo", conn);

            deleteCommand.Parameters.AddWithValue("@productNo", "Test2000");
            deleteCommand.ExecuteNonQuery();

            conn.Close();
        }
    }
    [Fact]
    //Test Create Read og Delete booking
    public void TestBookingCRDDAO()
    {

        //Arrange

        Booking booking = new Booking();
        Booking bookingSaved = new Booking();
        booking.StartTime = DateTime.Parse("2222 - 12 - 06T11: 00:00");
        booking.EndTime = DateTime.Parse("2222 - 12 - 06T12: 00:00");
        //Nummeret SKAL være i databasen
        booking.PhoneNo = "88888888";

        BookingLine boookingLine = new BookingLine();
        boookingLine.StationId = 1;
        boookingLine.Quantity = 0;
        boookingLine.ConsumableId = -1;
        booking.addToBookingLine(boookingLine);

        BookingDAO bookingDAO = new BookingDAO();

        SqlConnection conn = new SqlConnection(DBConnection.ConnectionString);
        
        

        try
        {
            //Act
            conn.Open();


            //Assert
            Assert.True(bookingDAO.Add(booking));

            SqlCommand getLastSavedCommand = new SqlCommand("SELECT TOP 1 * FROM nc_Booking ORDER BY ID DESC", conn);
            getLastSavedCommand.ExecuteNonQuery();

            SqlDataReader reader = getLastSavedCommand.ExecuteReader();
            while (reader.Read())
            {
                bookingSaved.BookingNo = (string)reader["bookingNo"];
            }
            bookingSaved = bookingDAO.Get(bookingSaved.BookingNo);
            

            Assert.Equivalent(booking.PhoneNo, bookingSaved.PhoneNo);
            Assert.Equivalent(booking.BookingLines, bookingSaved.BookingLines);

            bookingDAO.Remove(bookingSaved.BookingNo);

            Assert.Null(bookingDAO.Get(booking.BookingNo));

        }
        finally
        {
            //Slet den eksisterende test fra tidligere, hvis den eksisterer
            try
            {
                SqlCommand deleteCommand = new SqlCommand("DELETE nc_Booking WHERE bookingNo = @bookingNo", conn);

                deleteCommand.Parameters.AddWithValue("@bookingNo", bookingSaved.BookingNo);
                deleteCommand.ExecuteNonQuery();
            }
            catch (Exception) { }
            conn.Close();

        }
    }
    [Fact]
    public void TestEmployeeDAO()
    {
        Employee employee = new Employee();
        employee.Name = "EmployeeTest";
        employee.Email = "EmployeeTest@email.com";
        employee.Phone = "1";
        employee.PersonType = "Employee";
        employee.IsActive = true;
        employee.Password = BCryptTool.HashPassword("password");
        employee.Role = "Administrator";
        employee.Address = "EmployeeRoad 1";
        employee.Zipcode = 9000;
        EmployeeDAO employeeDAO = new EmployeeDAO();
        UserDAO userDAO = new UserDAO();
        SqlConnection conn = new SqlConnection(DBConnection.ConnectionString);
        //Sletter før metoden kører i tilfælde af, at testen er fejlet før og der derfor er gemt en Employee med phone = 1
        try
        {
            SqlCommand deleteBeforeEmployeeCommand = new SqlCommand("DELETE nc_Employee WHERE phone = @phone", conn);
            SqlCommand deleteBeforeCommand = new SqlCommand("DELETE nc_Person WHERE phone = @phone", conn);
            deleteBeforeCommand.Parameters.AddWithValue("@phone", 1);
            deleteBeforeCommand.ExecuteNonQuery();
            deleteBeforeEmployeeCommand.Parameters.AddWithValue("@phone", 1);
            deleteBeforeEmployeeCommand.ExecuteNonQuery();
        }
        catch (Exception)
        {


        }

        try
        {
            //Act
            conn.Open();


            employeeDAO.Add(employee);

            Employee customer2 = new Employee();
            customer2 = employeeDAO.Get(employee.Phone);
            customer2.Password = userDAO.GetHashByEmail(employee.Email).PasswordHash;
            //Assert
            Assert.Equivalent(employee, customer2);

            employee.Name = "Bobby";

            Assert.True(employeeDAO.Update(employee));

            employeeDAO.Remove(employee.Phone);

            Assert.False(employeeDAO.Get(employee.Phone).IsActive);

        }
        finally
        {
            SqlCommand deleteEmployeeCommand = new SqlCommand("DELETE nc_Employee WHERE phone = @phone", conn);
            SqlCommand deleteCommand = new SqlCommand("DELETE nc_Person WHERE phone = @phone", conn);

            deleteCommand.Parameters.AddWithValue("@phone", 1);
            deleteCommand.ExecuteNonQuery();
            deleteEmployeeCommand.Parameters.AddWithValue("@phone", 1);
            deleteEmployeeCommand.ExecuteNonQuery();

            conn.Close();

        }
    }
}