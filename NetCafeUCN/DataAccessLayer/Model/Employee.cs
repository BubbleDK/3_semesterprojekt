﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.Model
{
    public class Employee:Person
    {
        public string? Role { get; set; }
        public string? Address { get; set; }
        public int? Zipcode { get; set; }
    }
}
