using NetCafeUCN.MVC.Models.DTO;

namespace NetCafeUCN.MVC.Services
{
    public interface IUserProvider
    {
        UserLoginDto? GetHashByEmail(string email);
        UserDto? GetUserByLogin(string email, string password);
        
    }
}
