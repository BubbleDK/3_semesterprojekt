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
        public GamingStation(string productNumber, string type, string name, string seatNumber, string description) : base(productNumber, type, name)
        {
            this.ProductNumber = productNumber;
            this.Description = description;
            this.Name = name;
            this.Type = type;
            this.SeatNumber = seatNumber;
        }

        public GamingStation()
        {
        }

        public override string ToString()
        {

            return ProductNumber + SeatNumber;
        }
    }
}
