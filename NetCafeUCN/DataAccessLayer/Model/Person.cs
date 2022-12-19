namespace NetCafeUCN.DAL.Model
{
    /// <summary>
    ///  Person model klasse, som er en abstrakt klasse.
    /// </summary>
    public abstract class Person
    {
        public string? Name{ get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? PersonType { get; set; }
        public bool IsActive { get; set; }
        public string? Password { get; set; }

        /// <summary>
        /// Person constructor
        /// </summary>
        /// <param name="name">En string af person navnet</param>
        /// <param name="email">En string af en email</param>
        /// <param name="phone">En string af et telefon nummer</param>
        /// <param name="personType">En string af personens type</param>
        /// <param name="password">En string af personens password</param>
        public Person(string name, string email, string phone, string personType, string password)
        {
            Name = name;
            Email = email;
            Phone = phone;
            PersonType = personType;
            IsActive = true;
            Password = password;    
        }
        public Person()
        {

        }
    }
}
