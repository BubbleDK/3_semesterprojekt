using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.API.DTO
{
    public class GamingStationDTO:ProductDTO
    {
        public int? ProductID { get; set; }
        public string? SeatNumber { get; set; }
        public string? Description { get; set; }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
