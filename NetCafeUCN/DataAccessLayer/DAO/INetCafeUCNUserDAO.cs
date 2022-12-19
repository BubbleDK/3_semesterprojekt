using NetCafeUCN.DAL.Model;

namespace NetCafeUCN.DAL.DAO
{
    /// <summary>
    /// INetCafeUCNUserDAO er et generic interface til User i DAO
    /// </summary>
    public interface INetCafeUCNUserDAO
    {
        /// <summary>
        /// Metoden henter alle objekter af typen User.
        /// </summary>
        /// <returns>Collection af typen User</returns>
        public IEnumerable<User> GetAll();
        /// <summary>
        /// Metoden henter et bestemt hash af et password ved brug af en email
        /// </summary>
        /// <param name="email">string email som skal bruges til at finde hashet på</param>
        /// <returns>Et UserLogin objekt</returns>
        public UserLogin GetHashByEmail(string email);
        /// <summary>
        /// Metoden henter en bestemt user ved brug af password hash og email
        /// </summary>
        /// <param name="Email">string af den email som skal bruges</param>
        /// <param name="passwordHash">string af det password hash som skal bruges</param>
        /// <returns>Et User objekt</returns>
        public User GetUserByLogin(string Email, string passwordHash);
    }
}
