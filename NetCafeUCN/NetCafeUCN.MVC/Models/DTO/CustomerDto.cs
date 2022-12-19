namespace NetCafeUCN.MVC.Models
{
    /// <summary>
    /// CustomerDto model klasse, nedarver fra PersonDto
    /// </summary>
    public class CustomerDto : PersonDto
    {
        public CustomerDto(string name, string email, string phone, string personType, string password, bool isActive) : base(name, email, phone, personType, password, isActive)
        {
            isActive = true;
            PersonType = "Customer";
        }
        public CustomerDto() : base()
        {
            
        }
    }
}
