﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Employee:Person
    {
        public string? Role { get; set; }
        public string? Address { get; set; }
        public string? Zipcode { get; set; }
        public string? City { get; set; }
    }
}
