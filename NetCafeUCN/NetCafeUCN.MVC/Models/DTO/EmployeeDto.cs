namespace NetCafeUCN.MVC.Models
{
    /// <summary>
    /// EmployeeDto model klasse, nedarver fra PersonDto
    /// </summary>
    public class EmployeeDto : PersonDto
    {
        public string? Role { get; set; }
        public string? Address { get; set; }
        public int? Zipcode { get; set; }
        public string? City { get; set; }
        public EmployeeDto(string name, string email, string phone, string personType, string password, bool isActive) : base(name, email, phone, personType, password, isActive)
        {
        }
        public EmployeeDto():base()
        {

        }
    }
}
