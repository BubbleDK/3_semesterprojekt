using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DesktopApp.DTO
{
    internal class GamingStation:Product
    {
        public string? SeatNumber { get; set; }
        public string? Description { get; set; }
        public bool Booked { get; set; }
        
    }
}
