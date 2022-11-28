using NetCafeUCN.MVC.Models.DTO;

namespace NetCafeUCN.MVC.Services
{
    public interface IUserProvider
    {
        UserDto? GetUserByLogin(string email, string password);
        
    }
}
