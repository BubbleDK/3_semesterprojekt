﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.Model
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
