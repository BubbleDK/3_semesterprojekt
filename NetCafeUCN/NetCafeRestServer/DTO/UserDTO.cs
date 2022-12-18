namespace NetCafeUCN.API.DTO
{
    /// <summary>
    ///  UserDTO model
    /// </summary>
    public class UserDTO
    {
        public enum UserRole { User, Administrator }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNo { get; set; }
        public UserRole Role { get; set; }
    }
}
