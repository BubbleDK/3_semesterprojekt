namespace NetCafeUCN.DesktopApp.DTO
{
    public class CustomerDTO : PersonDTO
    {
        public CustomerDTO(string name, string email, string phone, string personType) : base(name, email, phone, personType)
        {
        }
        public CustomerDTO() : base()
        {

        }
    }
}
