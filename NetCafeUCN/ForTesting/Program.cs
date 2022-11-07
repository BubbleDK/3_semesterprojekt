

using DataAccessLayer.DAO;
using NetCafeUCN.DAL.DAO;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(DBConnection.ConnectionString);
        UserDataAccess userDataAccess = new UserDataAccess();
        Console.WriteLine(userDataAccess.GetAll());
        Console.WriteLine(userDataAccess.Get("88888888"));
    }
}