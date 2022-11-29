using NetCafeUCN.MVC.Models.DTO;

namespace NetCafeUCN.MVC.Services
{
    public interface IUserProviderService
    {
        UserLoginDto? GetHashByEmail(string email);
        UserDto? GetUserByLogin(string email, string password);
        
    }
}
