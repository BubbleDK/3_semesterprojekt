using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.MVC.Models
{
    /// <summary>
    /// GamingStationDto model klasse, nedarver fra ProductDto
    /// </summary>
    public class GamingStationDto : ProductDto
    {
        public int ProductID { get; set; } 
        public string? SeatNumber { get; set; }
        public string? Description { get; set; }
        public bool Booked { get; set; }
        public bool isChecked { get; set; }
    }
}
