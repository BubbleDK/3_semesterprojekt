namespace NetCafeUCN.MVC.Models.DTO
{
    /// <summary>
    /// UserLoginDto model klasse
    /// </summary>
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string? PasswordHash { get; set; }
    }
}
