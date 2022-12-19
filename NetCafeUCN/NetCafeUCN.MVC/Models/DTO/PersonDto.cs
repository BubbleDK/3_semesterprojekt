using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace NetCafeUCN.MVC.Models
{
    /// <summary>
    /// PersonDto model klasse, som er en abstrakt klasse
    /// </summary>
    public abstract class PersonDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", 
            ErrorMessage = "Ikke gyldigt email format. Eksempel af korrekt format: joe.example@example.org")]
        [EmailAddress(ErrorMessage = "Ikke en gyldig email")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Skriv et gyldigt telefonnummer")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^\\+?[1-9][0-9]{7}$", ErrorMessage = "Ikke et gyldigt telefonnummer")]
        public string Phone { get; set; } = string.Empty;
        public string? PersonType { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public PersonDto(string name, string email, string phone, string? personType, string password, bool isActive)
        {
            Name = name;
            Email = email;
            Phone = phone;
            PersonType = personType;
            Password = password;
            IsActive = isActive;    
        }
        public PersonDto()
        {

        }
        public override string ToString()
        {
            return Name;
        }
    }

}
