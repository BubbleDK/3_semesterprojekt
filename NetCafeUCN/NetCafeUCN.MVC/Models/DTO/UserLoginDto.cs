namespace NetCafeUCN.MVC.Models.DTO
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string? PasswordHash { get; set; }
    }
}
