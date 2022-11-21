namespace NetCafeUCN.MVC.Models.DTO
{
    public class User
    {
        public enum UserRole { User, Administrator }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
