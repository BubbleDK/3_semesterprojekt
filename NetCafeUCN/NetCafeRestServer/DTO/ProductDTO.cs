using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.API.DTO
{
    public abstract class ProductDTO
    {
        public string ProductNumber { get; set; } = string.Empty;
        public string? Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ProductDTO(string productNumber, string type, string name)
        {
            this.ProductNumber = productNumber;
            this.Type = type;
            this.Name = name;
        }
        public ProductDTO()
        {
        }

        public override abstract string ToString();


    }
}
