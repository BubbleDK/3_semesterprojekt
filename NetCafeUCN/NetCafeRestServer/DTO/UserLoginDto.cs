namespace NetCafeUCN.API.DTO
{
    /// <summary>
    ///  UserLoginDto model
    /// </summary>
    public class UserLoginDTO
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
