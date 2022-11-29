using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace NetCafeUCN.MVC.Models
{
    public abstract class PersonDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public string? PersonType { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
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
