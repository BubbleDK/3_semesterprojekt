using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.Model
{
    public class Pack : Product
    {
        public List<PackLine> PackLines { get; set; } = new List<PackLine>();
        public Pack()
        {

        }
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
