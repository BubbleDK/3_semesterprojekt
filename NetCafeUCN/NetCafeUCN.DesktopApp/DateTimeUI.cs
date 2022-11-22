using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DesktopApp
{
    public class DateTimeUI
    {
        public static TimeOnly Time { get; set; }
        public static List<TimeOnly> _timeList;
        public DateTimeUI()
        {
            
        }
        public override string ToString()
        {
            return Time.Hour + ":" + Time.Minute;
        }

        public static List<TimeOnly> GetStartTimes()
        {
            _timeList = new List<TimeOnly>();
            for (int i = 9; i < 24; i++)
            {
                int intervals = 2;
                if (i == 23)
                {
                    intervals = 1;
                }
                for (int j = 0; j < intervals; j++)
                {
                    Time = new TimeOnly(i, j * 30);
                    _timeList.Add(Time);
                }
            }
            return _timeList;
        }
        public static List<TimeOnly> GetEndTimes()
        {
            _timeList = new List<TimeOnly>();
            for (int i = 9; i < 24; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Time = new TimeOnly(i, j * 30);
                    _timeList.Add(Time);
                }
            }
            Time = new TimeOnly(0, 0);
            _timeList.Add(Time);
            return _timeList;
        }
    }
}
