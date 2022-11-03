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
        public string SeatNumber { get; set; }
        public bool Booked  { get; set; }
        public int Tier { get; set; }
        public GamingStation(string productNumber, string description, string seatNumber, int Tier) : base(productNumber, description)
        {
            this.ProductNumber = productNumber;
            this.Description = description;
            this.SeatNumber = seatNumber;
            this.Tier = Tier;
            this.Booked = false;

        }

    }
}
