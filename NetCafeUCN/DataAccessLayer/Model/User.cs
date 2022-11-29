namespace NetCafeUCN.DAL.Model
{
    public class User
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
