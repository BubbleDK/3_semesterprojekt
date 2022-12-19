namespace NetCafeUCN.MVC.Models.DTO
{
    /// <summary>
    /// UserDto model klasse
    /// </summary>
    public class UserDto
    {
        public enum UserRole { User, Administrator }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
    }
}
