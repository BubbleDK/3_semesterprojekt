namespace NetCafeUCN.DesktopApp.DTO
{
    public class Customer : Person
    {
        public Customer(string name, string email, string phone, string personType) : base(name, email, phone, personType)
        {
        }
        public Customer() : base()
        {

        }
    }
}
