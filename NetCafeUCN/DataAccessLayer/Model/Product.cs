using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.Model
{
    public abstract class Product
    {
        public string? ProductNumber{ get; set; }
        public string ?Type { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }

        public Product(string productNumber, string type, string name)
        {
            this.ProductNumber = productNumber;
            this.Type = type;
            this.Name = name;
            this.IsActive = true;
        }
        public Product()
        {
        }

        public override abstract string ToString();
        

    }
}
