using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.Model
{
    public class Pack : Product
    {
        public List<PackLine> PackLines { get; set; }
        public Pack()
        {
            PackLines = new List<PackLine>();
        }
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
