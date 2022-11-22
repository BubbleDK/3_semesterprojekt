using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DesktopApp
{
    public class DateTimeUI
    {
        public TimeOnly Time { get; set; }
        public override string ToString()
        {
            return Time.Hour + ":" + Time.Minute;
        }
    }
}
