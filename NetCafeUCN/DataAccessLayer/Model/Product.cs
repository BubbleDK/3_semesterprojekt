using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public abstract class Product
    {
        public string ProductNumber{ get; set; }
        public string Description { get; set; }
    }
}
