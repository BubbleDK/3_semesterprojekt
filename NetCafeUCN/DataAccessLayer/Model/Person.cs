using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public abstract class Person
    {
        public string? Name{ get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public Person(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
        public Person()
        {

        }
    }
}
