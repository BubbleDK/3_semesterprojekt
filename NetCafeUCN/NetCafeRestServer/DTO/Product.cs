using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.API.DTO
{
    public abstract class Product
    {
        public string ProductNumber { get; set; }
        public string? Type { get; set; }
        public string Name { get; set; }

        public Product(string productNumber, string type, string name)
        {
            this.ProductNumber = productNumber;
            this.Type = type;
            this.Name = name;
        }
        public Product()
        {
        }

        public override abstract string ToString();


    }
}
