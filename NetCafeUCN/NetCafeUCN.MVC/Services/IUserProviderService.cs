using NetCafeUCN.MVC.Models.DTO;

namespace NetCafeUCN.MVC.Services
{
    /// <summary>
    /// Interface som bruges til user service
    /// </summary>
    public interface IUserProviderService
    {
        /// <summary>
        /// Metode til er hente et hash ved brug af det indtastet email
        /// </summary>
        /// <param name="email">String af emailen som man ønsker at hente det hashet password på</param>
        /// <returns>Et UserLoginDto objekt</returns>
        UserLoginDto? GetHashByEmail(string email);
        /// <summary>
        /// Metode til at hente en specifik bruger, ved brug af email og password
        /// </summary>
        /// <param name="email">string af email på den specifikke bruger man vil hente</param>
        /// <param name="password">string af password på den specifikke bruger man vil hente </param>
        /// <returns></returns>
        UserDto? GetUserByLogin(string email, string password);
        
    }
}
