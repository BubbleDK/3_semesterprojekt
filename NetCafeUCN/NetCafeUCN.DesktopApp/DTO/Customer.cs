using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DesktopApp.DTO
{
    public class Customer : Person
    {
        public Customer(string name, string email, string phone, string personType) : base(name, email, phone, personType)
        {
        }
        public Customer():base()
        {

        }
    }
}
