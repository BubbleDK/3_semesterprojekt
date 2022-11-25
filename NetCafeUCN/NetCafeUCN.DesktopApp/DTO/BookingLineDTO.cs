using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DesktopApp.DTO
{
    public class BookingLineDTO
    {
        public int? Quantity { get; set; }
        public int StationProductId { get; set; }
        public int? ConsumableProductId { get; set; }
    }
}
