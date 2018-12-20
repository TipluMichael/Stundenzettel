using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class TimeHandler
    {
        public void GetOverTime(ObservableCollection<DayData> days)
        {
            foreach (var tday in days)
            {
                if (tday.Hours.TotalMinutes > 480)
                {
                    tday.Overtime =  tday.Hours - (TimeSpan.FromMinutes(480));
                }
                else
                {
                    tday.Overtime = new TimeSpan(0,0,0);
                }
            }
        }

        public TimeSpan OverallOvertime(ObservableCollection<DayData> days)
        {
            TimeSpan overAll = new TimeSpan();

            foreach (var day in days)
            {
                overAll += day.Overtime;
            }
            return overAll;
        }
    }
}
