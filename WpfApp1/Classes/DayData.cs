using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class DayData
    {

        public DateTime Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public TimeSpan Hours { get; set; }
        public float BreakTime { get; set; }
        public string Reason { get; set; }

        public DayData(DateTime date, TimeSpan start, TimeSpan end, TimeSpan hours, float breakTime, string reason)
        {
            Date = date;
            Start = start;
            End = end;
            Hours = hours;
            BreakTime = breakTime;
            Reason = reason;
        }

        public DayData()
        {

        }

    }
}
