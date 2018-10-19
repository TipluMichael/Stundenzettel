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
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Hours { get; set; }

        public DayData(DateTime date, DateTime start, DateTime end, TimeSpan hours)
        {
            Date = date;
            Start = start;
            End = end;
            Hours = hours;
        }
        public DayData()
        {

        }
    }
}
