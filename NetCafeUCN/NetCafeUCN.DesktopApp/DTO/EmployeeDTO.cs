namespace NetCafeUCN.DesktopApp.DTO
{
    public class EmployeeDTO:PersonDTO
    {
        

        public string? Role { get; set; }
        public string? Address { get; set; }
        public int? Zipcode { get; set; }
        public string? City { get; set; }
        public EmployeeDTO(string name, string email, string phone, string personType) : base(name, email, phone, personType)
        {
        }
        public EmployeeDTO():base()
        {

        }
    }
}
