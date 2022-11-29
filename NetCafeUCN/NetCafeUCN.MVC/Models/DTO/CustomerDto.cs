using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.MVC.Models
{
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
