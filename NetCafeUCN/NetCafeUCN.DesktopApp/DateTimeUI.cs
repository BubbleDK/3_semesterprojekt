namespace NetCafeUCN.DesktopApp
{
    public class DateTimeUI
    {
        public static TimeSpan Time { get; set; }
        public static List<TimeSpan> _timeList;
        public DateTimeUI()
        {
            
        }
        public override string ToString()
        {
            return Time.Hours + ":" + Time.Minutes;
        }

        public static List<TimeSpan> GetStartTimes()
        {
            _timeList = new List<TimeSpan>();
            for (int i = 9; i < 24; i++)
            {
                int intervals = 2;
                if (i == 23)
                {
                    intervals = 1;
                }
                for (int j = 0; j < intervals; j++)
                {
                    Time = new TimeSpan(i, j * 30, 0);
                    _timeList.Add(Time);
                }
            }
            return _timeList;
        }
        public static List<TimeSpan> GetEndTimes()
        {
            _timeList = new List<TimeSpan>();
            for (int i = 9; i < 24; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Time = new TimeSpan(i, j * 30, 0);
                    _timeList.Add(Time);
                }
            }
            Time = new TimeSpan(0, 0, 0);
            _timeList.Add(Time);
            return _timeList;
        }
    }
}
