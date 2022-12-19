namespace NetCafeUCN.MVC.Models
{
    /// <summary>
    /// CustomerDto model klasse, nedarver fra PersonDto
    /// </summary>
    public class CustomerDTO : PersonDTO
    {
        public CustomerDTO(string name, string email, string phone, string personType, string password, bool isActive) : base(name, email, phone, personType, password, isActive)
        {
            isActive = true;
            PersonType = "Customer";
        }
        public CustomerDTO() : base()
        {
            
        }
    }
}
