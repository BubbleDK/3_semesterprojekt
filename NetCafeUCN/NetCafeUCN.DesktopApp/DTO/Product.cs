using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DesktopApp.DTO
{
    public class Product
    {
        public string? ProductNumber { get; set; }
        public string? Type { get; set; }

        public string? Name { get; set; }

        public override string ToString()
        {
            return "Produkt nr: " + ProductNumber + " Produkttype: " + Type;
        }
    }
}
