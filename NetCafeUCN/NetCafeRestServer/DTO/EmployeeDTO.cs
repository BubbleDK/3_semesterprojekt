using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.API.DTO
{
    /// <summary>
    ///  EmployeeDTO model, arver fra PersonDTO
    /// </summary>
    public class EmployeeDTO:PersonDTO
    {
        public string Role { get; set; }
        public string Address { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
    }
}
