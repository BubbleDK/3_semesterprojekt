using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.API.DTO
{
    public class PersonDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? PersonType { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

}
