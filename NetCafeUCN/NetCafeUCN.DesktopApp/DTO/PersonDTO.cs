namespace NetCafeUCN.DesktopApp.DTO
{
    public abstract class PersonDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string PersonType { get; set; }
        public bool isActive { get; set; }
        public PersonDTO(string name, string email, string phone, string personType)
        {
            Name = name;
            Email = email;
            Phone = phone;
            PersonType = personType;
            isActive = true;
        }
        public PersonDTO()
        {

        }
        public override string ToString()
        {
            return Name;
        }
    }

}
