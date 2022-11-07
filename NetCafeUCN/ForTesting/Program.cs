

using DataAccessLayer.DAO;
using DataAccessLayer.Model;
using NetCafeUCN.DAL.DAO;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(DBConnection.ConnectionString);
        UserDataAccess userDataAccess = new UserDataAccess();
        Console.WriteLine(userDataAccess.GetAll());
        foreach (Person person in userDataAccess.GetAll())
        {
            Console.WriteLine(person.Phone);
        }
        Console.WriteLine(userDataAccess.Get("99999999").Name);
    }
}