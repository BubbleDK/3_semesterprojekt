namespace NetCafeUCN.MVC.Models.DTO
{
    /// <summary>
    /// UserDto model klasse
    /// </summary>
    public class UserDTO
    {
        public enum UserRole { User, Administrator }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}
