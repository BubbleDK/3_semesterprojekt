using NetCafeUCN.MVC.Models.DTO;

namespace NetCafeUCN.MVC.Services
{
    public interface IUserProvider
    {
        User? GetUserByLogin(string email, string password);
    }
}
