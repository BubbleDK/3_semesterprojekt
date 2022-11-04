using DataAccessLayer.DAO;
using NetCafeUCN.Desktop;

namespace DesktopUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UserDataAccess userDataAccess = new UserDataAccess();
            Console.WriteLine(userDataAccess.GetAll());
            Console.ReadLine();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrontPage());
            
        }
    }
}