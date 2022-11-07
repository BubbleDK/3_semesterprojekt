using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.Model
{
    public class GamingStation : Product
    {
        public string ?SeatNumber { get; set; }
        public string ?Description { get; set; }
        public bool Booked  { get; set; }
        public GamingStation(string productNumber, string type, string seatNumber, string description) : base(productNumber, type)
        {
            this.ProductNumber = productNumber;
            this.Description = description;
            this.Type = type;
            this.SeatNumber = seatNumber;
            this.Booked = false;
        }

        public GamingStation()
        {
        }
    }
}
