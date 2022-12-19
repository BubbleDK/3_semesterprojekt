namespace NetCafeUCN.MVC.Models
{
    /// <summary>
    /// EmployeeDto model klasse, nedarver fra PersonDto
    /// </summary>
    public class EmployeeDTO : PersonDTO
    {
        public string? Role { get; set; }
        public string? Address { get; set; }
        public int? Zipcode { get; set; }
        public string? City { get; set; }
        public EmployeeDTO(string name, string email, string phone, string personType, string password, bool isActive) : base(name, email, phone, personType, password, isActive)
        {
        }
        public EmployeeDTO():base()
        {

        }
    }
}
