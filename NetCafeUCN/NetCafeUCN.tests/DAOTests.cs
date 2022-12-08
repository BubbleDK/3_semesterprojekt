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
    public void TestCustomerDAO()
    {

        //Arrange
        Customer customer = new Customer();
        customer.Name = "Bob";
        customer.Email = "Bob@email.com";
        customer.Phone = "1";
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

            customer.Name = "Bobby";

            Assert.True(customerDAO.Update(customer));

            customerDAO.Remove(customer.Phone);

            Assert.False(customerDAO.Get(customer.Phone).IsActive);

        }
        finally
        {
            SqlCommand deleteCommand = new SqlCommand("DELETE nc_Person WHERE phone = @phoneNo", conn);

            deleteCommand.Parameters.AddWithValue("@phoneNo", 1);
            deleteCommand.ExecuteNonQuery();

            conn.Close();

        }
    }
    [Fact]
    public void TestBookingDAO()
    {

        //Arrange

        Booking booking = new Booking();
        Booking bookingSaved = new Booking();
        booking.StartTime = DateTime.Parse("2222 - 12 - 06T11: 00:00");
        booking.EndTime = DateTime.Parse("2222 - 12 - 06T12: 00:00");
        //Nummeret skal være i databasen
        booking.PhoneNo = "88888888";

        BookingLine boookingLine = new BookingLine();
        boookingLine.StationId = 1;
        boookingLine.Quantity = 1;
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

            booking.EndTime = booking.EndTime.AddHours(1);

            Assert.True(bookingDAO.Update(bookingSaved));

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