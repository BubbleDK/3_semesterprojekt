using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.API.DTO
{
    public abstract class Product
    {
        public string ProductNumber { get; set; } = string.Empty;
        public string? Type { get; set; }
        public string Name { get; set; } = String.Empty;
        public bool IsActive { get; set; } = true;

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
