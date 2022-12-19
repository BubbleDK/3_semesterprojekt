using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.Model
{
    /// <summary>
    ///  UserLogin model klasse
    /// </summary>
    public class UserLogin
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
