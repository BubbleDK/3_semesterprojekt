﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.MVC.Models
{
    public class Employee:Person
    {
        

        public string? Role { get; set; }
        public string? Address { get; set; }
        public int? Zipcode { get; set; }
        public string? City { get; set; }
        public Employee(string name, string email, string phone, string personType, string password, bool isActive) : base(name, email, phone, personType, password, isActive)
        {
        }
        public Employee():base()
        {

        }
    }
}
