﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.MVC.Models
{
    public abstract class Person
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string PersonType { get; set; }
        public Person(string name, string email, string phone, string personType)
        {
            Name = name;
            Email = email;
            Phone = phone;
            PersonType = personType;
        }
        public Person()
        {

        }
        public override string ToString()
        {
            return Name;
        }
    }

}
