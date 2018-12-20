using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Management
    {
        public TimeHandler tHandler { get; } = new TimeHandler();
        Reader rdr = new Reader(); 
        public Management()
        {

        }

        public void Run(ObservableCollection<DayData> day)
        {
            rdr.GetData(day);
            tHandler.GetOverTime(day);
        }
    }
}
