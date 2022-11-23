using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.Model
{
    public class PackLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public PackLine(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }
    }
}
